# GalaxyApp API - .NET Backend Application


## 📌 Project Overview
GalaxyApp is a backend .NET API designed to manage a large electronics store. The system handles the entire supply chain, from purchasing products in bulk to managing inventory, sales, and customer transactions.

### Key Features:
- **Product Management**: Add, update, delete, and manage products in the store.
- **Inventory Control**: Products are added to the warehouse when bulk purchases are made from suppliers.
- **Account Types**: Users can be assigned roles (Manager, Seller, Owner) with varying access permissions.
- **Sales Transactions**: Generate invoices for customer purchases and wholesale transactions with suppliers.
- **Warehouse & Store Operations**: Manage the movement of products between the warehouse and the retail store.

### Roles & Permissions:
- **Manager**: Manages inventory, products, and orders.
- **Seller**: Handles customer transactions and sales.
- **Owner**: Has full control over all operations, including user management.

### API Endpoints:
- **Product Management**: Add, update, delete, and view products.
- **Inventory Operations**: View and update product stock levels, including purchases from suppliers.
- **Sales & Invoicing**: Create invoices for customer purchases and bulk orders.
- **Role-based Access Control**: Enforce different access levels based on user roles.

## 🛠️ Technologies Used
- **Backend Framework**: .NET
- **Database**: SQL Server
- **Authentication**: JWT Token-based authentication for secure access
- **Architecture**: RESTful API

## 🚀 Setup and Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/EslamAymann22/GalaxyApp.APIs.git
