using Mango.Services.CouponAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using AutoMapper;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _responseDto;
        private IMapper _mapper;

        public CouponAPIController(AppDbContext db, IMapper mapper)

        {
            _mapper = mapper;
            _db = db;
            _responseDto = new ResponseDto();
        }
        [HttpGet]
        public ResponseDto get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();


                _responseDto.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);

            }
            catch (Exception ex)
            {
                _responseDto.isSuccess = false;
                _responseDto.Message = ex.Message;

            }
            return _responseDto;
        }
        [HttpGet]
        [Route("{id}")]
        public ResponseDto get(string id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(u => u.CouponId == id);

                _responseDto.Result = _mapper.Map<CouponDto>(obj);

            }
            catch (Exception ex)
            {
                _responseDto.isSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
        [HttpGet]
        [Route("getByCode/{code}")]
        public ResponseDto getByCode(string code)
        {
            try
            {
                Coupon obj = _db.Coupons.FirstOrDefault(u => u.CouponCode.ToLower() == code.ToLower());
                if (obj == null)
                {
                    _responseDto.isSuccess = false;
                }

                _responseDto.Result = _mapper.Map<CouponDto>(obj);



            }
            catch (Exception ex)
            {
                _responseDto.isSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
        [HttpPost]

        public ResponseDto post([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Add(obj);
                _db.SaveChanges();

                _responseDto.Result = _mapper.Map<CouponDto>(obj);

            }
            catch (Exception ex)
            {
                _responseDto.isSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
        [HttpPut]

        public ResponseDto put([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Update(obj);
                _db.SaveChanges();

                _responseDto.Result = _mapper.Map<CouponDto>(obj);

            }
            catch (Exception ex)
            {
                _responseDto.isSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
        [HttpDelete]
        [Route("{id}")]
        public ResponseDto delete(string id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(u=> u.CouponId == id);
                _db.Coupons.Remove(obj);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                _responseDto.isSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
    }
}
