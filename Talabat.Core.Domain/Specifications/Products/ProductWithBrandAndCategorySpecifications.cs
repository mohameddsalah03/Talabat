using Talabat.Core.Domain.Entites.Products;

namespace Talabat.Core.Domain.Specifications.Products
{
    public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product , int>
    {
        // The Object Created Via this ctor for building the query for GetAllProducts
        public ProductWithBrandAndCategorySpecifications(string? sort, int? brandId, int? categoryId , int pageSize , int PageIndex) 
            : base(
                  // This For Filtration Of BrandId And CategoryId
                  p => 
                        (!brandId.HasValue || p.BrandId == brandId.Value)
                            &&
                        (!categoryId.HasValue || p.CategoryId == categoryId.Value)
                  )
        {
            AddIncludes();

            //OrderBy
            switch(sort)
            {
                case "nameDesc":                //default but desc
                    AddOrderByDesc(P => P.Name);
                    break;

                case "priceAsc":
                    AddOrderBy(P => P.Price);
                    break;

                case "priceDesc":
                    AddOrderByDesc(P => P.Price);
                    break;
                
                default:
                    AddOrderBy(P => P.Name); 
                    break;
            }

            // Pagination
            AddPagination(pageSize * (PageIndex - 1), pageSize);

        }

        
        // The Object Created Via this ctor for building the query for GetProduct
        public ProductWithBrandAndCategorySpecifications(int id)
            : base(id)
        {
            AddIncludes();
        }


        #region Methods overrides from BaseSpecification

        private protected override void AddIncludes()
        {
            base.AddIncludes();
            Includes.Add(P => P.Brand!);
            Includes.Add(P => P.Category!);
        }

        
        
        #endregion

    }
}
