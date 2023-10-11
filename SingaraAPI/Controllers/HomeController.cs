using SingaraAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SingaraAPI.Controllers
{
    public class HomeController : ApiController
    {
        private static List<Item> data = new List<Item>()
        {
          new Item() { Id = 1, Value = "item1" },
          new Item() { Id = 2, Value = "item2" }
        };

        public IEnumerable<Item> Get() => data;

        public IHttpActionResult Get(int id) => id >= 0 && id < data.Count ? Ok(data.Find(c => c.Id == id)) : (IHttpActionResult)NotFound();

        [HttpPost]
        public IHttpActionResult Post([FromBody] Item item)
        {
            if (string.IsNullOrEmpty(item.Value))
                return BadRequest("Value cannot be empty.");
            int newId = data.Count > 0 ? data.Max(c => c.Id) : 0;
            data.Add(new Item()
            {
                Id = newId + 1,
                Value = item.Value
            });
            return Ok(item.Value);
        }
        [HttpPut]
        [Route("api/home/{id}")]
        public IHttpActionResult Put(int id, [FromBody] Item item)
        {
            Item obj = data.Find(c => c.Id == id);
            if (string.IsNullOrEmpty(obj?.Value))
                return NotFound();
            obj.Value = item.Value;
            return Ok();
        }
        [HttpDelete]
        [Route("api/home/{id}")]
        public IHttpActionResult Delete(int id)
        {
            Item obj = data.Find(c => c.Id == id);
            if (obj == null)
                return NotFound();
            data.Remove(obj);
            return Ok();
        }
    }
}
