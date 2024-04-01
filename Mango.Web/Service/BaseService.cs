using Mango.Web.Models;
using Mango.Web.Service.IService;
using static Mango.Web.Utility.SD;
using System.Net;
using Newtonsoft.Json;


namespace Mango.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDto?> SendAsysnc(RequestDto requestDto)
        {
            try
            {
                HttpClient httpClient = _httpClientFactory.CreateClient("MangoAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(requestDto.Url);

                if (requestDto.Data != null)
                {
                    message.Content = new
                        StringContent(JsonConvert.SerializeObject(requestDto.Data), System.Text.Encoding.UTF8, "application/json");

                }

                HttpResponseMessage? responseMessage = null;

                switch (requestDto.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;

                }
                responseMessage = await httpClient.SendAsync(message);

                switch (responseMessage.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { isSuccess = false, Message = "not found" };
                        break;
                    case HttpStatusCode.Forbidden:
                        return new() { isSuccess = false, Message = "forbdden error" };
                        break;
                    case HttpStatusCode.Unauthorized:
                        return new() { isSuccess = false, Message = "not authorized " };
                        break;
                    case HttpStatusCode.InternalServerError:
                        return new() { isSuccess = false, Message = "internal server error" };
                        break;
                    default:
                        var apiContent = await responseMessage.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDto;
                }
            }catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    Message = ex.Message.ToString(),
                    isSuccess = false
                };
                return dto;

            }
        }
    }
}
