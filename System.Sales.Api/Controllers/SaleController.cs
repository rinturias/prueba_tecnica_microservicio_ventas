using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Sales.Application.Dto;
using System.Sales.Application.Dto.Sales;
using System.Sales.Application.UseCases.Command;

namespace System.Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
  
        private readonly IMediator _mediator;

        public SaleController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost("CreateSaleMade")]
        public async Task<IActionResult> CreateSaleMade([FromBody] SaleMadeCommand command)
        {
            try
            {

                return Ok(await _mediator.Send(command));

            }
            catch (Exception ex)
            {

                return BadRequest(new ResulService() { success = false, codError = "501", messaje = "Error en la compra", error = ex.Message });
            }
        }




        [HttpPut("SaleDelivered")]
        public async Task<IActionResult> SaleDelivered([FromBody] RequestSaleDelivered valueDto)
        {

            try
            {
                if (valueDto == null)
                {
                    return NotFound();
                }

                return Ok(await _mediator.Send( new SalesDeliveredCommand(valueDto)));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResulService() { success = false, codError = "501", messaje = "Error en la solicitud", error = ex.Message });
            }
        }
    }
}
