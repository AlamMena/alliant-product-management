using AlliantProductManagementServer.Application.Dtos.Users;
using AlliantProductManagementServer.Application.Features.Users.Handlers;
using AlliantProductManagementServer.Domain.Entities.Users;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Mappings.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<User, UserDto>();
        }
    }
}
