# Alliant Products Management

## Overview

This project is a full-stack web application that consists of a **Frontend** built with **Next.js** and **React** and a **Backend API** developed with **.NET 9** and **PostgreSQL**. The web application allows users to manage **customers**, **products**, and **categories** while generating dynamic reports for each of these entities. Users can securely log in and register, and manage data associated with customers, including adding products with quantities and prices. The backend API is designed using **CQRS architecture** and provides a set of secure, efficient endpoints.

## Features

### Backend API

- **.NET 9** and **Entity Framework Core** for building the backend.
- **CQRS Architecture** for separating read and write concerns.
- **JWT Authentication** for securing API endpoints.
- **PostgreSQL Database** for data storage, running inside a Docker container.
- **Swagger UI** for API documentation and interactive testing.

### Web App

- **Next.js** and **React** for a modern, server-side rendered web application.
- **User Authentication**: Secure login and registration.
- **CRUD Operations** for managing **customers**, **products**, and **categories**.
- **Dynamic Reporting** and interactive **charts** using **ApexCharts**.
- **Fully Responsive UI** with **HeorUI** for a seamless user experience.

### Docker Compose

- The entire stack (Backend API, PostgreSQL, and Web App) is managed using **Docker Compose**.
- **Backend API** runs on **port 5000**.
- **PostgreSQL** is accessible on **port 5236**.
- **Web App** is available on **port 3000**.
- With **Docker Compose**, you can run the full stack with a single command, making it easy to deploy locally or in a cloud environment.

## Installation

### Prerequisites

- **Docker** and **Docker Compose** installed on your machine.
- **Internet access** to pull Docker images and dependencies.

### Steps

1. **Clone the repository**:
   ```bash
   git clone  https://github.com/AlamMena/alliant-product-management.git
   ```
2. \*\* Navigate to the project
   ```bash
   cd alliant-product-management
   ```
3. \*\* Build and run the entire stack with Docker Compose:
   ```bash
   docker-compose up --build
   ```
