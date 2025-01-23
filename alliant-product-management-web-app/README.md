# Web App Documentation

## Project Overview

This is a **Web App** built with **Next.js** and React, designed to handle customer, product, and category management with integrated reporting. The app features secure login and registration functionality, allowing users to access various pages where they can manage customers, products, and categories. Each page includes relevant reports, and customers can be associated with products, along with setting prices and quantities.

The app is containerized using Docker, with the web server running on port `3000`.

## Features

- **Login & Register Pages**: Secure user authentication and registration.
- **Customer Management**: Add products to customers with price and quantity management.
- **Product & Category Management**: Administer products and categories, view related reports.
- **Reports**: Detailed reports on customers, products, and categories.
- **Dockerized**: The app is fully containerized using Docker for easy deployment.

## Technologies & Libraries Used

### Core Libraries

- **`@heroui/react`**: A React UI component library to help build intuitive and responsive user interfaces quickly.
- **`@hookform/resolvers`**: Provides validation resolvers for use with React Hook Form, enabling easy form validation.
- **`apexcharts`**: A modern charting library used to generate interactive and customizable charts for reporting.
- **`axios`**: A promise-based HTTP client for making API requests from the client-side.
- **`framer-motion`**: A powerful animation library that enables easy creation of animations and transitions in React applications.
- **`from`**: A lightweight library for handling asynchronous operations and working with reactive streams.
- **`iron-session`**: A simple session management library used for handling authentication and user sessions.
- **`lodash`**: A utility library that provides helpful functions for working with arrays, objects, and other data types.
- **`next`**: The framework used to build the app, offering server-side rendering, static site generation, and more.
- **`next-themes`**: A library to handle themes in the app, allowing for dynamic theme switching.
- **`react`**: The core JavaScript library for building the app's user interface.
- **`react-apexcharts`**: A React wrapper for the ApexCharts library, used to render charts with React components.
- **`react-dom`**: The React DOM package used to render the app on the web.
- **`react-hook-form`**: A library for handling forms in React with minimal re-renders and validation.
- **`react-toastify`**: A library for displaying toast notifications in React apps.
- **`zod`**: A TypeScript-first schema declaration and validation library used for input validation.
- **`zustand`**: A small and fast state management library for React, used to manage app-level state.

### Prerequisites

- Docker
- Node.js (v16 or later)
