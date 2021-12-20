
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PresentationDomain;

namespace PresentationApplication.Interfaces
{
    public interface IPresentationDbContext
    {
        DbSet<Presentation> Presentaions { get; set; }
      
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
