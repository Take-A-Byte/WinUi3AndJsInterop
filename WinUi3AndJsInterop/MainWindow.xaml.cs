// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using System;
using Microsoft.UI.Xaml;
using Microsoft.Web.WebView2.Core;

namespace WinUi3AndJsInterop
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            webView2.Loaded += OnWebView2Loaded;
        }

        private async void OnWebView2Loaded(object sender, RoutedEventArgs e)
        {
            await webView2.EnsureCoreWebView2Async();
            webView2.CoreWebView2.SetVirtualHostNameToFolderMapping(hostName: "shan.tutorials.winui3",
                folderPath: "Assets",
                accessKind: CoreWebView2HostResourceAccessKind.Allow);

            webView2.Source = new Uri("https://shan.tutorials.winui3/html/index.html");

        }
    }
}
