
using ecommerce.Core.DTO;

namespace ecommerce.Core.ServiceContract
{
    /// <summary>
    /// Contract for user service that contains
    /// use cases for users
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Method to handle user login use case and return an AuthenticationResponse object
        /// that contains status of Login
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<AuthenticationResponse> Login(LoginRequest obj);


        /// <summary>
        /// Method to handle user registration use case and return an object of 
        /// AuthenticationResponse type that represents status of user registration.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<AuthenticationResponse> Register(RegisterRequest obj);
    }
}
