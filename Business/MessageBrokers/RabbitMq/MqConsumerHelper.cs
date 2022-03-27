using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.ViewModels;
using Entities.Concrete.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
 

namespace Business.MessageBrokers.RabbitMq
{
    public class MqConsumerHelper : BackgroundService
    {
        private IModel _channel;
        private IConnection _connection;
        private string _queueName;

        private readonly MessageBrokerOptions _brokerOptions;
        private readonly IReportService _reportService;

        public MqConsumerHelper(IConfiguration configuration, IReportService reportService )
        {
            _reportService = reportService;
            _brokerOptions = configuration.GetSection("MessageBrokerOptions").Get<MessageBrokerOptions>();
            InitializeRabbitMqListener();
            
        }

        private void InitializeRabbitMqListener()
        {
            _queueName = _brokerOptions.QueueName;

            var factory = new ConnectionFactory()
            {
                HostName = _brokerOptions.HostName,
                UserName = _brokerOptions.UserName,
                Password = _brokerOptions.Password
            };

            _connection = factory.CreateConnection();
            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, mq) =>
            {

                var body = mq.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);


                HandleMessage(message).Wait(stoppingToken);

            };

            _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

            return Task.CompletedTask;

        }


        private async Task HandleMessage(string message)
        {

            ReportRequestModelWithLocation model = JsonConvert.DeserializeObject<ReportRequestModelWithLocation>(message);
            Report reportPending = new Report() { RequestDate = DateTime.Now, ReportStatusId = 1 };

            //CreateReport Reading
             await _reportService.AddAsync(reportPending);



            //UpdateReportforReady
            var report = _reportService.Get(reportPending.Id);
            report.Data.PhoneNumberCount = model.ContactInformations.Where(q => !String.IsNullOrEmpty(q.Phone)).Count(q => q.Location == model.location);
            report.Data.ContactCount = model.ContactInformations.Count(q => q.Location == model.location);
            report.Data.Location = model.location;
            report.Data.ReportStatusId = 2;



            var fileName = $"report-excel-{Guid.NewGuid().ToString().Substring(1, 10)}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", fileName);
            Microsoft.Office.Interop.Excel.Application xlOrn = new Microsoft.Office.Interop.Excel.Application();
            if (xlOrn != null)
            {
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlOrn.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Cells[1, 1] = "Location";
                xlWorkSheet.Cells[2, 1] = report.Data.Location;
                xlWorkSheet.Cells[1, 2] = "Contact Count";
                xlWorkSheet.Cells[2, 2] = report.Data.ContactCount;
                xlWorkSheet.Cells[1, 3] = "Phone Count";
                xlWorkSheet.Cells[2, 3] = report.Data.PhoneNumberCount;
                xlWorkBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlOrn.Quit();
            }


            report.Data.FilePath = path+".xls";


            await _reportService.UpdateAsync(report.Data);


    





        }

        public virtual void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }



       
    }
}
