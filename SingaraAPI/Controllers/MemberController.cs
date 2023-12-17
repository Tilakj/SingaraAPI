using SingaraAPI.App_Data;
using System.Web.Http;

namespace SingaraAPI.Controllers
{
    public class MemberController : ApiController
    {
        private readonly IDataAccess dataAccess;

        public MemberController(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        [HttpGet]
        public IHttpActionResult GetMembers()
        {
            string query = "select * from singara1_dev.t_member";
            var result = dataAccess.ExecuteQuery(query);
            return Ok(result);
        }
    }
}
