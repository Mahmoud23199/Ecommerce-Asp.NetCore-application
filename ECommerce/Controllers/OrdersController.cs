using ECommerce.data.ViewModel;
using ECommerce.Data.Cart;
using ECommerce.Models;
using ECommerce.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ShoppingCart shoppingCart;
        private readonly IUnitOfWork unitOfWork;
        public OrdersController(ShoppingCart _shoppingCartItem, IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            this.shoppingCart = _shoppingCartItem;
            
        }
        // GET: OrdersController
        public ActionResult ShoppingCart()
        {
            var item = shoppingCart.GetShoppingCartItems();

            shoppingCart.ShoppingCartItems=item;
            var response = new ShoppingCartVM() 
            {
                ShoppingCardTotal =shoppingCart.GetShoppingCartTotal(), 
                ShoppingCart = shoppingCart
            };

            return View(response);
        }

        

        public async Task<RedirectToActionResult> AddItemToCart(int id)
        {
            var item =await unitOfWork.Movies.GetByIdAsync(id);
            if(item != null)
            {
                shoppingCart.AddItemToCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));

        }


    
        public async Task<RedirectToActionResult> RemoveItemFCart(int id)
        {
            var item = await unitOfWork.Movies.GetByIdAsync(id);
            if (item != null)
            {
                shoppingCart.RemoveItemFromCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart)); 
        }







      
    }
}
