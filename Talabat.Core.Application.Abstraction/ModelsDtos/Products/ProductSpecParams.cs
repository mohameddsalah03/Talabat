﻿namespace Talabat.Core.Application.Abstraction.ModelsDtos.Products
{
    public class ProductSpecParams
    {
        public string? Sort { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }

        /// Pagination
        public int PageIndex { get; set; } = 1;

        private const int MaxPageSize = 10;
        private int pageSize = 5;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > MaxPageSize ? MaxPageSize: value ; }
        }


    }
}
