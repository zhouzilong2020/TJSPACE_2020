using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TJSpace.DBModel;

namespace TJSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataDBContext dbContext;

        public ValuesController(DataDBContext context)
        {
            dbContext = context;

            if(dbContext.Teachers.Count()==0)
            {
                dbContext.Teachers.Add(new DBModel.Teacher { DeptName = "Sci", Name = "sb", TeacherId = "0001" });
                dbContext.SaveChanges();
            }
        }


        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            return await dbContext.Teachers.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
           
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
