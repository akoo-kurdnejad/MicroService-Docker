using Discount.Grpc.Protos;

namespace Basket.Api.Services
{
    public class DiscountGrpcService : IDiscountGrpcService
    {
        #region Constructor
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoService;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoService)
        {
            _discountProtoService = discountProtoService;
        }
        #endregion Constructor

        //***************** GetDiscount *******************
        public async Task<CouponModel> GetDiscount(string productId)
        {
            var discountRequest = new GetDiscountRequest
            {
                ProductId = productId
            };

            var result = await _discountProtoService.GetDiscountAsync(discountRequest); 
            return result;
        }
    }
}
