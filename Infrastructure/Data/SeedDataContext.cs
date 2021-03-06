using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Infrastructure.Data
{
    public class SeedDataContext
    {
        public static async Task SeedDataAsync(SkinetContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                // var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                if (!context.ProductTypes.Any())
                {
                    var productsTypeData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var productTypes = JsonConvert.DeserializeObject<List<ProductType>>(productsTypeData);

                    foreach (var type in productTypes)
                    {
                        context.ProductTypes.Add(type);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.ProductBrands.Any())
                {
                    var productsBrandData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var productBrands = JsonConvert.DeserializeObject<List<ProductBrand>>(productsBrandData);

                    foreach (var brand in productBrands)
                    {
                        context.ProductBrands.Add(brand);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonConvert.DeserializeObject<List<Product>>(productsData);

                    foreach (var product in products)
                    {
                        context.Products.Add(product);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.DeliveryMethods.Any())
                {
                    var deliveryMethodData = File.ReadAllText("../Infrastructure/Data/SeedData/delivery.json");
                    var deliveryMethods = JsonConvert.DeserializeObject<List<DeliveryMethod>>(deliveryMethodData);

                    foreach (var deliveryMethod in deliveryMethods)
                    {
                        context.DeliveryMethods.Add(deliveryMethod);
                    }
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<SeedDataContext>();
                logger.LogError("An error ocured when seeding data", ex);
            }
        }
    }
}