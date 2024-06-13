using System.Net;

namespace FriendFace;

public class Menu
{
    private Network _network;
    private User _currentUser;

    public Menu()
    {
        _network = new Network(this);
    }
    public void GameMenu()
    {
        
        Console.WriteLine("Welcome to FriendFace");
        MakeUser();
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?\n1. Find friends\n2. See friends");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ShowUserMenu();
                    break;
                case "2":
                    ShowFriendsMenu();
                    break;
                default:
                    Console.WriteLine("Write a valid number!");
                    break;
            }
        }

    }

    public void ShowUserMenu()
    {
        bool inMenu = true;
        while (inMenu)
        {
            _network.ShowAllUsers();
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Add friend\n2. Check profile\n3. Go back");
            var response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    AddFriend();
                    break;
                case "2":
                    ShowSpecificUser();
                    break;
                case "3":
                    inMenu = false;
                    break;
                default:
                    Console.WriteLine("Write a valid number");
                    break;
            }
        }
    }

    public void ShowFriendsMenu()
    {
        bool inMenu = true;
        while (inMenu)
        {
            _currentUser.ShowAllFriends();
            if (_currentUser.FriendList.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Remove friend\n2. Go back");
                var response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        RemoveFriend();
                        break;
                    case "2":
                        inMenu = false;
                        break;
                    default:
                        Console.WriteLine("Write a valid number");
                        break;
                }
            }
            else
            {
                Console.WriteLine("You have no friends!");
                inMenu = false;
            }
            
        }
    }


    public void MakeUser()
    {
        Console.WriteLine("Let's make you a profile!\nFirst things first: What is your name?");
        var name = Console.ReadLine();
        Console.WriteLine("Nice to meet you " + name + "!\nNow you need to set a password:");
        var password = Console.ReadLine();
        Console.WriteLine("Good! So how old are you?");
        var age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("And what city do you live in?");
        var city = Console.ReadLine();
        Console.WriteLine("Do you have any hobbies?");
        var hobby = Console.ReadLine();
        Console.WriteLine("And finally, what do you do for a living?");
        var job = Console.ReadLine();
        Console.WriteLine("Thank you! Here is your profile:");
        _currentUser = new User(name, password, age, city, hobby, job);
        Console.WriteLine($"Name: {_currentUser.Name}\nAge: {_currentUser.Age}\nCity: {_currentUser.City}\nHobbies: {_currentUser.Hobbies}\nJob: {_currentUser.Job}");
    }
    public void AddFriend()
    {
        Console.WriteLine("\nWrite the name of the person you want to add:");
        string input = Console.ReadLine();
        User friend = _network.GetUserByName(input);
        _currentUser.AddFriend(friend);
    }
    public void RemoveFriend()
    {
        Console.WriteLine("\nWrite the name of the person you want to remove:");
        string input = Console.ReadLine();
        User friend = _network.GetUserByName(input);
        _currentUser.RemoveFriend(friend);
    }

    public void ShowSpecificUser()
    {
        Console.WriteLine("\nWrite the name of the person you want to see the profile off:");
        string input = Console.ReadLine();
        User friend = _network.GetUserByName(input);
        _network.ShowSpecificUser(friend.Name);
    }

}