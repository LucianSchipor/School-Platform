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

            _users = new ObservableCollection<User>();
            User user = new User();
            user.UserName = "lucian3";
            user.Password = "pass1";
            _users.Add(user);

            user.UserName = "lucian1";
            user.Password = "pass2";
            _users.Add(user);

            user.UserName = "lucian5";
            user.Password = "pass1";
            _users.Add(user);

            user.UserName = "lucian";
            user.Password = "pass";
            _users.Add(user);

            classes = new ObservableCollection<Class>();
            classes.Add(new Class { ID = "A", Specialization = "Stiinte-Sociale", YearOfStudy = "9" });
            classes.Add(new Class { ID = "B", Specialization = "Filologie", YearOfStudy = "9" });
            classes.Add(new Class { ID = "C", Specialization = "Stiinte-ale-Naturii", YearOfStudy = "9" });
            classes.Add(new Class { ID = "D", Specialization = "Matematica-Informatica", YearOfStudy = "9" });
            classes.Add(new Class { ID = "A", Specialization = "Stiinte-Sociale", YearOfStudy = "10" });
            classes.Add(new Class { ID = "B", Specialization = "Stiinte-Sociale", YearOfStudy = "10" });
            classes.Add(new Class { ID = "C", Specialization = "Matematica-Informatica", YearOfStudy = "10" });
            classes.Add(new Class { ID = "D", Specialization = "Stiinte-Sociale", YearOfStudy = "10" });
            classes.Add(new Class { ID = "A", Specialization = "Stiinte-ale-Naturii", YearOfStudy = "11" });
        }
    }
}
