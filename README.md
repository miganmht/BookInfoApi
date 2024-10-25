# Taghche Book Info API

Taghche is a platform designed for reading books, and this project provides an API for displaying book information. It allows users to fetch details about various books and supports caching mechanisms to enhance performance.

## Features

- **Fetch Book Information**: The API provides an endpoint to retrieve details about a specific book using its ID.
- **Caching**: Implements caching strategies using Redis and in-memory caching to improve response times and reduce database load.

## API Endpoints

### POST /api/book

- **Description**: Fetches information about a book based on its ID.
- **Request Body**:
    ```json
    {
        "id": "string"  // The ID of the book
    }
    ```
- **Response**:
    - On success, returns details about the book.
    - On failure, returns an appropriate error message.

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- Docker
- Docker Compose

### Running the Application

1. Clone the repository:
    ```bash
    git clone <repository-url>
    cd TaghcheBookInfo
    ```

2. Build and run the application using Docker:
    ```bash
    docker-compose up --build
    ```
    or
    ```bash
    docker compose up -d
    ```

3. Access the API at `http://localhost:5000/api/book/{id}`.

## Environment Variables

- `CACHE_INMEMORY_PERIOD`: Duration for in-memory cache expiration (in minutes).
- `CACHE_REDIS_PERIOD`: Duration for Redis cache expiration (in minutes).

## Testing

- To be implemented. Unit tests will be added in future updates.


