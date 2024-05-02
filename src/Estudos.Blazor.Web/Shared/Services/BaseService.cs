using Estudos.Blazor.Web.Shared.Responses;
using Newtonsoft.Json;

namespace Estudos.Blazor.Web.Shared.Services
{
    public abstract class BaseService
    {
        internal string _baseControllerURI;
        protected readonly HttpClient _httpClient;
        public BaseService
        (
            HttpClient httpClient, 
            string controllerName
        )
        {
            _httpClient = httpClient;
            _baseControllerURI = "api/" + controllerName;
        }

        public async Task<ResquestResponse<T>> GetAsync<T>(string path = "")
        {
            try
            {
                var url = _baseControllerURI + path;
                var response = await _httpClient.GetFromJsonAsync<T>(url);
                return new ResquestResponse<T>()
                {
                    Data = response,
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return HandleError<T>(ex);
            }
        }

        private ResquestResponse<T> HandleError<T>(Exception ex)
        {
            return ex switch
            {
                JsonReaderException _ => new ResquestResponse<T>()
                {
                    IsSuccess = false,
                    Message = "Falha ao deserializar objeto",
                },
                JsonSerializationException _ => new ResquestResponse<T>()
                {
                    IsSuccess = false,
                    Message = "Falha ao deserializar objeto",
                },
                _ => new ResquestResponse<T>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                }
            };
        }



    }
}
