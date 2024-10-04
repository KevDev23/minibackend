

using backendpv.Models;

namespace backendpv.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Manager user);
    }
}
