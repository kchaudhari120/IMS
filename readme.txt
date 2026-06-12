login Admin:-
admin@test.com
Admin@123

{
  "email": "admin@test.com",
  "password": "Admin@123"
}

Create Supplier
{
  "supplierName": "ABC Electronics",
  "contactPerson": "John",
  "email": "john@abc.com",
  "phone": "9876543210",
  "address": "Mumbai"
}


product=>
{
  "name": "Dell Laptop",
  "description": "Dell Inspiron 15",
  "price": 55000,
  "categoryId": 5,
  "supplierId": 2
}
OUTPUT
{
    "id": 1,
    "name": "Dell Laptop",
    "description": "Dell Inspiron 15",
    "price": 55000,
    "categoryName": "Electronics",
    "supplierName": "ABC Electronics",
    "currentStock": 0
  }