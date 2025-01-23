using AlliantProductManagementServer.Application.Dtos.Customers;
using AlliantProductManagementServer.Application.Dtos.Users;
using AlliantProductManagementServer.Application.Security;
using AlliantProductManagementServer.Application.Utils;
using AlliantProductManagementServer.Domain.Entities.Customers;
using AlliantProductManagementServer.Domain.Entities.Users;
using AlliantProductManagementServer.Domain.Exceptions;
using AlliantProductManagementServer.Domain.Repositories.Customers;
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
    public class CreateUserCommand : IRequest<UserDto>
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
    public class CreateUserHandler(IUserRepository userRepository, IMapper mapper, IJwtHandler jwtHandler) : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IJwtHandler _jwtHandler = jwtHandler;
        private readonly IMapper _mapper = mapper;

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            var userExists = await _userRepository.GetUserByEmail(user.Email);
            if (userExists is not null)
            {
                throw new DomainException("Email already taken.", (int)HttpStatusCode.Conflict);
            }

            await _userRepository.AddAsync(user);

            var response = _mapper.Map<User, UserDto>(user);

            response.Token = _jwtHandler.GenerateJwtToken(user);

            return response;
        }
    }
}
