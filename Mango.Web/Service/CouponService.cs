using Mango.Web.Models;
using Mango.Web.Models.Mango.Services.CouponAPI.Models.Dto;
using Mango.Web.Service.IService;
using  Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService baseService;

        public CouponService(IBaseService baseService)
        {
            this.baseService = baseService;
        }

        public async Task<ResponseDto?> CreateCouponAsync(CouponDto cupon)
        {
            return await baseService.SendAsysnc(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Data = cupon,
                Url = SD.CouponAPIBase + "/api/coupon"
            });
        }

        public async  Task<ResponseDto?> DeleteCouponsAsync(string id)
        {
            return await baseService.SendAsysnc(new RequestDto
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CouponAPIBase + "/api/coupon/"+id
            });
        }

        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
            return await baseService.SendAsysnc(new RequestDto
            {
                ApiType = SD.ApiType.GET,
               
                Url = SD.CouponAPIBase + "/api/coupon"
            });
        }

        public async Task<ResponseDto?> getCouponAsync(string couponCode)
        {
            return await baseService.SendAsysnc(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/GetByCode/" + couponCode
            }); ;
        }

        public async  Task<ResponseDto?> GetCouponsByIdAsync(string id)
        {
            return await baseService.SendAsysnc(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon/"+id
            });
        }

        public async Task<ResponseDto?> UpdateCouponsAsync(CouponDto coupon)
        {
            return await baseService.SendAsysnc(new RequestDto
            {
                ApiType = SD.ApiType.PUT,
                Data = coupon,
                Url = SD.CouponAPIBase + "/api/coupon"
            });
        }
    }
}
