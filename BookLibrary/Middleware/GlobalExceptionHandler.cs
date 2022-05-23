using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Middleware
{
    public class GlobalExceptionHandler
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
