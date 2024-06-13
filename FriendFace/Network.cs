namespace FriendFace;

public class Network
{
    public List<User> users = new();
    private Menu _menu;

    public Network(Menu menu)
    {
        initialize();
        _menu = menu;
    }

    public void initialize()
    {
        users.Add(new User("Jonas", "1234", 27, "Ulefoss", "Writing", "Student"));
        users.Add(new User("Kristian", "abcd", 32, "Molde", "Cars", "IT-Support"));
        users.Add(new User("Trine", "2345", 31, "Senja", "Gaming", "Radiographer"));
        users.Add(new User("Marie", "bcde", 30, "Larvik", "Jujitsu", "Teacher"));
        users.Add(new User("Maren", "4321", 25, "Porsgrunn", "Cosplay", "Student"));
    }

    public void ShowAllUsers()
    {
        foreach (User user in users)
        {
            Console.WriteLine("\nName: " + user.Name + "\nAge: " + user.Age);
        }
    }

    public User GetUserByName(string name)
    {
        foreach (User user in users)
        {
            if (user.Name == name)
            {
                return user;
            }
        }
        return null;
    }

    public void ShowSpecificUser(string friend)
    {
        foreach (User user in users)
        {
            if (user.Name == friend)
            {
                Console.WriteLine("\nName: " + user.Name + "\nAge: " + user.Age + "\nCity: " + user.City + "\nHobbies: " + 
                                  user.Hobbies + "\nOccupation: " + user.Job);
            }
        }
    }
}