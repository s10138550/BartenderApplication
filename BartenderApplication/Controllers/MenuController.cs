using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BartenderApplication.Models;
using BartenderApplication.Models.ViewModels;

namespace BartenderApplication.Controllers
{
    public class MenuController : Controller
    {
        private IMenuRepository repository;
        public int PageSize = 4;
        public MenuController(IMenuRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(string category, int page = 1)
            => View(new MenuListViewModel{
               Menu = repository.Menu
                        .OrderBy(p => p.MenuID)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize),
               PagingInfo = new PagingInfo
               {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Menu.Count()
               }
            });
    }
}