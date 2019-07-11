using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace wkn.Evet.WebApi.Model.Abstraction
{
    public abstract class RestFulResource
    {
        public RestFulResource()
        {
            Id = Guid.NewGuid().ToString();
        }
        [JsonProperty(Order = -4)]
        public Dictionary<string, Link> Urls { get; set; }
        [JsonProperty(Order = -3)]
        public string Id { get; set; }
        
    }

    public class Link
    {
        public static Link From(IUrlHelper urlHelper,string method = "GET" , string rel=null)
        {
            return new Link()
            {
                Rel = rel,
                Method = method,
                //Href = urlHelper.Link()
            };
        }
        [JsonProperty(Order = -3)]
        public string Href { get; set; }
        [DefaultValue("GET")]
        [JsonProperty(Order = -1, NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Include)]
        public string Method { get; set; }
        [JsonProperty(Order = -2, NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Rel { get; set; }
        
    }

    public class RestfulResourceList<T> : List<T> where T : RestFulResource
    {
        
    }
}