using DemoProject.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Server.Controllers
{
    [Route("[controller]")]
    public class VehicleController : Controller
    {
        private readonly ILogger<VehicleController> logger;
        private DbContextOptionsBuilder<VTS_DBContext> m_optionsBuilder;
        private VTS_DBContext m_context;
        public VehicleController(ILogger<VehicleController> logger)
        {
            this.logger = logger;
            m_optionsBuilder = new DbContextOptionsBuilder<VTS_DBContext>();
            m_optionsBuilder.UseSqlServer(@"Server=ASIA17844\LOCALHOST;Database=VTS_DBN;Trusted_Connection=True;");
            m_context = new VTS_DBContext(m_optionsBuilder.Options);
        }
        [HttpGet]
        public async Task<IEnumerable<Vehicle>> GetAllVehicle(string searchText)
        {
            IEnumerable<Vehicle> list = m_context.Vehicle.ToList();
            return list.ToArray();
        }

        /// <summary>
        /// It will filter out outpu data with comparing searchText with Organization name of Vehicle
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        [HttpGet("/api/Vehicle/GetVehicle/{searchText}")]
        public async Task<IEnumerable<Vehicle>> GetVehicle(string searchText)
        {
            string sql = "SELECT * FROM Vehicle WHERE OrganisationName like" +
            "'%"+searchText+"%' ORDER BY OrganisationName" +
            " OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY; ";

            IEnumerable<Vehicle> list = m_context.Vehicle.FromSqlRaw(sql).ToList();
            return  list.ToArray();
        }

    }
}
