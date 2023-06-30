using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fylth.Models.E621;

namespace Fylth.Controls;

public partial class PostContentView : ContentView
{
    public static readonly BindableProperty CurrentPostProperty = BindableProperty.Create(nameof(CurrentPost), typeof(Post), typeof(PostCardView));
    
    public Post CurrentPost
    {
        get => (Post)GetValue(CurrentPostProperty);
        set => SetValue(CurrentPostProperty, value);
    }

    public PostContentView()
    {
        InitializeComponent();
    }
}