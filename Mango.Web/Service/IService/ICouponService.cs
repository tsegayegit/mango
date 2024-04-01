using Mango.Web.Models;
using Mango.Web.Models.Mango.Services.CouponAPI.Models.Dto;

namespace Mango.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto?> getCouponAsync(string couponCode);
        Task<ResponseDto?> GetAllCouponsAsync();
        Task<ResponseDto?> GetCouponsByIdAsync(string id);
        Task<ResponseDto?> CreateCouponAsync(CouponDto cupon);
        Task<ResponseDto?> UpdateCouponsAsync(CouponDto coupon);
        Task<ResponseDto?> DeleteCouponsAsync(string id);
    }
}
