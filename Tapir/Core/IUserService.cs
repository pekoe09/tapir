using System.Collections.Generic;

namespace Tapir.Core
{
    public interface IUserService
    {
        List<UserDTO> GetUsers();
        UserDTO GetUser(int id);
        UserDTO SaveUser(UserDTO user);
        UserDTO RemoveUser(int id);
    }
}
