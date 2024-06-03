using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;
using Discount.Grpc.Repositories;
using Grpc.Core;

namespace Discount.Grpc.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        #region Constructor
        private readonly IDiscountRepository _discountRepository;
        private readonly ILogger<DiscountService> _logger;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository discountRepository,
                               ILogger<DiscountService> logger,
                               IMapper mapper)
        {
            _discountRepository = discountRepository;
            _logger = logger;
            _mapper = mapper;
        }
        #endregion Constructor

        //******************** GetDiscount ***********************
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon =  await _discountRepository.GetByProductId(request.ProductId);
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.NotFound, "record not found"));

            _logger.LogInformation("Discount is Retrivd for Product Id");
            return _mapper.Map<CouponModel>(coupon);
        }

        //******************** CreateDiscount ***********************
        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);
            await _discountRepository.Create(coupon);
            _logger.LogInformation($"discount is Succesfuly create for product {coupon.ProductId}");
            var couponModel = _mapper.Map<CouponModel>(coupon); 
            return couponModel;
        }

        //******************** UpdateDiscount ***********************
        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);
            await _discountRepository.Update(coupon);
            _logger.LogInformation($"discount is Succesfuly update for product {coupon.ProductId}");
            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;
        }

        //******************** DeleteDiscount ***********************
        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var deleted = await _discountRepository.Delete(request.ProductId);
            return new DeleteDiscountResponse
            {
                Success = deleted,
            };
        }
    }
}
