using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Sales.Application.Dto;
using System.Sales.Application.Dto.Sales;
using System.Text;
using System.Threading.Tasks;

namespace System.Sales.Application.UseCases.Command
{
    public class SaleMadeCommand : IRequest<ResulService>
    {
        public RequestSaleMade Detail { get; set; }
        private SaleMadeCommand() { }

        public SaleMadeCommand(RequestSaleMade detail)
        {
            Detail = detail;
        }

      

    }
}
