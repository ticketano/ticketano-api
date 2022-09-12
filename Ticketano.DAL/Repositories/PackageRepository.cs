using Ticketano.DAL.Models;

namespace Ticketano.DAL.Repositories;

public class PackageRepository: BaseRepository<Package>
{
    public PackageRepository(ApplicationDbContext db) : base(db)
    {
    }
    
    // Invoicing
    // Mass mailing
    // Credit card payments
    // Add image galleries, videos, custom buttons
    // Embedded
    // Place counts
    // Plan draw by us
}