using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Estudos.Blazor.Web.Shared.Responses
{
    public class ResquestResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiError ParsedErrorOrDefault()
        {
            try
            {
                return JsonConvert.DeserializeObject<ApiError>(Message);
            }
            catch
            {
                return new ApiError { Id = "42", Title = Message };
            }
        }
    }
}
