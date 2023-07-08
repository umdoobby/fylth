using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Fylth.ViewModels;

namespace Fylth.Views;

public partial class E621ViewPostPage : ContentPage
{
    public E621ViewPostPage(E621ViewPostViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void E621ViewPostPage_OnAppearing(object sender, EventArgs e)
    {
        if (BindingContext is not E621ViewPostViewModel vm) return;
        Title = $"Post ID {vm.SelectedPost.Id}";
    }

    private void E621ViewPostPage_OnNavigatedTo(object sender, NavigatedToEventArgs e)
    {
        if (BindingContext is not E621ViewPostViewModel vm) return;
        vm.SetMediaTypeCommand.Execute(null);
    }

    private void Preview_OnLoaded(object sender, EventArgs e)
    {
        
    }
}