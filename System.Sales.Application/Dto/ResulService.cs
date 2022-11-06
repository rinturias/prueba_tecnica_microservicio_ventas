using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Sales.Application.Dto
{
    public class ResulService
    {
        public bool success { get; set; } = true;
        public dynamic data { get; set; }
        public string messaje { get; set; }
        public string error { get; set; } = "";
        public string codError { get; set; } = "COD200";
    }
}
