using System.Collections.ObjectModel;

namespace School_Platform.Models
{
    public class DB_Context
    {

        public ObservableCollection<User> _users { get; set; }
        public ObservableCollection<Student> _students { get; set; }

        public ObservableCollection<Class> classes;
        public DB_Context()
        {

            _students = new ObservableCollection<Student>();
            _users = new ObservableCollection<User>();

            User user = new User();
            user.SetUsername("lucian1");
            user.SetPassword("pass1");
            _users.Add(user);
            user = new User();
            user.SetUsername("lucian2");
            user.SetPassword("pass2");
            _users.Add(user);
            user = new User();
            user.SetUsername("lucian3");
            user.SetPassword("pass3");
            _users.Add(user);
            user = new User();
            user.SetUsername("lucian4");
            user.SetPassword("pass4");
            _users.Add(user);
            user = new User();
            user.SetUsername("lucian5");
            user.SetPassword("pass5");
            _users.Add(user);

            _users[0].MakeAdmin();

            classes = new ObservableCollection<Class>();
            classes.Add(new Class { ID = "A", Specialization = "Matematica-Informatica", YearOfStudy = "9" });
            classes.Add(new Class { ID = "B", Specialization = "Stiinte ale naturii", YearOfStudy = "9" });
            classes.Add(new Class { ID = "C", Specialization = "Stiinte-Sociale", YearOfStudy = "9" });
            classes.Add(new Class { ID = "D", Specialization = "Filologie", YearOfStudy = "9" });
            classes.Add(new Class { ID = "A", Specialization = "Matematica-Informatica", YearOfStudy = "10" });
            classes.Add(new Class { ID = "B", Specialization = "Stiinte ale naturii", YearOfStudy = "10" });
            classes.Add(new Class { ID = "C", Specialization = "Stiinte-Sociale", YearOfStudy = "10" });
            classes.Add(new Class { ID = "D", Specialization = "Filologie", YearOfStudy = "10" });
            classes.Add(new Class { ID = "A", Specialization = "Matematica-Informatica", YearOfStudy = "11" });

        }
    }
}
