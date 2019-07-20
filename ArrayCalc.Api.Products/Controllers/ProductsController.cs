using System.Web.Http;
using ArrayCalc.Api.Products.Services;

namespace ArrayCalc.Api.Products.Controllers
{
    [RoutePrefix("api/arraycalc")]
    public class ArrayCalcController : ApiController
    {
        public IProductService _productService;
        public ArrayCalcController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// reverse the given array input
        /// </summary>
        /// <param name="productIds"></param>
        /// <returns>IHttpActionResult</returns>
        [Route("reverse")]
        public IHttpActionResult Get([FromUri] int[] productIds)
        {
            //Check whether the request is a valid one
            if (productIds != null && productIds.Length > 0)
            {
                _productService = new ProductService();
                var reverseProdIds = _productService.ReverseArrayItem(productIds);
                return Ok(reverseProdIds);
            }

            return BadRequest("Invalid Request");
        }

        /// <summary>
        /// delete at postion from given array input
        /// </summary>
        /// <param name="position"></param>
        /// <param name="productIds"></param>
        /// <returns>IHttpActionResult</returns>
        [Route("deletepart")]
        public IHttpActionResult Get([FromUri] int position, [FromUri]int[] productIds)
        {
            //Check whether the request is a valid one
            if (productIds != null && productIds.Length > 0 && position < productIds.Length)
            {
                var updateProdIdArray = _productService.RemoveArrayItemAt(position, productIds);
                return Ok(updateProdIdArray);
            }

            return BadRequest("Invalid Request");
        }
    }
}