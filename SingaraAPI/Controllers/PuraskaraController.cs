using SingaraAPI.App_Data;
using System.Web.Http;

namespace SingaraAPI.Controllers
{
    public class PuraskaraController : ApiController
    {
        private readonly IDataAccess dataAccess;

        public PuraskaraController(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        [HttpGet]
        public IHttpActionResult GetPuraskara()
        {
            string query = "SELECT year, name, category,field FROM singara1_dev.t_puraskara where is_deleted=0;";
            var result = dataAccess.ExecuteQuery(query);
            return Ok(result);
        }
     
    }
}
