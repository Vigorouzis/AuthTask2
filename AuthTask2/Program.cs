using AuthTask2.interfaces;
using AuthTask2.model;

class Program
{
    public static void Main(string[] args)
    {


        var manager = new UserManager();
        var repository = new UserRepository();

        repository.GetById("d50fb692-3eb4-465a-b9d6-91021ed888ff");

        Console.WriteLine("1. Sing in");
        Console.WriteLine("2. Регистрация");
        Console.WriteLine("3. Sing out");
        while (true)
        {
            var message = Console.ReadLine();
            var users = repository.Get();
            var userList = repository.GetAuthUser();
            switch (message)
            {
                case "1":
                {
                    if (userList == null)
                    {
                        var username = Console.ReadLine();
                        var password = Console.ReadLine();
                        User? user = null;
                        foreach (var item in users)
                        {
                            if (item.Username == username && item.Password == password)
                            {
                                user = new User()
                                {
                                    Id = item.Id,
                                    Username = item.Username,
                                    Password = item.Password
                                };
                            }
                        }
                        manager.SingIn(user!);

                        Console.WriteLine("Вы успешно авторизированы\n");
                        Console.WriteLine("1. Редактирование");
                        Console.WriteLine("2. Sing out");

                        var newMessage = Console.ReadLine();
                        switch (newMessage)
                        {
                            case "1":
                            {
                                var editUsername = Console.ReadLine();
                                var editPassword = Console.ReadLine();
                                repository.Update(editUsername, editPassword);
                                break;
                            }

                            case "2":
                            {
                                manager.SingOut(userList[0]);
                                Console.WriteLine("Вы вышли");
                                break;
                            }
                        }


                    }
                    else
                    {
                        Console.WriteLine("Уже авторизованы");
                        Console.WriteLine("1. Редактирование");
                        Console.WriteLine("2. Sing out");

                        var newMessage = Console.ReadLine();
                        switch (newMessage)
                        {
                            case "1":
                            {
                                var editUsername = Console.ReadLine();
                                var editPassword = Console.ReadLine();
                                repository.Update(editUsername, editPassword);
                                break;
                            }

                            case "2":
                            {
                                manager.SingOut(userList[0]);
                                Console.WriteLine("Вы вышли");
                                break;
                            }
                        }


                    }
                    break;
                }
                case "2":
                {
                    var username = Console.ReadLine();
                    var password = Console.ReadLine();
                    manager.Registration(username, password);
                    break;
                }
                case "3":
                    manager.SingOut(userList[0]);
                    Console.WriteLine("Вы вышли");
                    break;

            }


        }
    }
}