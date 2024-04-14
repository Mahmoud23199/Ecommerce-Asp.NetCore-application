using ECommerce.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.data.ViewComponents
{
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly ShoppingCart shoppingCart;
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke() 
        {

            var item = shoppingCart.GetShoppingCartItems();
            return View(item.Count);
         
        }

    }
}
