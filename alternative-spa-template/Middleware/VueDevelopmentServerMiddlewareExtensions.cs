// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SpaServices;
using System;

namespace VueSPATemplate.Middleware
{
    /// <summary>
    /// Extension methods for enabling React development server middleware support.
    /// </summary>
    public static class VueDevelopmentServerMiddlewareExtensions
    {
        /// <summary>
        /// Starts a Vue development server and waits before proceeding with any request for the server to be started
        /// Once started, redirects "/" requests to the Vue development server root URL.
        /// This way you can start the ASP.NET Core project in development, which will take care of starting the
        /// Vue development server.
        ///
        /// This feature should only be used in development!r.
        /// </summary>
        /// <param name="appBuilder">The <see cref="IApplicationBuilder"/>.</param>
        /// <param name="sourcePath">The path to the Vue app from the project root. Defaults as "ClientApp"</param>
        /// <param name="npmScript">The name of the script in your package.json file that launches the Vue app. Defaults as "serve".</param>
        public static void UseVueDevelopmentServer(
            this IApplicationBuilder appBuilder,
            string sourcePath = "ClientApp",
            string npmScript = "serve")
        {
            if (appBuilder == null)
            {
                throw new ArgumentNullException(nameof(appBuilder));
            }

            VueDevelopmentServerMiddleware.Attach(appBuilder, sourcePath, npmScript);
        }
    }
}