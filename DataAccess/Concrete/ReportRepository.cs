

using DataAccess.Abstract.Interfaces;
using DataAccess.Context;
using Entities.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ReportRepository:IReportRepository
    {
        private readonly RiseAssesstmentContext _context;

        public ReportRepository(RiseAssesstmentContext context)
        {
            _context = context;
        }

        public IQueryable<Report> GetAll()
        {
            return _context.Reports.Include(q=>q.ReportStatus);
        }

        public Report Get(Guid id)
        {
            return _context.Reports.Include(q => q.ReportStatus).FirstOrDefault(q=>q.Id==id);
        }

        public async Task<Report> AddAsync(Report report)
        {
            await _context.AddAsync(report);
            await _context.SaveChangesAsync();

            return report;
        }

        public async Task UpdateAsync(Report report)
        {
            var existingEntity = await _context.Reports.FindAsync(report.Id);
             _context.Entry(existingEntity).CurrentValues.SetValues(report);
            await _context.SaveChangesAsync();
        }
    }
}
