using AutoMapper;
using ecommerce.Core.DTO;
using ecommerce.Core.Entities;
using ecommerce.Core.RepositoryContract;
using ecommerce.Core.ServiceContract;


namespace ecommerce.Core.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper; 
        }

        public async Task<AuthenticationResponse> Login(LoginRequest obj)
        {
          var response =  await  _userRepository.GetUserByEmailAndPassword(obj.Email, obj.Password);
           
            if(response ==null)
            {
                return null;
            }
            else
            {
                //return new AuthenticationResponse
                //(
                //    response.UserID,
                //    response.Email,
                //    response.PersonName,
                //    response.Gender,
                //    "token",
                //    Success : true
                //);

                return _mapper.Map<AuthenticationResponse>(response)
                with
                {
                    Success = true,
                    Token = "Token"
                };
            }
        } 

        public async Task<AuthenticationResponse> Register(RegisterRequest obj)
        {
            // Create a new ApplicationUser object for RegisterRequest

            ApplicationUser user = new ApplicationUser()
            {
                PersonName = obj.PersonName,
                Password = obj.Password,
                Email = obj.Email,
                Gender = obj.Gender.ToString()
            };

            var response = await _userRepository.AddUser(user);

            if(response.UserID == null)
            {
                return null;
            }
            else
            {
                //return new AuthenticationResponse
                //(
                //    response.UserID,
                //    response.Email,
                //    response.PersonName,
                //    response.Gender,
                //    "token",
                //    Success: true
                //);

                return _mapper.Map<AuthenticationResponse>(response)
                with
                {
                    Success = true,
                    Token = "Token"
                };
            }
        }
    }
}
