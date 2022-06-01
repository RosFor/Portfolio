using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class CarMasteryDbContext : IdentityDbContext<AppUser>
    {
        public CarMasteryDbContext() : base("CarDealership")
        {

        }
    }
}