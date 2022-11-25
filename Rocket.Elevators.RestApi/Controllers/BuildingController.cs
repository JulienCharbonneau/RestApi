using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket.Elevators.RestApi.Infra.Context;
using Rocket.Elevators.RestApi.Model;
using System.Xml.Linq;

namespace Rocket.Elevators.RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BuildingController : ControllerBase
    {
        private readonly FluentMySqlContext _mySqlContext;
        //private readonly FluentPostgresContext _postgresSqlContext;

        public BuildingController(FluentMySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
           
        }

        [HttpGet]
        public IEnumerable<Building> GetAllBuildingsContainsBattery()
        {
            return _mySqlContext.Buildings.Where(b => b.Batteries.Count > 0);
        }

        [HttpGet]
        public Building GetBuildingById(long id)
        {
            return _mySqlContext.Buildings.Single(i => i.Id.Equals(id));
        }

        [HttpGet]
        public IEnumerable<Building> GetAllBuildingsIntervention()
        {
            //return _mySqlContext.Buildings.Where(building => building.Batteries.Any(bat => bat.Status.Equals("intervention"))).ToList();
            return _mySqlContext.Buildings.Where(building => building.Batteries.Any(bat => bat.Status.Equals("offline") ||
                                                building.Batteries.Any(bat => bat.Columns.Any(col => col.Status.Equals("offline") ||
                                                building.Batteries.Any(bat => bat.Columns.Any(col => col.Elevators.Any(e => e.Status.Equals("offline"))))))))
                    .Select(b => new Building 
                    {
                        Id = b.Id,
                        AdminEmail = b.AdminEmail,
                        AdminFullName = b.AdminFullName,
                        AdminPhoneNumber = b.AdminPhoneNumber,
                        Batteries = b.Batteries.Where(bat => bat.Status.Equals("offline")).ToList(),
                        BuildingAddress = b.BuildingAddress,
                        CustomerId = b.CustomerId,
                        TechnicalContactEmail = b.TechnicalContactEmail,
                        TechnicalContactFullName = b.TechnicalContactFullName,
                        TechnicalContactPhoneNumber = b.TechnicalContactPhoneNumber,
                    });

            
        }
    }
}
