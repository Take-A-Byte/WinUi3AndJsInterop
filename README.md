# WinUi3AndJsInterop
This project demonstrates how we can inject a native object in javascript. This gives us ability take advantage of native Windows capabilities while executing a function in javascript.

The commits in the repository will guide you through the process of injecting step by step.

## Project Summaries
- **WinUi3AndJsInterop**: This is main application project in which we will use WebView2 control to host a local web page. This web page will use JavaScript to call native code.

- **NativeCode**: This project will be home for the code which needs to be accessed from JavaScript. In our case it is the `Add` function.

- **NativeAdapter**: This is an sort-of-empty project; empty in the sense that we will not be adding any code manually in this project. Instead the project will use the `wv2winrt` tool provided by Microsoft with WebView2 to generate code needed for accessing the native code in JavaScript.

> **Note**
> **I will soon be writing a blog about this to explain everything in detail. So stay tuned!**

## Steps Summary
1. Add a WinUI3 project - `WinUi3AndJsInterop` - [goto commit](https://github.com/Take-A-Byte/WinUi3AndJsInterop/commit/939659323c4d794ea6d2893430dde1d312afe31b)

2. Add `WebView2` control to `MainWindow` and host local `index.html` - [goto commit](https://github.com/Take-A-Byte/WinUi3AndJsInterop/commit/d146966f978c327aa86bb6e6d44c64d202685953)

> **Note**
> Unlike legacy WebView, We need to add a virtual host mapping to the local folder containing `index.html` in `WebView2` for it to be able to access local files.

3. Add a C++/WinRT project - `NativeCode`. Add code that needs to be accessed from JavaScript. In our case - Add class containing `Add` function - [goto commit](https://github.com/Take-A-Byte/WinUi3AndJsInterop/commit/a0ec0c659c913b9d4b2c291eb35d102677454fe1)

> **Warning** 
> Ensure that the same target framework is selected for all the projects.

4. Add another C++/WinRT project - `NativeAdapter` - [goto commit](https://github.com/Take-A-Byte/WinUi3AndJsInterop/commit/6b5738edcfb292180f9448435f090a2342257da7)

5. Add Windows Implementation Library and WebView2 NuGet packages to NativeAdapter project - [goto commit](https://github.com/Take-A-Byte/WinUi3AndJsInterop/commit/7521a992edd91bd605b4acf36f123aeab085d7ce)

6. Add `NativeCode` project reference to `NativeAdapter` project and update its properties to use `wv2winrt` tool - [goto commit](https://github.com/Take-A-Byte/WinUi3AndJsInterop/commit/1d1ac1756d7738816b9e6d675f45a3ec720bf233)

7. Add CSWinRT NuGet package reference to `WinUi3AndJsInterop` project to be able to reference WinRT project in Win32-WinUI3 project - [goto commit](https://github.com/Take-A-Byte/WinUi3AndJsInterop/commit/fcef440af13200dd5c045ff8ecb39492b2418aa9)

8. Add reference of `NativeAdapter` project to `WinUi3AndJsInterop` project - [goto commit](https://github.com/Take-A-Byte/WinUi3AndJsInterop/commit/3dba46f53536ebaa1ee2b718b079682ae46d96dc)

9. Inject `NativeCode` object and call it from JavaScript - [goto commit](https://github.com/Take-A-Byte/WinUi3AndJsInterop/commit/fb09dae0fb2135c6040434fb9cde8236b8107e8b)
