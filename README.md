# MultiTenantSystem

# First Step 
1. Clone the project
2. Change the connection string in appsetting.json
3. Run update migration cmd => dotnet ef database update --project MultiTenantSystem.Infrastructure --startup-project MultiTenantSystem.API
4. If dotnet tools not exist then run this => dotnet tool install --global dotnet-ef
5. Run number 3
6. Start the project


# Initial Login
Route => /api/Auth/login 
Default Login
{
  "email": "admin@global.com",
  "password": "Admin@123"
}

# Example API requests 
1. Tenant
    Route => /api/Tenant/CreateTenant
    {
        "name": "Example"
    }

    //
    Route => /api/Tenant/GetTenantById/{id}
    id: "3fa85f64-5717-4562-b3fc-2c963f66afa6"

    //
    Route => /api/Tenant/GetAllTenant

2. Tenant User
    Route => /api/TenantUser/addEdit
    {
        "tenantId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "email": "example@gmail.com",
        "password": "example@123"
    }

    //
    Router => /api/TenantUser/delete
    tenantId: "3fa85f64-5717-4562-b3fc-2c963f66afa6"

3. Tenant Login
    Route => /api/Auth/login
    {
        "tenantId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "email": "example@gmail.com",
        "password": "example@123"
    }

4. Employee
    Route => /api/Employee/CreateEmployee
    {
        "fullName": "John",
        "email": "john@gmail.com",
        "position": "Developer",
        "address": "USA",
        "contactNo": "+1 202-555-0143"
    }

    //
    Route => /api/Employee/GetAllEmployee

    //
    Route => /api/Employee/YpdateEmployee/{id}
    id: "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    {
        "fullName": "John Doe",
        "email": "doe@gmail.com",
        "position": "Developer",
        "address": "USA",
        "contactNo": "+1 202-555-0143"
    }

    //
    Router => /api/Employee/DeleteEmployee/{id}
    id: "3fa85f64-5717-4562-b3fc-2c963f66afa6"