using System.Threading.Channels;

namespace FriendFace;

public class User
{
    public string Name { get; private set; }
    private string Password { get; set; }
    public int Age { get; private set; }
    public string City { get; private set; }
    public string Hobbies { get; private set; }
    public string Job { get; private set; }
    public List<User> FriendList { get; private set; }

    public User(string name, string password, int age, string city, string hobbies, string job)
    {
        Name = name;
        Password = password;
        Age = age;
        City = city;
        Hobbies = hobbies;
        Job = job;
        FriendList = new List<User>();
    }

    public void AddFriend(User friend)
    {
        if (friend != null && !FriendList.Contains(friend))
        {
            FriendList.Add(friend);
            Console.WriteLine($"{friend.Name} has been added to your friend list.");
        }
        else
        {
            Console.WriteLine("Friend not found or already in friend list.");
        }
    }

    public void RemoveFriend(User friend)
    {
        if (friend != null && FriendList.Contains(friend))
        {
            FriendList.Remove(friend);
            Console.WriteLine($"{friend.Name} has been removed from your friend list.");
        }
        else
        {
            Console.WriteLine("Friend not found in friend list.");
        }
    }

    public void ShowAllFriends()
    {
        foreach (User user in FriendList)
        {
            Console.WriteLine("\nName: " + user.Name + "\nAge: " + user.Age);
        }
    }


}