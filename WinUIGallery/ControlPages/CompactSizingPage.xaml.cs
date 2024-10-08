﻿using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using AppUIBasics.SamplePages;

namespace AppUIBasics.ControlPages
{
    public sealed partial class CompactSizingPage : Page
    {
        public CompactSizingPage()
        {
            this.InitializeComponent();

        }

        private void Example1_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(SampleStandardSizingPage), null, new SuppressNavigationTransitionInfo());
        }

        private void Standard_Checked(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(SampleStandardSizingPage), null, new SuppressNavigationTransitionInfo());
        }

        private void Compact_Checked(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(SampleCompactSizingPage), null, new SuppressNavigationTransitionInfo());
        }
    }
}
