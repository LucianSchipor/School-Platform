using School_Platform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace School_Platform.Views
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin_View : Window
    {
        public Admin_View()
        {
            InitializeComponent();
        }

        public class MyTemplateSelector : DataTemplateSelector
        {
            public override DataTemplate SelectTemplate(object item, DependencyObject container)
            {
                // Implementați logica de selectare a șablonului în funcție de criteriile dorite
                // Returnați șablonul corespunzător în funcție de item

                if (item is List<Student>)
                    return (DataTemplate)Application.Current.Resources["ListBox_StudentsTemplate"];

                if (item is List<Teacher>)
                    return (DataTemplate)Application.Current.Resources["ListBox_StudentsTemplate"];

                if (item is List<Class>)
                    return (DataTemplate)Application.Current.Resources["ListBox_StudentsTemplate"];

                if (item is List<Specializations_Subjects>)
                    return (DataTemplate)Application.Current.Resources["ListBox_StudentsTemplate"];

                // Returnați alte șabloane, dacă este cazul

                return null;
            }
        }
    }
}
