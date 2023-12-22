using Api.Models;

namespace Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<UserModel> GetAllUsers();
        UserModel GetById(int id);
        UserModel Add(UserModel user);
        UserModel Update(UserModel user, int Id);
        bool Delete(int id);
    }
}
