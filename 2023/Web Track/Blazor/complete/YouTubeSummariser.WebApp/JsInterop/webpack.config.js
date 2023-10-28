const path = require("path");

module.exports = {
  module: {
    rules: [
      {
        test: /\.js$/,
        exclude: /node_modules/,
        use: {
          loader: "babel-loader"
        }
      }
    ]
  },
  output: {
    path: path.resolve(__dirname, '../wwwroot/js'),
    filename: "bundle.js",
    library: "YouTube",
    libraryTarget: "window"
  }
};
