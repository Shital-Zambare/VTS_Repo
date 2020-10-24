using DemoProject.DatabaseContext;
using DemoProject.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Server.Controllers
{
    [Route("[controller]")]
    public class UserInfoController : ControllerBase
    {
        private readonly DatabaseConfigOptions _databaseConfigOptions;
        private readonly ILogger<UserInfoController> logger;
        private DbContextOptionsBuilder<VTS_DBContext> m_optionsBuilder;
        private VTS_DBContext m_context;
        
        public UserInfoController(ILogger<UserInfoController> logger)
        {
            this.logger = logger;
            m_optionsBuilder = new DbContextOptionsBuilder<VTS_DBContext>();
            m_optionsBuilder.UseSqlServer(@"Server=ASIA17844\LOCALHOST;Database=VTS_DBN;Trusted_Connection=True;");
            m_context = new VTS_DBContext(m_optionsBuilder.Options);
        }
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            var l=m_context.User.ToList();
            IEnumerable<User> list = m_context.User.ToList();
            return list.ToArray();
        }

        [HttpGet("/api/UserInfo/GetUsers/{id}")]
        [Produces("application/json")]
        public Task<User> GetUsersWithId(int id)
        {
            User user = m_context.User.Where(u => u.UserId == id).FirstOrDefault();
            return Task.FromResult(user);
        }


        [HttpPost]
        public void SaveUser([FromBody] User user)
        {
            m_context.AddAsync(user);
            m_context.SaveChanges();
          
        }

        [HttpPut("/api/UserInfo/GetUsers/{id}")]
        public async Task<ActionResult> UpdateUser(int id,[FromBody] User user)
        {
            m_context.Entry(user).State = EntityState.Modified;
            await m_context.SaveChangesAsync();
            return NoContent();
        }

    }
}