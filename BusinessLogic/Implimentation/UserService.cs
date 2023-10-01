using BusinessLogic.Interfaces;
using Model.DataBaseContext;
using Model.Model;

namespace BusinessLogic.Implimentation
{
    public class UserService : IUserService
    {
        private readonly ApplicationDataBaseContext _context;

        public UserService(ApplicationDataBaseContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public User GetUserById(int id)
        {
            var existUser = _context.Users.FirstOrDefault(x => x.Id == id);

            return existUser;
        }

        public void CreateUser(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(x => x.Name == user.Name
            && x.MiddleName == user.MiddleName
            && x.LastName == user.LastName);
            if (existingUser == null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Ошибка при регистрации пользователя, такой пользователь уже есть");
            }
        }
        public User GetUserByLastName(string lastName)
        {
            var existUser = _context.Users.FirstOrDefault(x => x.LastName == lastName);

            return existUser;
        }
    }
}
