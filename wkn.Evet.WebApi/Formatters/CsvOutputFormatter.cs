using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using wkn.Evet.WebApi.Model;
using wkn.Evet.WebApi.Model.CrmModule;

namespace wkn.Evet.WebApi.Formatters
{
    public class CsvOutputFormatter  : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add("text/csv");
            SupportedMediaTypes.Add("application/csv");
            // Encoding
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        { string modelCsv ="csv:file";
            if (context.ObjectType == typeof(ApiResponse<IEnumerable<CustomerModel>>))
            {
                ApiResponse<IEnumerable<CustomerModel>> model =context.Object as  ApiResponse<IEnumerable<CustomerModel>>;
               
                if (model != null)
                {
                    modelCsv = "";
                    foreach (var c in model.Data)
                    {
                        Type ctype  =(c.GetType());
                        modelCsv += ctype
                            
                            .GetProperties(BindingFlags.Public).Select(
                            p => p.Name +":"+ p.GetValue(c)+",");

                    }
                }
            }
            await context.HttpContext.Response.WriteAsync($"{modelCsv}");
            
        }
        
        
    }
}