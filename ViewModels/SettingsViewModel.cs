using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylth.ViewModels;

public partial class SettingsViewModel : BaseViewModel
{
    [ObservableProperty]
    private bool _isRefreshing;

    [ObservableProperty]
    private string _LabelText;

    public SettingsViewModel()
    {
        LabelText = "Wooo lad settings";
    }
}
