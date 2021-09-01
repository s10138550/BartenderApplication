using BartenderApplication.Models;
namespace BartenderApplication.Models.ViewModels
{
    public class CartIndexViewModel
    {
        public Order Order { get; set; }
        public string ReturnUrl { get; set; }
    }
}