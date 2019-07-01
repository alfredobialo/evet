using System;

namespace wkn.Evet.Abstractions
{
    public class DefaultCriteria
    {
        public string Query { get; set; }
        public object Tag { get; set; }
        public bool Paginate { get; set; }
    }
}