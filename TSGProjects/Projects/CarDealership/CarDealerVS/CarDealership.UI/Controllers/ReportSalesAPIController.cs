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
    public class ReportSalesAPIController : ApiController
    {
        [Route("api/Reports/ReportSales")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchIndex(DateTime? FromDate, DateTime? ToDate, string UserSearch)
        {
            var repo = SaleRepositoryFactory.GetRepository();

            try
            {
                var parameters = new ReportSearchParameters()
                {
                    FromDate = FromDate != null ? FromDate.Value : (DateTime.Now.Date).AddYears(-222),
                    ToDate = ToDate != null ? ToDate.Value : (DateTime.Now.Date).AddYears(1),
                    UserSearch = UserSearch != null ? UserSearch : ""
                };

                var result = repo.ReportSearch(parameters);
                return Ok(result);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
