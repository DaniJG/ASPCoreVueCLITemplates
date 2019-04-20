module.exports = {
  configureWebpack: {
    // The URL where the .Net Core app will be listening.
    //    See https://cli.vuejs.org/config/#devserver-proxy and https://webpack.js.org/configuration/dev-server#devserverproxy
    // Instead of hardcoding something lile https://localhost:5001/,
    // read the ASPNET_URL environment variable, injected by VueDevelopmentServerMiddleware
    devServer: {
      // When running in IISExpress, the env variable wont be provided. Hardcode it here based on your launchSettings.json
      proxy: process.env.ASPNET_URL || 'https://localhost:44345'
    },
    // Use source map for debugging in VS and VS Code
    devtool: 'source-map',
    // Breakpoints in VS and VSCode wont work since the source maps conside clien-app the project root, rather than its parent folder
    output: {
      devtoolModuleFilenameTemplate: info => {
        const resourcePath = info.resourcePath.replace('./src', './ClientApp/src')
        return `webpack:///${resourcePath}?${info.loaders}`
      }
    }
  }
}
