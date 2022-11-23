using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Serialization;
using AuthTask2.model;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace AuthTask2.interfaces;

public interface IUserRepository
{
    IList<User>? Get();

    IList<User>? GetAuthUser();
    void Update(string username, string password);
    void Delete(User user);
    void Add(User user);

    void AddAuth(User user);
    void GetById(string id);
}
class UserRepository : IUserRepository
{
    public IList<User>? Get()
    {

        using var r = new StreamReader("users.json");
        var json = r.ReadToEnd();
        var list = JsonConvert.DeserializeObject<List<User>>(json);
        if (json.Length == 0)
        {
            return null;
        }
        return list;


    }

    public IList<User>? GetAuthUser()
    {
        using var r = new StreamReader("user.json");
        var json = r.ReadToEnd();
        var list = JsonConvert.DeserializeObject<List<User>>(json);
        if (json.Length == 0)
        {
            return null;
        }
        return list;
    }

    public void Update(string username, string password)
    {
        var list = Get();
        foreach (var item in list)
        {
            if (item.Username == username)
            {
                item.Password = password;
            }
        }

        var jsonString = JsonSerializer.Serialize(list, new JsonSerializerOptions()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, WriteIndented = true
        });
        File.WriteAllText(@"users.json", jsonString);

    }

    public void Delete(User user)
    {
        File.WriteAllText(@"user.json", "");
    }

    public void Add(User user)
    {

        var users = Get();

        if (users == null)
        {
            users = new List<User>();
        }

        var data = new User
        {
            Id = user.Id,
            Username = user.Username,
            Password = user.Password
        };

        users?.Add(data);

        var jsonString = JsonSerializer.Serialize(users, new JsonSerializerOptions()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, WriteIndented = true
        });
        File.WriteAllText(@"users.json", jsonString);


    }

    public void AddAuth(User user)
    {
        var users = GetAuthUser();

        if (users == null)
        {
            users = new List<User>();
        }

        var data = new User
        {
            Id = user.Id,
            Username = user.Username,
            Password = user.Password
        };

        users?.Add(data);

        var jsonString = JsonSerializer.Serialize(users, new JsonSerializerOptions()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, WriteIndented = true
        });
        File.WriteAllText(@"user.json", jsonString);
    }


    public void GetById(string id)
    {
        var users = Get();
        foreach (var item in users)
        {
            if (Equals(item.Id, id))
            {
                Console.WriteLine($"GUID: {item.Id}, username: {item.Username}, password: {item.Password}");
            }
        }
    }
}