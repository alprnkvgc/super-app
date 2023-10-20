using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Infrastructure.Routes
{
    public static class ProductRoutes
    {
        public static string GetAll = "api/v1/Product";
        public static string Delete = "api/v1/products";
        public static string Save = "api/v1/products";
        public static string GetCount = "api/v1/products/count";

        public static string GetById(int id)
        {
            return $"api/v1/products/{id}";
        }
    }
}
