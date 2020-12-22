using Cristutiu_Andreea_Proiect.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cristutiu_Andreea_Proiect.Models
{
    public class OrderProductsPageModel : PageModel
    {
        public List<AssignedProductData> AssignedProductDataList;

        public void PopulateAssignedProductData(Cristutiu_Andreea_ProiectContext context, Order order)
        {
            var allProducts = context.Product;
            var orderProducts = new HashSet<int>(order.OrderProducts.Select(c => c.OrderID));
            AssignedProductDataList = new List<AssignedProductData>();
            foreach (var prod in allProducts)
            {
                AssignedProductDataList.Add(new AssignedProductData
                {
                    ProductID = prod.ID,
                    Name = prod.ProductName,
                    Price = prod.ProductPrice,
                    Assigned = orderProducts.Contains(prod.ID)
                });
            }
        }

        public void UpdateOrderProducts(Cristutiu_Andreea_ProiectContext context, string[] selectedProducts, Order orderToUpdate)
        {
            if (selectedProducts == null)
            {
                orderToUpdate.OrderProducts = new List<OrderProduct>();
                return;
            }
           

            var selectedProductsHS = new HashSet<string>(selectedProducts);
            var orderProducts = new HashSet<int>(orderToUpdate.OrderProducts.Select(c => c.Product.ID));
            var total = orderToUpdate.OrderPrice;
            foreach (var prod in context.Product)
            {
                if (selectedProductsHS.Contains(prod.ID.ToString()))
                {
                    if (!orderProducts.Contains(prod.ID))
                    {
                        orderToUpdate.OrderProducts.Add(new OrderProduct
                        {
                            OrderID = orderToUpdate.ID,
                            ProductID = prod.ID
                        });
                        total += prod.ProductPrice;
                    }
                }
                else
                {
                    if (orderProducts.Contains(prod.ID))
                    {
                        OrderProduct productToRemove = orderToUpdate.OrderProducts.SingleOrDefault(i => i.ProductID == prod.ID);
                        context.Remove(productToRemove);
                        total -= prod.ProductPrice;
                    }
                }
            }
            orderToUpdate.OrderPrice = total;
        }
    }
}
