using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BartenderApplication.Models
{
    public class EFMenuRepository : IMenuRepository
    {
        private ApplicationDbContext context;
        public EFMenuRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Menu> Menu => context.Menu;
    }
}
