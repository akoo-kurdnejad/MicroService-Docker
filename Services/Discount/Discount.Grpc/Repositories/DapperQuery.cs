

namespace Discount.Grpc.Repositories
{
    public class DapperQuery
    {
        public static string GetDiscountQuery()
            => "SELECT * FROM Coupon WHERE ProductId = @ProductId";

        public static string CreateQuery()
            => "INSERT INTO Coupon (ProductId, Description, Amount) VALUES (@ProductId, @Description, @Amount)";

        public static string UpdateQuery()
            => "UPDATE Coupon SET ProductId = @ProductId , Description = @Description, Amount = @Amount WHERE ID=@Id";

        public static string DeleteQuery()
            => "DELETE FROM Coupon WHERE ProductId = @ProductId";
    }
}
