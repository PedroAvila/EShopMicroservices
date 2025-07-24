

namespace Ordering.Infrastructure.Data.Extensions;

public class InitialData
{
    public static IEnumerable<Customer> Customers =>
        new List<Customer>
        {
            Customer.Create(CustomerId.Of(new Guid("9a219087-1b20-4d14-ac7e-c93bef9a354e")), "mehmet", "mehmet@gmail.com"),
            Customer.Create(CustomerId.Of(new Guid("eb0ac7e0-9db1-4471-95d1-02cb84c7d926")), "john", "john@gmail.com")
        };

    public static IEnumerable<Product> Products =>
        new List<Product>
        {
            Product.Create(ProductId.Of(new Guid("179687e1-8a41-4ba7-97f9-757f3c404e0c")), "IPhone X", 500),
            Product.Create(ProductId.Of(new Guid("2f1be9a9-8d3a-455e-970c-d63fb06f4ccf")), "Samsung 10", 400),
            Product.Create(ProductId.Of(new Guid("a3fb1901-89e3-4408-b40c-9b6ad9e8f05f")), "Huawei Plus", 650),
            Product.Create(ProductId.Of(new Guid("14e2a4f1-832f-4fe4-9d9f-c4cf6af0b0c9")), "Xiaomi Mi", 450)
        };

    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("mehmet", "ozkaya", "mehmet@gmail.com", "Bahcelievler No:4", "Turkey", "Istanbul", "38050");
            var address2 = Address.Of("john", "doe", "john@gmail.com", "Broadway No:1", "England", "Nottingham", "08050");

            var payment1 = Payment.Of("mehmet", "5555555555554444", "12/28", "355", 1);
            var payment2 = Payment.Of("john", "8885555555554444", "06/30", "222", 2);

            var order1 = Order.Create(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("9a219087-1b20-4d14-ac7e-c93bef9a354e")),
                    OrderName.Of("ORD_1"),
                    shippingAddress: address1,
                    billingAddress: address1,
                    payment1);
            order1.Add(ProductId.Of(new Guid("179687e1-8a41-4ba7-97f9-757f3c404e0c")), 2, 500);
            order1.Add(ProductId.Of(new Guid("2f1be9a9-8d3a-455e-970c-d63fb06f4ccf")), 1, 400);

            var order2 = Order.Create(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("eb0ac7e0-9db1-4471-95d1-02cb84c7d926")),
                    OrderName.Of("ORD_2"),
                    shippingAddress: address2,
                    billingAddress: address2,
                    payment2);
            order2.Add(ProductId.Of(new Guid("a3fb1901-89e3-4408-b40c-9b6ad9e8f05f")), 1, 650);
            order2.Add(ProductId.Of(new Guid("14e2a4f1-832f-4fe4-9d9f-c4cf6af0b0c9")), 2, 450);

            return new List<Order> { order1, order2 };
        }
    }
}
