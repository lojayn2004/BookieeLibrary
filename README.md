# Bookiee API Documentation

## Overview
Bookiee is a library management system API that provides book cataloging, borrowing functionality, and user management. The API supports both admin and student roles with different levels of access.

## Authentication
The API uses JWT Bearer token authentication. Include the token in the Authorization header:

```
Authorization: Bearer <your-token>
```

## API Endpoints

### Authentication Endpoints

#### Register Admin
- **POST** `/api/auth/register/admin`
- Register a new admin user
- Requires security key for registration

#### Register Student
- **POST** `/api/auth/register/student`
- Register a new student user
- Requires university ID

#### Login
- **POST** `/api/auth/login`
- Authenticate and receive JWT token

#### Verify Student
- **PATCH** `/api/auth/verify/{studentEmail}`
- Verify student account

### Book Management

#### Public Book Endpoints
- **GET** `/api/books`
  - Get paginated list of books with filtering and sorting
- **GET** `/api/books/{isbn}`
  - Get specific book details by ISBN

#### Admin Book Endpoints
- **GET** `/api/admin/AdminBook`
  - Get books with admin details (pagination/filtering)
- **POST** `/api/admin/AdminBook`
  - Add new book (supports file upload for book picture)
- **PATCH** `/api/admin/AdminBook`
  - Update book information
- **GET** `/api/admin/AdminBook/{isbn}`
  - Get admin details for specific book
- **DELETE** `/api/admin/AdminBook/{isbn}`
  - Delete a book

### Category Management
- **GET** `/api/Category`
  - Get all categories
- **POST** `/api/Category`
  - Create new category
- **PUT** `/api/Category`
  - Update category
- **GET** `/api/Category/{CategoryId}`
  - Get specific category
- **DELETE** `/api/Category/{categoryId}`
  - Delete category

### Borrowing System
- **POST** `/api/borrow`
  - Borrow a book
- **POST** `/api/borrow/return`
  - Return a borrowed book




### Borrowing System
- **POST** `/api/borrow`
  - Borrow a book
- **POST** `/api/borrow/return`
  - Return a borrowed book
