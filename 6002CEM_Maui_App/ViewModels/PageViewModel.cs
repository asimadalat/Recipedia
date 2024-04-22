using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace _6002CEM_Maui_App.ViewModels;

// Base view model, other vms to inherit OnProperyChanged
public class PageViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    // For ui element updates 
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public PageViewModel()
    {
    }
}