using Discount.Grpc.Protos;

namespace Basket.Api.Services
{
    public interface IDiscountGrpcService
    {
        Task<CouponModel> GetDiscount(string productId);
    }
}
