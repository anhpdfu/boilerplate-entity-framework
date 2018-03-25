using Boilerplate.EFCore.Data;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;

namespace Boilerplate.EFCore.EFComplexServices
{
    public class ComplexUserServices : ComplexRepository, IComplexUserServices
    {
        public ComplexUserServices(IBoilerplateDbContext dbContext) : base(dbContext)
        {
        }

        public int UpdateUserName(int userId, string userName)
        {
            return SpUserUpdateUserName(userId, userName);
        }

        #region Stored procedures

        private int SpUserUpdateUserName(int userId, string userName)
        {
            var userIdParam = new SqlParameter
            {
                ParameterName = "@UserId",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = userId,
            };

            var userNameParam = new SqlParameter
            {
                ParameterName = "@UserName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = userName,
            };

            var procResultParam = new SqlParameter
            {
                ParameterName = "@procResult",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            ExecuteSql(TransactionalBehavior.DoNotEnsureTransaction,
                "EXEC @procResult = [dbo].[sp_User_UpdateUserName] @UserId, @UserName",
                userIdParam, userNameParam,
                procResultParam);

            return (int)procResultParam.Value;
        }

        #endregion
    }
}
