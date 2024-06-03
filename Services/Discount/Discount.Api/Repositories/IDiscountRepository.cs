using Discount.Api.Entities;

namespace Discount.Api.Repositories
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetByProductId(string productId);

        Task<bool> Create(Coupon coupon);  
        
        Task<bool> Update(Coupon coupon);

        Task<bool> Delete(string productId);    
    }
}
