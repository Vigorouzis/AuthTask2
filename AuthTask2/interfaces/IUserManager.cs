using AuthTask2.model;

namespace AuthTask2.interfaces;

public interface IUserManager
{
    void SingIn(User user);
    void Registration(string? username, string? password);

    void Edit(string username, string password);
    void SingOut(User user);
}
class UserManager : IUserManager
{
    private UserRepository _repository = new UserRepository();


    public void SingIn(User user)
    {
        _repository.AddAuth(user);
        
    }

    public void Registration(string? username, string? password)
    {
        var newUser = new User
        {
            Id = Guid.NewGuid().ToString(),
            Username = username,
            Password = password
        };

        _repository.Add(newUser);
    }

    public void Edit(string username, string password)
    {
        _repository.Update(username, password);
    }

    public void SingOut(User user)
    {
        _repository.Delete(user);
    }
}