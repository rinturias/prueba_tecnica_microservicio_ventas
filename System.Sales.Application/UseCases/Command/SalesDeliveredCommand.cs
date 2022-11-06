using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Sales.Application.Dto.Sales;
using System.Sales.Application.Dto;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace System.Sales.Application.UseCases.Command
{

    public class SalesDeliveredCommand : IRequest<ResulService>
    {
        public RequestSaleDelivered DetailDelivered { get; set; }

        public SalesDeliveredCommand(RequestSaleDelivered detail)
        {
            DetailDelivered = detail;
        }
     
        private SalesDeliveredCommand() { }
    }
}
