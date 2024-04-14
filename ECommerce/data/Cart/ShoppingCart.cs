using ECommerce.Models;
using ECommerce.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Data.Cart
{
    public class ShoppingCart
    {
        private readonly EcommerceContext context;
        private readonly IUnitOfWork unitOfWork;

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(EcommerceContext context)
        {
            this.context = context;
        }
        public static ShoppingCart GetShoppingCart(IServiceProvider service) 
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context=service.GetService<EcommerceContext>();

            string cartId=session.GetString("CartId")??Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId= cartId };
        }

        public void AddItemToCart(Movie movie) 
        {
            var ShopItem=context.shoppingCartItems.FirstOrDefault(i=>i.Movie.Id==movie.Id&&i.ShoppingCardId==ShoppingCartId);

            if (ShopItem!=null) 
            {
                ShopItem.Amount++;
            }
            else
            {
                context.shoppingCartItems.Add(new ShoppingCartItem { Amount = 1, Movie = movie ,ShoppingCardId=ShoppingCartId });
            }
            context.SaveChanges();
        
        }
        public void RemoveItemFromCart(Movie movie) 
        {
            var ShopItem = context.shoppingCartItems.FirstOrDefault(i => i.Movie.Id == movie.Id && i.ShoppingCardId == ShoppingCartId);

            if (ShopItem != null)
            {
                if (ShopItem.Amount > 1) 
                {
                    ShopItem.Amount--;
                }
                else 
                {
                    context.shoppingCartItems.Remove(ShopItem);
                }
            }
            context.SaveChanges();
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = context.shoppingCartItems.Where(i => i.ShoppingCardId == ShoppingCartId)
                .Include(n => n.Movie).ToList());
        }
        public double GetShoppingCartTotal()
        {
            var total = context.shoppingCartItems.Where(i => i.ShoppingCardId == ShoppingCartId).Select(s => s.Movie.Price * s.Amount).Sum();
            return total;
        }


    }
}
