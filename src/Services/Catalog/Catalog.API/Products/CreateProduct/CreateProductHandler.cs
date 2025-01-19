

namespace Catalog.API.Products.CreateProduct
   

{

    public record CreateProductCommand(string Name, List<string> Category, string Description, String Imagefile, decimal Price) 
        : ICommand<CreateProductResult> ;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler(IDocumentSession session)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //Business logic to create product
            var product = new Product
            {
                Name = command.Name,
                Catagory = command.Category,
                ImageFile = command.Imagefile,
                Price = command.Price,
                Description = command.Description
            };

            //save to DB
            session.Store(product);
            await session.SaveChangesAsync();

            return new CreateProductResult(product.Id);

        }
    }
}
