using Talabat.Core.Domain.Entites.Products;

namespace Talabat.Core.Domain.Specifications.Products
{
    public class ProductWithFiltrationForCountSpecifications : BaseSpecifications<Product, int>
    {

        public ProductWithFiltrationForCountSpecifications(int? brandId,int? categoryId)
            : base(
                  // This For Filtration Of BrandId And CategoryId
                  p =>
                        (!brandId.HasValue || p.BrandId == brandId.Value)
                            &&
                        (!categoryId.HasValue || p.CategoryId == categoryId.Value)
                  )
        {
            
        }

    }
}
