module.exports = {
  css: {
    loaderOptions: {
      scss: {
        prependData: `@import "@/sass/main.scss";`,
      },
    },
  },
};
