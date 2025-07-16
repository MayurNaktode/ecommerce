using ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Core.RepositoryContract
{
    /// <summary>
    /// Contract to be implemented by UserRepository
    /// that contains data access logic of user data store.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Method to add a user to the data store 
        /// and return the added user details.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<ApplicationUser?> AddUser(ApplicationUser user);

        /// <summary>
        /// Method to retrive existing user by their email and password.
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>

        Task<ApplicationUser?> GetUserByEmailAndPassword(string? Email, string? Password);
    }
}
