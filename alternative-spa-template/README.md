# Alterntive SPA template for Vue
Rather than a straight port of the React SPA template seen in the adapted-spa-template folder, 
this alternative template uses the Vue development server as the front server who will proxy API requests
to the ASP.NET Core server during development.

This gives a better performance since the hot reload web sockets dont need to be proxied.
It also avoids the [current issues](https://github.com/aspnet/AspNetCore/issues/7812) opening certain web sockets.

The ClientApp folder has been replaced with a Vue application initialized with the Vue CLI.
It is possible to replace its contents with any Vue app initialzed by the CLI selecting any options you like. You might want to keep the **vue.config.js** file if you want to debug Vue code from VSCode and/or VS.

The project is modified to expect Vue bundles on **ClientApp/dist** and to run `npm run serve` to start the Vue development server.

## How the React SPA middleware is adapted for this alternative Vue template
The Middleware folder contains the code needed to modify the `UseReactDevelopmentServer` SPA extension
so it uses the Vue development server as the main front server during development.

The extension and middleware have been renamed and the Middleware has been modified to:

- start the Vue development server on a free port
- pass the ASP.NET Core URL as an environment variable so the Vue dev server can use it as the proxy for API requests
- wait for the development server to be started before serving the request
- redirect "/" requests to the Vue development web server

Several utilities used by the React middleware to run npm scripts have been copied from Microsoft.AspNetCore.SpaServices.Extensions since they are internal.
