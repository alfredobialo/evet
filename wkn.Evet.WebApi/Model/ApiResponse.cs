using System;
using Newtonsoft.Json;

namespace wkn.Evet.WebApi.Model
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }

        public ApiResponse()
        {
            
        }
        [JsonProperty(Order =-5, NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        [JsonProperty( NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Exception ServerFault { get; set; }
        public bool HasFault => ServerFault != null;
        [JsonProperty( NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public dynamic RootHref { get; set; }
    }
    
}