using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fylth.ViewModels;

namespace Fylth.Views;

public partial class E621PostsPage : ContentPage
{
    public E621PostsPage(E621PostsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        
        if (DeviceInfo.Current.Idiom != DeviceIdiom.Desktop) return;
        ToolbarItems.Add(new ToolbarItem()
        {
            Command = viewModel.GetPostsCommand,
            Text = "Refresh",
            IconImageSource = new FontImageSource()
            {
                FontFamily = "FaSolid",
                Glyph = "\uf2f1",
                FontAutoScalingEnabled = true
            }
        });
    }
}