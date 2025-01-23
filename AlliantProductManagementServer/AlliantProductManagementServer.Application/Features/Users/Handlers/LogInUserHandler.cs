using AlliantProductManagementServer.Application.Dtos.Users;
using AlliantProductManagementServer.Application.Security;
using AlliantProductManagementServer.Domain.Entities.Users;
using AlliantProductManagementServer.Domain.Exceptions;
using AlliantProductManagementServer.Domain.Repositories.Users;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Features.Users.Handlers
{
    public class LogInUserCommand : IRequest<UserDto>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
    public class LoginUserHandler(IUserRepository userRepository, IMapper mapper, IAuthHandler authHandler) : IRequestHandler<LogInUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IAuthHandler _authHandler = authHandler;
        private readonly IMapper _mapper = mapper;

        public async Task<UserDto> Handle(LogInUserCommand request, CancellationToken cancellationToken)
        {
            var encryptedPassword = _authHandler.Encrypt(request.Password);

            var user = await _userRepository.GetUserByEmail(request.Email);

            if (user is null)
            {
                throw new DomainException("Invalid credentials", (int)HttpStatusCode.BadRequest);
            }

            var passwordIsValid = request.Password == _authHandler.Decrypt(user.Password);
            if (!passwordIsValid)
            {
                throw new DomainException("Invalid credentials", (int)HttpStatusCode.BadRequest);
            }

            var response = _mapper.Map<User, UserDto>(user);

            response.Token = _authHandler.GenerateJwtToken(user);

            return response;
        }
    }

}
