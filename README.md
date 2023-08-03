# BlazorCRUD

This is a Blazor Webassembly App. Here are the steps to create a project :

1. Open Visual Studio, Search Blazor WebAssembly App , Select choose .Net Version and select option ASP.NET core hosted.
Now hosting model will create Blazor App with three projects :


blazerproject.Client
blazerproject.Server
blazerproject.Shared

The blazerproject.Client folder contains the code that is executed on the client's browser. This code is written in C# and compiled to WebAssembly.

The blazerproject.Server folder contains the code that is executed on the server. This code is responsible for handling requests from the client and rendering the Blazor UI.

The blazerproject.Shared folder contains code that is shared between the client and the server. This code is typically used to define models and services that are used by both the client and the server.


2. The Blazor WebAssembly hosting model is a way to run Blazor apps on the client using WebAssembly. WebAssembly is a new technology that allows compiled code to run in the browser. This means that Blazor WebAssembly apps can be as fast and responsive as native desktop apps.

When you use the Blazor WebAssembly hosting model, your Blazor app is compiled to WebAssembly and then delivered to the client as a set of static files. The client's browser then loads and executes the WebAssembly code, which renders the Blazor UI.

(a) The Blazor WebAssembly hosting model has several benefits:

Performance: Blazor WebAssembly apps can be very performant, especially for complex apps.
Cross-platform compatibility: Blazor WebAssembly apps can be run on any platform that supports WebAssembly, including Windows, macOS, Linux, and Android.
Scalability: Blazor WebAssembly apps can be scaled to handle a large number of users.

(b)However, there are also some drawbacks to using the Blazor WebAssembly hosting model:

Initial load time: The initial load time for Blazor WebAssembly apps can be longer than for Blazor Server apps.
Dependencies: Blazor WebAssembly apps require the WebAssembly runtime to be installed on the client's browser.

3. The client's browser loads the blazerproject.Client code from the web server. This code is compiled to WebAssembly and then executed in the browser. The WebAssembly code renders the Blazor UI and makes requests to the server.

The server receives requests from the client and handles them. The server then returns responses to the client. The responses are rendered by the WebAssembly code in the browser.


