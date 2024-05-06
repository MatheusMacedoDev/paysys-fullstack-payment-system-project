import type { Config } from 'tailwindcss';

const config: Config = {
    content: [
        './src/pages/**/*.{js,ts,jsx,tsx,mdx}',
        './src/components/**/*.{js,ts,jsx,tsx,mdx}',
        './src/app/**/*.{js,ts,jsx,tsx,mdx}'
    ],
    theme: {
        colors: {
            green: {
                100: '#0D2D2A',
                200: '#13423E',
                600: '#069A59',
                700: '#2EBE7F',
                800: '#63F5B5',
                900: '#41E09A'
            },
            gray: {
                500: '#CED0CC',
                800: '#F3F7EE',
                900: '#FFFFFF'
            },
            red: '#E04638'
        },
        extend: {}
    },
    plugins: []
};
export default config;
