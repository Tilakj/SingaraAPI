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
        [Route("api/CurrentCommittee")]
        public IHttpActionResult GetCurrentCommittee()
        {
            string query = "SELECT name,position,image,service_year FROM singara1_dev.t_committee where is_current=1;";
            var result = dataAccess.ExecuteQuery(query);
            return Ok(result);
        }
        [HttpGet]
        [Route("api/pastCommittee")]
        public IHttpActionResult GetPastCommittee()
        {
            string query = @"SELECT service_year, name, position FROM singara1_dev.t_committee GROUP BY service_year, name, position
                            ORDER BY service_year,CASE
                                    WHEN position = 'President' THEN 1
                                    WHEN position = 'Vice President' THEN 2
                                    WHEN position = 'Treasurer' THEN 3
                                    WHEN position = 'Secretary' THEN 4
                                    WHEN position = 'Asst. Secretary' THEN 5
                                    WHEN position = 'Member' THEN 6
                                    ELSE 7
                                END";
            var result = dataAccess.ExecuteQuery(query);
            return Ok(result);
        }
    }
}
