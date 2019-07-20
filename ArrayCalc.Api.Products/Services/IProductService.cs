using System.Collections.Generic;
namespace ArrayCalc.Api.Products.Services
{
    public interface IProductService
    {
        IList<int> RemoveArrayItemAt(int postionToRemove, int[] productIds);
        IList<int> ReverseArrayItem(int[] productIds);
    }
}