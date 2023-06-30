using CommunityToolkit.Mvvm.ComponentModel;
using Fylth.Models.E621;
using Fylth.Services;

namespace Fylth.ViewModels;

[QueryProperty(nameof(SelectedPost), "Post")]
public partial class E621ViewPostViewModel : BaseViewModel
{
    [ObservableProperty] 
    private bool _isRefreshing;
    
    [ObservableProperty]
    private Post _selectedPost;

    private readonly E621Service _e621Service;
    
    public E621ViewPostViewModel(E621Service e621Service)
    {
        _e621Service = e621Service;
    }
}