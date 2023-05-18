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

            Student student = new Student{ Name = "Lucian", Email ="lucian@unitbv.ro"};
            _students.Add(student);

            student = new Student();
            student.Name = "Alexandru";
            student.Email = "alexandru@unitbv.ro";
            _students.Add(student);

            student = new Student();
            student.Name = "Mihai";
            student.Email = "mihai@unitbv.ro";
            _students.Add(student);
            student = new Student();
            student.Name = "Ioana";
            student.Email = "ioana@unitbv.ro";
            _students.Add(student);
            student = new Student();
            student.Name = "Adriana";
            student.Email = "adriana@unitbv.ro";
            _students.Add(student);
            student = new Student();
            student.Name = "Ionica";
            student.Email = "ionica@unitbv.ro";
            _students.Add(student);
            student = new Student();
            student.Name = "MGK";
            student.Email = "mgk@unitbv.ro";
            _students.Add(student);
            student = new Student();
            student.Name = "Sebi";
            student.Email = "sebi@unitbv.ro";
            _students.Add(student);
            student = new Student();
            student.Name = "Rares";
            student.Email = "rares@unitbv.ro";
            _students.Add(student);
            student = new Student();
            student.Name = "Alexia";
            student.Email = "alexia@unitbv.ro";
            _students.Add(student);

            classes[0].AddStudent(_students[0]);
            classes[1].AddStudent(_students[1]);
            classes[2].AddStudent(_students[2]);
            classes[2].AddStudent(_students[3]);
            classes[3].AddStudent(_students[4]);
            classes[3].AddStudent(_students[5]);
            classes[4].AddStudent(_students[6]);
            classes[5].AddStudent(_students[7]);
            classes[6].AddStudent(_students[8]);
            classes[6].AddStudent(_students[9]);
        }
    }
}
