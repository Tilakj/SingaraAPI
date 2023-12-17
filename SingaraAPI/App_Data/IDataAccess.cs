using System.Data;

namespace SingaraAPI.App_Data
{
    public interface IDataAccess
    {
        DataTable ExecuteQuery(string query);
    }
}