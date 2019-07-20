using System;
using System.Collections.Generic;
namespace ArrayCalc.Api.Products.Services
{
    public class ProductService : IProductService
    {
        /// <summary>
        /// This method is used to Reverse the contents of a given array using pure array manipulation
        /// </summary>
        /// <param name="productsIds"></param>
        /// <returns>reversed productIds</returns>
        public IList<int> ReverseArrayItem(int[] productsIds)
        {
            for (int i = 0; i < productsIds.Length / 2; i++)
            {
                int tempArray = productsIds[i];
                productsIds[i] = productsIds[productsIds.Length - i - 1];
                productsIds[productsIds.Length - i - 1] = tempArray;
            }
            return productsIds;

        }
        /// <summary>
        /// This method is used to Remove the array Item using pure array manipulation
        /// </summary>
        /// <param name="postionToRemove"></param>
        /// <param name="productIds"></param>
        /// <returns>removed productIds</returns>
        public IList<int> RemoveArrayItemAt(int postionToRemove, int[] productIds)
        {
            for (int i = postionToRemove - 1; i < productIds.Length - 1; i++)
            {
                productIds[i] = productIds[i + 1];
            }
            Array.Resize<int>(ref productIds, productIds.Length - 1);
            return productIds;
        }

    }
}