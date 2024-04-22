using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6002CEM_Maui_App.ViewModels
{
    public partial class SettingsPageViewModel : PageViewModel
    {
        private string _selectedItem;
        public string SelectedItem // On get, return _selectedItem, on set alter dynamic resources based on value set to
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    if (_selectedItem == "Dark")
                    {
                        Shell.Current.Resources["Primary"] = Color.FromArgb("#242424");
                        Shell.Current.Resources["PrimaryDark"] = Color.FromArgb("#3C3C3C");
                        Shell.Current.Resources["PrimaryDarkText"] = Color.FromArgb("#FFFFFF");
                    }
                    else
                    {
                        Shell.Current.Resources["Primary"] = Color.FromArgb("#FFFFFF");
                        Shell.Current.Resources["PrimaryDark"] = Color.FromArgb("#E6E6E6");
                        Shell.Current.Resources["PrimaryDarkText"] = Color.FromArgb("#242424");
                    }
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        public SettingsPageViewModel()
        {
            
        }
    }
}
