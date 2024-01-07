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
            string query = @"SELECT first_name,t_member.member_id,member_desc,valid_until FROM singara1_dev.t_member
                                join singara1_dev.t_member_type on t_member.member_type_id = t_member_type.id
                                join singara1_dev.t_membership on t_member.member_id = t_membership.member_id";
            var result = dataAccess.ExecuteQuery(query);
            return Ok(result);
        }
    }
}
