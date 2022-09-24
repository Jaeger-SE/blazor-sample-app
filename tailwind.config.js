/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/Zwedze.Demo.Blazor.Web/**/*.razor", "./src/**/index.html"],
  theme:[],
  variants: {
    extend: {},
  },
  plugins: [
    require('tw-elements/dist/plugin')
  ],
}
