using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Sales.Application.Dto;
using System.Sales.Domain.Factories;
using System.Sales.Domain.Interfaces;
using System.Sales.Domain.Models.sale;
using System.Text;
using System.Threading.Tasks;

namespace System.Sales.Application.UseCases.Command
{
    public class SaleMadeHandler:IRequestHandler<SaleMadeCommand, ResulService>
    {
        const int active_registry= 0;
        readonly decimal PORCENTAGE_IVA;
        public readonly ISaleFactory _ISaleFactory;
        public readonly IUnitOfWork _unitOfWork;
        public readonly ISaleRepository _ISaleRepository;
        private readonly IConfiguration _configuration;


        public SaleMadeHandler(ISaleFactory iSaleFactory, IUnitOfWork unitOfWork, ISaleRepository iSaleRepository, IConfiguration configuration)
        {
          
            _ISaleFactory = iSaleFactory;
            _unitOfWork = unitOfWork;
            _ISaleRepository = iSaleRepository;
            _configuration = configuration;
            PORCENTAGE_IVA = decimal.Parse(configuration["KEY:KEY_PORCENTAGE_VALUE_IVA"]);
        }

        public async Task<ResulService> Handle(SaleMadeCommand request, CancellationToken cancellationToken)
        {

            try
            {

                Sale objSale = _ISaleFactory.Create(active_registry,request.Detail.note,request.Detail.clienteId,request.Detail.userId,request.Detail.discount, PORCENTAGE_IVA);

                foreach (var item in request.Detail.listDetailsSaleDto)
                {
                    objSale.agregarItem(item.productId, objSale.Id, item.price,item.quantity);
                }

                 objSale.consolidateSale();

                 await _ISaleRepository.CreateAsync(objSale);

                await _unitOfWork.Commit();

                return new ResulService { data = objSale.Id, messaje = "se realizo una venta" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ResulService { success = false, error = ex.Message, codError = "COD501", messaje = "ERROR crear la venta" };

            }


        }


    }
}
