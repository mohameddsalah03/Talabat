using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Talabat.Core.Application.Abstraction.Services;
using Talabat.Core.Application.Abstraction.Services.Auth;
using Talabat.Core.Application.Abstraction.Services.Basket;
using Talabat.Core.Application.Abstraction.Services.Orders;
using Talabat.Core.Application.Abstraction.Services.Products;
using Talabat.Core.Application.Services.Products;
using Talabat.Core.Domain.Contracts;

namespace Talabat.Core.Application.Services
{
    internal class ServiceManager : IServiceManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IBasketService> _basketService;
        private readonly IServiceProvider _serviceProvider; // For Basket Service To Generate other DI for it
        private readonly Lazy<IAuthService> _authService;
        private readonly Lazy<IOrderService> _orderService;



        public ServiceManager(
            IUnitOfWork unitOfWork ,
            IMapper mapper ,
            IConfiguration configuration,
            IServiceProvider serviceProvider
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
            _productService = new Lazy<IProductService>(() => new ProductService(_unitOfWork, _mapper));
            _basketService = new Lazy<IBasketService>(() => _serviceProvider.GetRequiredService<IBasketService>());
            _authService = new Lazy<IAuthService>(() => _serviceProvider.GetRequiredService<IAuthService>());
            _orderService = new Lazy<IOrderService>(() => _serviceProvider.GetRequiredService<IOrderService>());

        }

        public IProductService ProductService => _productService.Value;
        public IBasketService BasketService => _basketService.Value;

        public IAuthService AuthService => _authService.Value;

        public IOrderService OrderService => _orderService.Value;
    }
}
