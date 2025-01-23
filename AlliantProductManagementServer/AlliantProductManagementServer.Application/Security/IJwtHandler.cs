using AlliantProductManagementServer.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Application.Security
{
    public interface IJwtHandler
    {
        string GenerateJwtToken(User user);
    }
}
