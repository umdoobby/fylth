using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Fylth.Models.E621;
using Fylth.Models.Settings;
using Fylth.Services;

namespace Fylth.ViewModels;

public partial class E621PostsViewModel : BaseViewModel
{
    public ObservableCollection<Post> Posts { get; set; } = new();

    private readonly E621Service _e621Service;

    [ObservableProperty] 
    private bool _isRefreshing;

    [ObservableProperty] 
    private int _numRemaining = 5;
    
    [ObservableProperty] 
    private Aspect _previewAspect;

    public E621PostsViewModel(E621Service e621Service)
    {
        Title = "e621 Latest Posts";
        _e621Service = e621Service;
        
        Task.Run(async () =>
        {
            if (SettingsService.Read(SettingsKeys.E621IsLoggedIn))
            {
                if (!await _e621Service.Login())
                {
                    await Shell.Current.DisplayAlert("Error",
                        $"Failed to log into e621. Confirm that your username and API key are still correct.", "OK");
                }
            }
            
            await GetPostsAsync();
        });
    }
    
    [RelayCommand]
    private async Task CheckPreviewAspect()
    {
        await Task.Run( () =>
        {
            PreviewAspect = SettingsService.Read(SettingsKeys.FillPreview) ? Aspect.AspectFill : Aspect.AspectFit;
        });
    }
    
    [RelayCommand]
    private async Task GetPostsAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            var posts = await _e621Service.GetPosts();
            if (Posts.Any()) 
                Posts.Clear();
            foreach (var post in posts.Where(post => post.Preview.Url is not null))
            {
                Posts.Add(post);
            }
        }
        catch (Exception exception)
        {
            Debug.WriteLine("Failed to retrieve posts from e621 with following error\n{0}", exception);
            await Shell.Current.DisplayAlert("Error", $"Failed to retrieve posts from e621 with error:\n{exception.Message}", "OK");
            throw;
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }
    }
    
    


}