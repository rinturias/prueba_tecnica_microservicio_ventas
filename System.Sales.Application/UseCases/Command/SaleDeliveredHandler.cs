using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Sales.Application.Dto;
using System.Sales.Domain.Factories;
using System.Sales.Domain.Interfaces;
using System.Sales.Domain.Models.sale;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace System.Sales.Application.UseCases.Command
{
    public class SaleDeliveredHandler :IRequestHandler<SalesDeliveredCommand, ResulService> {

        public readonly ISaleFactory _ISaleFactory;
        public readonly IUnitOfWork _unitOfWork;
        public readonly ISaleRepository _ISaleRepository;


     
        public SaleDeliveredHandler(ISaleFactory iSaleFactory, IUnitOfWork unitOfWork, ISaleRepository iSaleRepository)
        {

            _ISaleFactory = iSaleFactory;
            _unitOfWork = unitOfWork;
            _ISaleRepository = iSaleRepository;
        }



        public async Task<ResulService> Handle(SalesDeliveredCommand request, CancellationToken cancellationToken)
        {
            try
            {


                Sale objSale = await _ISaleRepository.FindByIdAsync(request.DetailDelivered.saleId);

                if (objSale != null)
                {

                    objSale.consolidateSaleDelivered(objSale.Id, request.DetailDelivered.status);
                    await _ISaleRepository.UpdateAsync(objSale);
                }
                else
                {
                    return new ResulService { codError = "COD403", messaje = "No existe la venta" };
                }


                await _unitOfWork.Commit();

                return new ResulService { data = objSale.Id, messaje = "Operacion exitosa" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
            return new ResulService { success = false, codError = "COD501", messaje = "ERROR al  cerrar entrega de venta" };


        }
    }
}