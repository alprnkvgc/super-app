using Application.Features.Products.Queries.GetAll;
using Client.Infrastructure.Managers.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace Client.Pages
{
    public partial class Products
    {
        [Inject] private IProductManager ProductManager { get; set; }
        private List<ProductsResponse> _productList = new();
        private ProductsResponse _product = new();

        protected override async Task OnInitializedAsync()
        {
            await GetCompaniesAsync();
        }

        private async Task GetCompaniesAsync()
        {
            var response = await ProductManager.GetAllAsync();
            if (response.Count>0)
            {
                _productList = response.ToList();
            }
        }
    }
}
