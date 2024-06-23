/** @type {import('tailwindcss').Config} */
export default {
  content: [
    './index.html',
    './src/**/*.{js,ts,jsx,tsx}',
    'node_modules/flowbite-react/lib/esm/**/*.js',
  ],
  theme: {
    extend: {
      colors: {
        primary: '#F98311',
        secondary: '#414042',
        tertiary: '#FFFFFF'
      },
    },
  },
  plugins: [
    require('tailwindcss-animated'),
    require('flowbite/plugin'),
  ],
};
