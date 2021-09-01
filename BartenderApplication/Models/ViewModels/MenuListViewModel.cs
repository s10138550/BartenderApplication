using System.Collections.Generic;
using BartenderApplication.Models;
namespace BartenderApplication.Models.ViewModels
{
    public class MenuListViewModel
    {
        public IEnumerable<Menu> Menu { get; set; }
        public PagingInfo PagingInfo { get; set; }

        

    }
}