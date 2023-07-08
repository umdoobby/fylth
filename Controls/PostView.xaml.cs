using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Fylth.Models;
using Fylth.Models.E621;
using E6File = Fylth.Models.E621.File;

namespace Fylth.Controls;

public partial class PostView : ContentView
{
    public static readonly BindableProperty PreviewContentProperty = BindableProperty.Create(nameof(PreviewContent), typeof(Preview), typeof(PostView));
    
    public static readonly BindableProperty SampleContentProperty = BindableProperty.Create(nameof(SampleContent), typeof(Sample), typeof(PostView));
    
    public static readonly BindableProperty FileContentProperty = BindableProperty.Create(nameof(FileContent), typeof(E6File), typeof(PostView));
    
    public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(PostView), 5);
    
    public Preview PreviewContent
    {
        get => (Preview)GetValue(PreviewContentProperty);
        set => SetValue(PreviewContentProperty, value);
    }
    
    public Sample SampleContent
    {
        get => (Sample)GetValue(SampleContentProperty);
        set => SetValue(SampleContentProperty, value);
    }
    
    public E6File FileContent
    {
        get => (E6File)GetValue(FileContentProperty);
        set => SetValue(FileContentProperty, value);
    }
    
    public int CornerRadius
    {
        get => (int)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public PostView()
    {
        InitializeComponent();
    }
    
    private async Task LoadFlashPlayer()
    {
        await using var stream = await FileSystem.OpenAppPackageFileAsync("FlashView\\index.html");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        FlashPlayer.Source = new HtmlWebViewSource()
        {
            Html = contents,
            BaseUrl = "file:///FlashView/"
        };
        await FlashPlayer.EvaluateJavaScriptAsync($"playFile({FileContent.Url})");
    }
    
    private void SetContentVisibility(VisualElement element, bool enabled)
    {
        element.IsEnabled = enabled;
        element.IsVisible = enabled;
    }

    private void PostView_OnLoaded(object sender, EventArgs e)
    {
        switch (FileContent.Ext.ToLower())
        {
            case ("gif"):
                SampleImage.IsAnimationPlaying = true;
                FullImage.IsAnimationPlaying = true;
                SetContentVisibility(VideoPlayer, false);
                SetContentVisibility(FlashPlayer, false);
                break;

            case ("webm"):
                SetContentVisibility(SampleImage, false);
                SetContentVisibility(FullImage, false);
                SetContentVisibility(FlashPlayer, false);
                break;

            case ("swf"):
                SetContentVisibility(SampleImage, false);
                SetContentVisibility(FullImage, false);
                SetContentVisibility(VideoPlayer, false);
                Task.Run(async () =>
                {
                    await LoadFlashPlayer();
                });
                break;

            default:
                SetContentVisibility(VideoPlayer, false);
                SetContentVisibility(FlashPlayer, false);
                break;
        }
    }


    private void SampleImage_OnLoaded(object sender, EventArgs e)
    {
        PreviewImage.IsVisible = false;
        SetContentVisibility(LoadingIndicator, false);
    }

    private void FullImage_OnLoaded(object sender, EventArgs e)
    {
        PreviewImage.IsVisible = false;
        SetContentVisibility(LoadingIndicator, false);
    }
    
    private void FlashPlayer_OnLoaded(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void VideoPlayer_OnLoaded(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}