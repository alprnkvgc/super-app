namespace AspNETWebApi.Features.Products.Queries.GetById
{
    public class GetProductByIdResponse
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Quantity { get; set; }
    }
}
