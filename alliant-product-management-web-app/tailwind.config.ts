import type { Config } from "tailwindcss";
import { heroui } from "@heroui/react";

export default {
  content: [
    "./src/pages/**/*.{js,ts,jsx,tsx,mdx}",
    "./src/components/**/*.{js,ts,jsx,tsx,mdx}",
    "./src/app/**/*.{js,ts,jsx,tsx,mdx}",
    "./node_modules/@heroui/theme/dist/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {},
  },
  darkMode: "class",
  plugins: [
    heroui({
      themes: {
        light: {
          colors: {
            focus: {
              DEFAULT: "rgb(0, 174, 239)",
            },
            primary: {
              DEFAULT: "#005b9f",
              "50": "rgba(255, 255, 255, 0.5)",
              "100": "rgb(207, 244, 255)",
              "200": "rgb(86, 209, 255)",
              "300": "rgb(0, 174, 239)",
              "400": "rgb(3, 117, 176)",
              "500": "rgb(0, 91, 159)",
              "600": "rgb(0, 91, 159)",
              "700": "rgb(0, 91, 159)",
              "800": "rgb(0, 0, 0)",
              "900": "rgb(40, 41, 54)",
            },
            secondary: {
              DEFAULT: "rgb(255, 221, 0)",
            },
          },
        },
      },
    }),
  ],
} satisfies Config;
