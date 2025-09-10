using AutoMapper;
using Microsoft.Extensions.Configuration;
using Talabat.Core.Application.Abstraction.Common.Contracts.Infrastructure;
using Talabat.Core.Domain.Contracts.Infrastructure;
using Talabat.Core.Domain.Entites.Basket;
using Talabat.Shared.DTOs.Basket;
using Talabat.Shared.Exceptions;

namespace Talabat.Core.Application.Services.Basket
{
    internal class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public BasketService(
            IBasketRepository basketRepository ,
            IMapper mapper,
            IConfiguration configuration
            )
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
            _configuration = configuration;
        }


        public async Task<CustomerBasketDto?> GetCustomerBasketAsync(string basketId)
        {
            var basket = await _basketRepository.GetAsync(basketId);
            
            if(basketId is null)
                throw new NotFoundException(nameof(CustomerBasket),basketId!);   
            
            var basketToReturn = _mapper.Map<CustomerBasketDto>(basket);
            return basketToReturn;
        }

        public async Task<CustomerBasketDto?> UpdateCustomerBasketAsync(CustomerBasketDto basketDto)
        {
            var basket = _mapper.Map<CustomerBasket>(basketDto);
            var timeToLiveFromAppSettings = TimeSpan.FromDays(double.Parse(_configuration.GetSection("RedisSettings")["TimeToLiveInDays"]!));
            var updatedBasket = await _basketRepository.UpdateAsync(basket , timeToLiveFromAppSettings);
            if (updatedBasket == null)
                throw new BadRequestException("can't update, there is a problem with this basket.");
            return basketDto;
        }

        public async Task DeleteCustomerBasketAsync(string basketId)
        {
            var deleted = await _basketRepository.DeleteAsync(basketId);

            if (!deleted)
                throw new BadRequestException("Cannot Delete This Basket.");
        }

    }
}
