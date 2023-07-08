using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Fylth.Models;
using Fylth.Models.E621;
using Fylth.Services;

namespace Fylth.ViewModels;

[QueryProperty(nameof(SelectedPost), "SelectedPost")]
public partial class E621ViewPostViewModel : BaseViewModel
{
    public ObservableCollection<TagPill> PostTags { get; set; } = new();

    [ObservableProperty] 
    private bool _isRefreshing;
    
    [ObservableProperty]
    private Post _selectedPost;

    [ObservableProperty]
    private bool _isVideo;

    [ObservableProperty]
    private bool _isAnimated;

    [ObservableProperty]
    private bool _isFlash;

    private readonly E621Service _e621Service;
    
    public E621ViewPostViewModel(E621Service e621Service)
    {
        _e621Service = e621Service;
    }

    private void LoadTags()
    {
        foreach (var s in SelectedPost.Tags.General)
        {
            PostTags.Add(new TagPill()
            {
                Type = "General",
                Value = s
            });
        }
    }
    
    [RelayCommand]
    private void SetMediaType()
    {
        switch (SelectedPost.File.Ext.ToLower())
        {
            case ("gif"):
                IsAnimated = true;
                IsVideo = false;
                IsFlash = false;
                break;

            case ("webm"):
                IsAnimated = false;
                IsVideo = true;
                IsFlash = false;
                break;

            case ("swf"):
                IsAnimated = false;
                IsVideo = false;
                IsFlash = true;
                break;

            default:
                IsAnimated = false;
                IsVideo = false;
                IsFlash = false;
                break;
        }

    }
}