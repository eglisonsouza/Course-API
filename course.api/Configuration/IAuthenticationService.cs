using System;
using course.api.Models.Users;

namespace course.api.Configuration
{
    public interface IAuthenticationService
    {
        String GenerateToken(UserViewModelOutput userViewModelOutput);
    }
}