﻿using Talabat.Core.Application.Abstraction.Services.Products;

namespace Talabat.Core.Application.Abstraction.Services
{
    public interface IServiceManager
    {
        public IProductService ProductService { get; }


    }
}
