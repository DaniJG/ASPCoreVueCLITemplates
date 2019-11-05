# Separated frontend and backend projects
This approach keeps the ASP.NET Core and Vue.js applications separately.
Developers will independently start each application and can use different tooling/editors/debuggers with each.

During development, you still ca use the same domain to access both frontend and backend side.
You just need to setup a proxy in one of the 2 following ways:

- (Recommended) Add a `vue.config.js` file inside the frontend folder with the following contents in order to setup a proxy from the frontend Vue development server to the backend IISExpress/Kestrel server. Then use the Vue development server URL in your browser, and send requests to the backend API using the current domain.

      module.exports = {
        // The URL where the .Net Core app will be listening.
        // Specific URL depends on whether IISExpress/Kestrel and HTTP/HTTPS are used
        devServer: {
          proxy: 'https://localhost:5001'
        }
      }

- Add the `spa.UseProxyToSpaDevelopmentServer("http://localhost:8080/");` middleware to the backend application in order to setup a proxy from the backend to the frontend Vue development server. Then use the IISExpress/Kestrel URL in your browser, and send requests to the backend API using the current domain.
