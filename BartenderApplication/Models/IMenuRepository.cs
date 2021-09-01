using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BartenderApplication.Models
{
    public interface IMenuRepository
    {
        IEnumerable<Menu> Menu { get; }
    }
}