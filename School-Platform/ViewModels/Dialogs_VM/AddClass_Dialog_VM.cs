using School_Platform.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace School_Platform.ViewModels.Dialogs_VM
{
    public class AddClass_Dialog_VM : BaseVM
    {
        private string selectedYear;
        public string SelectedYear
        {
            get
            {
                return selectedYear;
            }
            set
            {
                selectedYear = value;
                NotifyPropertyChanged(nameof(SelectedYear));
            }
        }

        private string selectedLetter;
        public string SelectedLetter
        {
            get
            {
                return selectedLetter;
            }
            set
            {
                selectedLetter = value;
                NotifyPropertyChanged(nameof(selectedLetter));
            }
        }

        private string selectedSpec;
        public string SelectedSpec
        {
            get
            {
                return selectedSpec;
            }
            set
            {
                selectedSpec = value;
                NotifyPropertyChanged(nameof(selectedSpec));
            }
        }



        private ICommand selectYearCommand;
        public ICommand SelectYearCommand
        {
            get
            {
                if (selectYearCommand == null)
                {
                    selectYearCommand = new RelayCommandGeneric<ComboBoxItem>(SelectYear);
                }
                return selectYearCommand;
            }
        }

        private void SelectYear(ComboBoxItem selected)
        {
            this.selectedYear = (selected.Content as string);
        }

        private ICommand selectSpecializationCommand;
        public ICommand SelectSpecializationCommand
        {
            get
            {
                if (selectSpecializationCommand == null)
                {
                    selectSpecializationCommand = new RelayCommandGeneric<ComboBoxItem>(SelectSpecialization);
                }
                return selectSpecializationCommand;
            }
        }

        private void SelectSpecialization(ComboBoxItem selected)
        {
            this.selectedSpec = (selected.Content as string);
        }

        private ICommand selectLetterCommand;
        public ICommand SelectLetterCommand
        {
            get
            {
                if (selectLetterCommand == null)
                {
                    selectLetterCommand = new RelayCommandGeneric<ComboBoxItem>(SelectLetter);
                }
                return selectLetterCommand;
            }
        }

        private void SelectLetter(ComboBoxItem selected)
        {
            this.selectedLetter = selected.Content.ToString();
        }
    }
}
