using CarDealership.Data.Factory;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.UI.Controllers
{
    public class InventoryAPIController : ApiController
    {
        [Route("api/Inventory/New")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchNew(string SearchTerm, decimal? MinPrice, decimal? MaxPrice, int? MinYear, int? MaxYear )
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            try
            {
                var parameters = new VehicleSearchParameters()
                {
                    MinPrice = MinPrice != null ? MinPrice.Value : 0M,
                    MaxPrice = MaxPrice != null ? MaxPrice.Value : 900000M,
                    MinYear = MinYear != null ? MinYear.Value : 0,
                    MaxYear = MaxYear != null ? MaxYear.Value : Int16.MaxValue,
                    SearchTerm = SearchTerm != null ? SearchTerm : ""
                };

                var result = repo.SearchNew(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/Inventory/Used")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchUsed(decimal? MaxPrice, decimal? MinPrice, int? MaxYear, int? MinYear, string SearchTerm)
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            try
            {
                var parameters = new VehicleSearchParameters()
                {
                    MinPrice = MinPrice != null ? MinPrice.Value : 0M,
                    MaxPrice = MaxPrice != null ? MaxPrice.Value : 900000M,
                    MinYear = MinYear != null ? MinYear.Value : 0,
                    MaxYear = MaxYear != null ? MaxYear.Value : Int16.MaxValue,
                    SearchTerm = SearchTerm != null ? SearchTerm : ""
                };

                var result = repo.SearchUsed(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
