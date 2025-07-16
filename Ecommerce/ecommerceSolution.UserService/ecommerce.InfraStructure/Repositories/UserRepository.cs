using Dapper;
using ecommerce.Core.DTO;
using ecommerce.Core.Entities;
using ecommerce.Core.RepositoryContract;
using ecommerce.InfraStructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.InfraStructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly DapperDbContext _dapperDbContext;

        public UserRepository(DapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            // Generate a new unique user Id for the users
            user.UserID = Guid.NewGuid();

            // SQL Query

            string insert_query = "INSERT INTO public.\"Users" +
                "\"(\"UserID\",\"Email\",\"PersonName\",\"Gender\",\"Password\") VALUES(@UserID,@Email,@PersonName,@Gender,@Password)";


            int rowCountAffects  = await _dapperDbContext.DbConnection.ExecuteAsync(insert_query,user);

            if(rowCountAffects > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? Email, string? Password)
        {
            // Sql Query to select a user by Email and Password..
          string select_query = "Select * from public.\"Users\" where \"Email\" =@Email  AND \"Password\"=@Password";

            var parameters = new { Email = Email, Password = Password };
             
          ApplicationUser? user  =  await _dapperDbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(select_query, parameters);
          return user;
;
        }
    }
}
