using System.Threading.Tasks;
using Bookstore.Api.Dtos;

namespace Bookstore.Api.Services
{
  public interface IAuthManager
  {
    Task<bool> ValidateUser(LoginUserDto userDto);
    Task<string> CreateToken();
  }
}