# Taghche Book Info API

Taghche is a platform designed for reading books, and this project provides an API for displaying book information. It allows users to fetch details about various books and supports caching mechanisms to enhance performance.

## Features

- **GET Endpoint**: Allows users to retrieve book information by sending a book ID.
- **Caching**: Implements in-memory and Redis caching to improve response times and reduce load on the database.

## API Endpoint

### Get Book Information

- **Endpoint**: `GET /api/book/{id}`
- **Description**: Retrieves information about a book given its ID.
- **Parameters**:
  - `id` (string): The unique identifier for the book.
  - 
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


