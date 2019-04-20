# React SPA template adapted for Vue
This template adapts the official React SPA template to work with Vue.

> Software Ateliers has published a [Vue project template](https://github.com/SoftwareAteliers/asp-net-core-vue-starter) that is pretty much the same as the approach contained in this template. 

The ClientApp folder has been replaced with a Vue application initialized with the Vue CLI.
It is possible to replace its contents with any Vue app initialzed by the CLI selecting any options you like. You might want to keep the **vue.config.js** file if you want to debug Vue code from VSCode and/or VS.

The project is modified to expect Vue bundles on **ClientApp/dist** and to run `npm run serve` to start the Vue development server.

With this template, the ASP.NET Core server proxies requests to the Vue development server, including the hot reload modules.
This, apart from introducing unnecessary latency, [currently causes problems](https://github.com/aspnet/AspNetCore/issues/7812) with the hot reload web sockets.

Check the **alternate-spa-template** folder for a different template where proxying is done by the Vue development server instead!

## How the React SPA middleware is adapted for Vue
The Middleware folder contains the code needed to adapt the `UseReactDevelopmentServer` SPA extension to work with Vue.

The extension and middleware have been renamed and the Middleware has been modified to:

- specify the port for the Vue development server using the `--port` option
- wait until the Vue development server prints _DONE_ to the standard output

Several utilities used by the React middleware to run npm scripts have been copied from Microsoft.AspNetCore.SpaServices.Extensions since they are internal.
