using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
                return;

            // Marten UPSERT will carter for existing records
            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync();
        }

        private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
        {
            new Product()
            {
                Id = new Guid("28607f17-662f-4736-8644-b7bea98f855a"),
                Name = "IPhone X",
                Description = "This phone is the company's biggest change to its",
                ImageFile = "product-1.png",
                Price = 950.00M,
                Category = new List<string> { "Smart Phone" }
            },
            new Product()
            {
                Id = new Guid("14634438-fe6b-47c1-bb52-5bbe5878a0ed"),
                Name = "Samsung 10",
                Description = "This phone is the company's biggest change to its",
                ImageFile = "product-2.png",
                Price = 840.00M,
                Category = new List<string> { "Smart Phone" }
            },
            new Product()
            {
                Id = new Guid("43bb382c-5fdd-43b2-8646-c6bf4fd5a8e0"),
                Name = "Huawei Plus",
                Description = "This phone is the company's biggest change to its",
                ImageFile = "product-3.png",
                Price = 650.00M,
                Category = new List<string> { "White Appliances" }
            },
            new Product()
            {
                Id = new Guid("1a3d7c69-b6cf-4272-83aa-b095a45bb258"),
                Name = "Xiomi Mi 9",
                Description = "This phone is the company's biggest change to its",
                ImageFile = "product-4.png",
                Price = 470.00M,
                Category = new List<string> { "White Appliances" }
            },
            new Product()
            {
                Id = new Guid("a087ad48-8b5c-418e-9d4e-ba2a7a2fc7ca"),
                Name = "HTC U11+ Plus",
                Description = "This phone is the company's biggest change to its",
                ImageFile = "product-5.png",
                Price = 380.00M,
                Category = new List<string> { "Smart Phone" }
            },
            new Product()
            {
                Id = new Guid("2037e744-823c-47ce-b165-f407d552394d"),
                Name = "LG G7 ThinQ",
                Description = "This phone is the company's biggest change to its",
                ImageFile = "product-6.png",
                Price = 240.00M,
                Category = new List<string> { "Home Kitchen" }
            },
            new Product()
            {
                Id = new Guid("a95c5d00-c75a-42f0-9809-f1cb63a8543a"),
                Name = "Panasonic Lumix",
                Description = "This phone is the company's biggest change to its",
                ImageFile = "product-7.png",
                Price = 240.00M,
                Category = new List<string> { "Camera" }
            }
        };
    }
}
