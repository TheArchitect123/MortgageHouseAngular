using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageHouse.Backend.Domain.ServiceArtifacts
{
    public interface IUserSecurity
    {
        bool AuthenticateUser(string username, string password);
    }
}
