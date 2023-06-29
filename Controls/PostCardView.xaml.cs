using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Fylth.Models.E621;
using Fylth.Models.Settings;
using Fylth.Services;

namespace Fylth.Controls;

public partial class PostCardView : ContentView
{
    
    public static readonly BindableProperty CurrentPostProperty = BindableProperty.Create(nameof(CurrentPost), typeof(Post), typeof(PostCardView));

    public static readonly BindableProperty PreviewSizeProperty = BindableProperty.Create(nameof(PreviewSize), typeof(int), typeof(PostCardView), 150);
    
    public Post CurrentPost
    {
        get => (Post)GetValue(CurrentPostProperty);
        set => SetValue(CurrentPostProperty, value);
    }
    
    public int PreviewSize
    {
        get => (int)GetValue(PreviewSizeProperty);
        set => SetValue(PreviewSizeProperty, value);
    }

    public int FrameSize => PreviewSize + 4;

    public static Aspect PreviewAspect => SettingsService.Read(SettingsKeys.FillPreview) ? Aspect.AspectFill : Aspect.AspectFit;

    public PostCardView()
    {
        InitializeComponent();
    }

    private void PostCardView_OnLoaded(object sender, EventArgs e)
    {
        MainBorder.Stroke = CurrentPost.Rating.Trim().ToLower() switch
        {
            "e" => GetColorResource("Danger500"),
            "q" => GetColorResource("Warn500"),
            "s" => GetColorResource("Success500"),
            _ => GetColorResource("Gray500")
        };
    }

    private Color GetColorResource(string key)
    {
        var hasValue = App.Current.Resources.TryGetValue(key, out object tempColor);
        if (hasValue)
        {
            return (Color)tempColor;
        }

        return Colors.White;
    }
}