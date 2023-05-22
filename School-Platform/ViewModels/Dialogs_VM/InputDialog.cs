using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows;

namespace School_Platform.ViewModels.Dialogs_VM
{
    public class InputDialog : Window
    {
        private readonly TextBox textBox = new TextBox();
        public Label label = new Label();
        private readonly Button okButton = new Button { Content = "OK", FontSize = 10, Height = 20, Width = 50 };
        private readonly Button cancelButton = new Button { Content = "Cancel", FontSize = 10, Height = 20, Width = 50 };
        private readonly ComboBox comboBox = new ComboBox();
        public string Answer => comboBox.SelectedItem.ToString();

        public InputDialog(string prompt)
        {
            Title = prompt;
            Width = 300;
            Height = 300;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            comboBox.Items.Add("Mate-Info");
            comboBox.Items.Add("Stiinte ale naturii");
            comboBox.Items.Add("Stiinte sociale");
            comboBox.Items.Add("Filologie");

            var stackPanel = new StackPanel();
            stackPanel.Children.Add(comboBox);
            stackPanel.Children.Add(label);
            label.Content = "Choose name.";
            var buttonPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            buttonPanel.Children.Add(okButton);
            buttonPanel.Children.Add(cancelButton);
            stackPanel.Children.Add(buttonPanel);
            Content = stackPanel;
            okButton.Click += (sender, e) => DialogResult = true;
            cancelButton.Click += (sender, e) => DialogResult = false;
        }
    }
}
