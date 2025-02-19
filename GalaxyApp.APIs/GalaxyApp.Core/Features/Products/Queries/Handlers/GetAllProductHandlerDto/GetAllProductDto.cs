namespace GalaxyApp.Core.Features.Products.Queries.Handlers.GetAllProductHandlerDto
{
    public class GetAllProductDto
    {
        public GetAllProductDto(string name, string? imageUrl, int evaluation, int quantity)
        {
            Name = name;
            ImageUrl = imageUrl;
            Evaluation = evaluation;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int Evaluation { get; set; }
        public int Quantity { get; set; }

    }
}
