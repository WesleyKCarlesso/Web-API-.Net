using Api.Data;
using Api.Models;
using Api.Repositories.Interfaces;

namespace Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiDBContext _apiDBContext;

        public UserRepository(ApiDBContext apiDBContext)
        {
            _apiDBContext = apiDBContext;
        }

        public List<UserModel> GetAllUsers()
        {
            return _apiDBContext.Users.ToList();
        }

        public UserModel GetById(int id)
        {
            return _apiDBContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public UserModel Add(UserModel user)
        {
            _apiDBContext.Users.Add(user);
            _apiDBContext.SaveChanges();
            
            return user;
        }

        public UserModel Update(UserModel user, int id)
        {
            UserModel userById = GetById(id);
            
            if (userById == null)
            {
                throw new Exception($"Usuário não encontrado.");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;

            _apiDBContext.Users.Update(userById);
            _apiDBContext.SaveChanges();

            return userById;
        }

        public bool Delete(int id)
        {
            UserModel userById = GetById(id);

            if (userById == null)
            {
                return false;
            }

            _apiDBContext.Users.Remove(userById);
            _apiDBContext.SaveChanges();

            return true;
        }
    }
}
