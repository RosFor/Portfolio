using CarDealership.Data.Factory;
using CarDealership.Models;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.UI.Controllers
{
    public class AdminAPIController : ApiController
    {
        [Route("api/Admin/Models/{MakeID}")]
        [AcceptVerbs("GET")]
        public IEnumerable<VehicleModel> GetVehicleModel(int MakeID)
        {
            var repo = VehicleModelRepositoryFactory.GetRepository();
            var model = repo.GetAll();
            return model.Where(m => m.Make.MakeID == MakeID);
        }

        [Route("api/Admin/Index")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchIndex(decimal? MaxPrice, decimal? MinPrice, int? MaxYear, int? MinYear, string SearchTerm)
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

                var result = repo.SearchNewAndUsed(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/Admin/DeleteVehicle/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteVehicle(int id)
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            try
            {
                repo.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
