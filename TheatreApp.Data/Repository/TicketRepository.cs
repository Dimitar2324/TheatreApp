using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatreApp.Data.Models;
using TheatreApp.Data.Repository.Interfaces;

namespace TheatreApp.Data.Repository
{
    public class TicketRepository : BaseRepository<Ticket, Guid>, ITicketRepository
    {
        public TicketRepository(TheatreAppDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
