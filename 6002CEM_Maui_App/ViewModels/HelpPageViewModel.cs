using _6002CEM_Maui_App.Interfaces;
using _6002CEM_Maui_App.Services;
using _6002CEM_Maui_App.Models;
using _6002CEM_Maui_App.Views;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace _6002CEM_Maui_App.ViewModels
{
    public partial class HelpPageViewModel : PageViewModel
    {
        private readonly IHelpService _helpService;
        private readonly ILocalDatabaseService _localDatabaseService;

        private ObservableCollection<HelpModel> _help;
        public ObservableCollection<HelpModel> Help
        {
            get { return _help; }
            set
            {
                if (_help != value)
                {
                    _help = value;
                    OnPropertyChanged(nameof(Help));
                }
            }
        }

        public HelpPageViewModel(ILocalDatabaseService localDatabaseService)
        {
            _localDatabaseService = localDatabaseService;
            _helpService = new HelpService();
            updateHelp();
        }

        public async void updateHelp()
        {
            // Get all categories from local db, convert to observablecollection 
            Help = new ObservableCollection<HelpModel>(await _localDatabaseService.GetHelpQuestions());
        }
    }
}
