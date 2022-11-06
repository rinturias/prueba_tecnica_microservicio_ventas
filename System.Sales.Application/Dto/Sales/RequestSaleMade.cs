using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Sales.Application.Dto.Sales
{
    public class RequestSaleMade
    {

        public string note { get; set; }
        public Guid clienteId { get; set; }
        public Guid userId { get; set; }
        public decimal amountTotal { get; set; }
        public decimal amountNominal { get; set; }
        public decimal discount { get; set; }

        public List<DetailsSaleDTO> listDetailsSaleDto { get; set; }

    }
}
