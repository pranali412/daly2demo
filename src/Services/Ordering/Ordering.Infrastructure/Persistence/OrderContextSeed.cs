using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {
                   
                    UserName = "swn",
                    FirstName = "Mehmet",
                    LastName = "Ozkaya",
                    EmailAddress = "ezozkme@gmail.com",
                    AddressLine = "Bahcelievler",
                    Country = "Turkey",
                    TotalPrice = 350,
                    State = "MH",
                    ZipCode = "223344",
                    CardName = "abc",
                    CardNumber = "12345677",
                    Expiration ="11/23",
                    CVV="234",
                    PaymentMethod = 1,
                    LastModifiedDate = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Pranali",
                    LastModifiedBy = "Pranali"

                   }
            };
        }
    }
}