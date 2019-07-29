using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using wkn.Evet.WebApi.Formatters;

namespace wkn.Evet.WebApi.Pipeline
{
    public class MvcServicePipeline
    {
        private readonly MvcOptions _options;

        public MvcServicePipeline(MvcOptions options)
        {
            _options = options;
        }
        public  MvcServicePipeline AddCsvOutputFormatters()
        {
            _options.OutputFormatters.Add(new CsvOutputFormatter());
            return this;
        }
        public  MvcServicePipeline AddTextOutputFormatters()
        {
            _options.OutputFormatters.Add(new StringOutputFormatter());
            return this;
        }
    }
}