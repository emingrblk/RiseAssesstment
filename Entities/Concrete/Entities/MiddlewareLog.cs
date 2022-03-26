using Entities.Abstract.Interface;
using System;
 

namespace Entities.Concrete.Entities
{
    public class MiddlewareLog : IEntity
    {
        public Guid Id { get; set; }
        public string LogMessage { get; set; }
        public string LogInnerException { get; set; }
        public string LogStackTrace { get; set; }
        public string LogMethod { get; set; }
        public string ControllerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Path { get; set; }
        public string UserIp { get; set; }
    }
}
