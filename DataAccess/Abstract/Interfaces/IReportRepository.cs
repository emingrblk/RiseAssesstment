
using Entities.Concrete.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Abstract.Interfaces
{
    public interface IReportRepository
    {
        IQueryable<Report> GetAll();
        Report Get(Guid id);
        Task<Report> AddAsync(Report report);
        Task UpdateAsync(Report report);
    }
}
