using SingaraAPI.App_Data;
using System.Web.Http;

namespace SingaraAPI.Controllers
{
    public class CommitteeController : ApiController
    {
        private readonly IDataAccess dataAccess;

        public CommitteeController(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        [HttpGet]
        public IHttpActionResult GetCommittees()
        {
            string query = "select * from singara1_dev.t_committee";
            var result = dataAccess.ExecuteQuery(query);
            return Ok(result);
        }
    }
}
