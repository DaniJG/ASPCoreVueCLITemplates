module.exports = {
  configureWebpack: {
    // Use source map for debugging in VS and VS Code
    // devtool: 'source-map',
    // Breakpoints in VS and VSCode wont work since the source maps conside clien-app the project root, rather than its parent folder
    output: {
      devtoolModuleFilenameTemplate: info => {
        const resourcePath = info.resourcePath.replace('./src', './ClientApp/src')
        return `webpack:///${resourcePath}?${info.loaders}`
      }
    }
  }
}
