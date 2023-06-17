using Hotel_List_API.Models.User;
using Microsoft.AspNetCore.Identity;

namespace Hotel_List_API.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDTO userDto);
        Task<bool> Login(LoginDTO loginDTO);
    }
}
