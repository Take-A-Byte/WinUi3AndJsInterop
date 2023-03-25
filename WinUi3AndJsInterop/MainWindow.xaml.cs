// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using System;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.Web.WebView2.Core;
using Windows.Graphics;
using Microsoft.UI.Windowing;

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
            // Retrieve the window handle (HWND) of the current (XAML) WinUI 3 window.
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);

            // Retrieve the WindowId that corresponds to hWnd.
            WindowId windowId = Win32Interop.GetWindowIdFromWindow(hWnd);

            // Lastly, retrieve the AppWindow for the current (XAML) WinUI 3 window.
            AppWindow appWindow = AppWindow.GetFromWindowId(windowId);

            if (appWindow != null)
            {
                appWindow.Resize(new SizeInt32(800, 300));
            }

            webView2.Loaded += OnWebView2Loaded;
        }

        private async void OnWebView2Loaded(object sender, RoutedEventArgs e)
        {
            await webView2.EnsureCoreWebView2Async();
            webView2.CoreWebView2.SetVirtualHostNameToFolderMapping(hostName: "shan.tutorials.winui3",
                folderPath: "Assets",
                accessKind: CoreWebView2HostResourceAccessKind.Allow); 
            var dispatchAdapter = new NativeAdapter.DispatchAdapter();
            webView2.CoreWebView2.AddHostObjectToScript(
                "NativeCode", dispatchAdapter.WrapNamedObject("NativeCode", dispatchAdapter));

            webView2.Source = new Uri("https://shan.tutorials.winui3/html/index.html");

        }
    }
}
