using Application.Features.Products.Queries.GetAll;
using Application.Features.Products.Queries.GetById;
using Domain.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Client.Infrastructure.Managers.Product
{

    public class ProductManager : IProductManager
    {
        private readonly HttpClient _httpClient;

        public ProductManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetProductByIdResponse> GetByIdAsync(GetProductByIdQuery request)
        {
            var response = await _httpClient.GetAsync(Routes.ProductRoutes.GetById(request.Id));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                // API'den dönen veriyi uygun bir veri türüne dönüştürün.
                //var productData = JsonConvert.DeserializeObject<ProductData>(content);
                var productData = JsonSerializer.Deserialize<GetProductByIdResponse>(content);

                // API'den dönen veriyi, GetProductByIdResponse türüne dönüştürün.
                var productResponse = new GetProductByIdResponse
                {
                    Id = productData.Id,
                    Title = productData.Title,
                    Quantity = productData.Quantity,
                };

                return productResponse;
            }
            else
            {
                // API yanıtı başarısızsa, uygun bir hata işlemi yapabilirsiniz.
                throw new Exception("API yanıtı başarısız: " + response.ReasonPhrase);
            }
        }
        public async Task<List<ProductsResponse>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(Routes.ProductRoutes.GetAll);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                // API'den dönen veriyi uygun bir veri türüne dönüştürün.
                //var productDataList = JsonConvert.DeserializeObject<List<ProductData>>(content);
                var productDataList = JsonSerializer.Deserialize<List<ProductsResponse>>(content,new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    ReferenceHandler = ReferenceHandler.Preserve
                });
                // API'den dönen veriyi GetProductResponse türüne dönüştürün.
                var productResponses = productDataList.Select(productData => new ProductsResponse
                {
                    Id = productData.Id,
                    Title = productData.Title,
                    Quantity = productData.Quantity,
                }).ToList();

                return productResponses.ToList();   
            }
            else
            {
                // API yanıtı başarısızsa, uygun bir hata işlemi yapabilirsiniz.
                throw new Exception("API yanıtı başarısız: " + response.ReasonPhrase);
            }
        }

        public Task<GetProductByIdResponse> GetByIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}
