module.exports = {
  css: {
    loaderOptions: {
      scss: {
        prependData: `@import "@/sass/main.scss";`,
      },
    },
  },
  devServer: {
    proxy: 'http://localhost:49822',
  },
};
