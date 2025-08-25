using Talabat.Core.Domain.Entites.Products;

namespace Talabat.Core.Domain.Specifications.Products
{
    public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product , int>
    {
        // The Object Created Via this ctor for building the query for GetAllProducts
        public ProductWithBrandAndCategorySpecifications() 
            : base()
        {
            AddIncludes();
        }


        ///
        // The Object Created Via this ctor for building the query for GetProduct
        public ProductWithBrandAndCategorySpecifications(int id)
            : base(id)
        {
            AddIncludes();
        }


        #region Helper

        private void AddIncludes()
        {
            Includes.Add(P => P.Brand!);
            Includes.Add(P => P.Category!);
        } 

        #endregion

    }
}
