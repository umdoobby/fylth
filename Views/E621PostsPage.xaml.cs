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
        
        // The annoying solution to issue #2 for right now anyway
        ToolbarItems.Add(new ToolbarItem()
        {
            Command = viewModel.GetMorePostsCommand,
            Text = "Get more posts",
            IconImageSource = new FontImageSource()
            {
                FontFamily = "FaSolid",
                Glyph = "\uf2ea",
                FontAutoScalingEnabled = true
            }
        });
    }

    private int CalculateColumns(double width, int frameSize)
    {
        var columns = (int)Math.Round(width / frameSize);
        if (columns < 1) columns = 1;
        return columns;
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        if (BindingContext is not E621PostsViewModel vm) return;
        vm.NumOfColumns = CalculateColumns(width, vm.PreviewFrameSize);
    }

    private void E621PostsPage_OnLoaded(object sender, EventArgs e)
    {
        if (BindingContext is not E621PostsViewModel vm) return;
        vm.NumOfColumns = CalculateColumns(DeviceDisplay.MainDisplayInfo.Width, vm.PreviewFrameSize);
    }
}