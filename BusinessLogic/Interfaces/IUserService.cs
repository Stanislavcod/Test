using Model.Model;

namespace BusinessLogic.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByLastName(string lastName);
        void CreateUser(User user);
    }
}
