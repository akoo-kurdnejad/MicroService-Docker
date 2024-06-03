using Dapper;
using Discount.Api.Entities;
using Npgsql;

namespace Discount.Api.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        #region Constructor
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion Constructor

        public async Task<Coupon> GetByProductId(string productId)
        {
            using var connection = new NpgsqlConnection(GetConnectionString());
            var coupon = await connection
                .QueryFirstOrDefaultAsync<Coupon>(DapperQuery.GetDiscountQuery(), new
                {
                    ProductId = productId
                });

            if (coupon is null)
                throw new Exception("Record Not Found");

            return coupon;
        }

        public async Task<bool> Create(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(GetConnectionString());
            var result = await connection.ExecuteAsync(DapperQuery.CreateQuery(), coupon);
            return result > 0 ? true : false;
        }

        public async Task<bool> Update(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(GetConnectionString());
            var result = await connection.ExecuteAsync(DapperQuery.UpdateQuery(), coupon);
            return result > 0 ? true : false;
        }

        public async Task<bool> Delete(string productId)
        {
            using var connection = new NpgsqlConnection(GetConnectionString());
            var result = await connection.ExecuteAsync(DapperQuery.DeleteQuery(), new { ProductId = productId });
            return result > 0 ? true : false;
        }

        private string GetConnectionString()
            => _configuration.GetValue<string>("DatabaseSettings:ConnectionString");
    }
}
