using System.Data;

namespace Quickpack.Application.Common.Interface
{
    public interface IDataBase
    {
        IDbConnection GetConnection();
    }
}
