module.exports = {
  baseUrl: process.env.NODE_ENV === 'production' ? './' : '/',
  chainWebpack: config => {
    config.module.rules.delete('eslint');
  },
  devServer: {
    host: '0.0.0.0',
    port: 8080,
    disableHostCheck: true
  }
}