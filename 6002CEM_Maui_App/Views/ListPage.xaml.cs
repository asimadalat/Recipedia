using _6002CEM_Maui_App.Models;
using _6002CEM_Maui_App.ViewModels;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Collections.ObjectModel;

namespace _6002CEM_Maui_App.Views
{
    public partial class ListPage : ContentPage
    {
        public ListPage(ListPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}