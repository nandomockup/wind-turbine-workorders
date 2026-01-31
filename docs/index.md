# Wind Turbine Work Orders API Documentation

**Repository:** [wind-turbine-workorders](https://github.com/nandomockup/wind-turbine-workorders)
**Last Updated:** 2026-01-31 02:12:30 UTC

> This documentation is automatically generated using AI whenever the API code changes.

---

## Update: 2026-01-31 02:12:30 UTC

**Changed Files:**
- `WindTurbineWorkOrders/Controllers/WorkOrdersController.cs`

# Wind Turbine Work Orders API - Change Log

## Overview
This update introduces a basic Work Orders Management System for wind turbines, implementing core functionality for retrieving work order information. The system provides REST endpoints to:
- List all work orders across the wind farm
- Look up specific work orders by their unique number

**Business Impact:**
- Enables maintenance teams to track work orders digitally
- Provides centralized visibility into turbine maintenance status
- Facilitates better maintenance scheduling and tracking

## API Endpoints

### 1. Get All Work Orders
```
GET /api/workorders
```

**Purpose:**  
Retrieves a complete list of work orders in the system.

**Parameters:**  
None

**Response Example:**
```json
[
  {
    "workOrderNumber": "WTWO-0001",
    "turbineId": "TURB-001",
    "description": "Maintenance for wind turbine 1",
    "status": "Closed"
  },
  {
    "workOrderNumber": "WTWO-0002",
    "turbineId": "TURB-002",
    "description": "Maintenance for wind turbine 2",
    "status": "Open"
  }
]
```

**Error Responses:**
- `500 Internal Server Error` - Server-side processing error

### 2. Get Work Order by Number
```
GET /api/workorders/{workOrderNumber}
```

**Purpose:**  
Retrieves details for a specific work order.

**Parameters:**
- `workOrderNumber` (string, required) - Format: WTWO-XXXX

**Response Example:**
```json
{
  "workOrderNumber": "WTWO-0001",
  "turbineId": "TURB-001",
  "description": "Maintenance for wind turbine 1",
  "status": "Closed"
}
```

**Error Responses:**
- `404 Not Found` - Work order number doesn't exist
- `500 Internal Server Error` - Server-side processing error

## Data Models

### WorkOrder
```csharp
public class WorkOrder
{
    public string WorkOrderNumber { get; set; }  // Format: WTWO-XXXX
    public string TurbineId { get; set; }        // Format: TURB-XXX
    public string Description { get; set; }
    public string Status { get; set; }           // Values: "Open" or "Closed"
}
```

**Relationships:**
- Each WorkOrder is associated with one Turbine (via TurbineId)

## Business Logic

### Work Order Status Rules
- Work orders can be either "Open" or "Closed"
- System currently uses a simple alternating status based on even/odd work order numbers

### Identifier Formats
- Work Order Numbers: WTWO-XXXX (4-digit sequence)
- Turbine IDs: TURB-XXX (3-digit sequence)

## Database Changes
Currently using in-memory collection for demonstration. No database implementation yet.

**Future Considerations:**
- Implement persistent storage
- Add proper database tables for WorkOrders and Turbines
- Include audit trails for status changes

## Usage Examples

### Querying All Work Orders
```csharp
var client = new HttpClient();
var response = await client.GetAsync("https://api.windturbines.com/api/workorders");
var workOrders = await response.Content.ReadFromJsonAsync<List<WorkOrder>>();
```

### Looking Up a Specific Work Order
```csharp
var client = new HttpClient();
var response = await client.GetAsync("https://api.windturbines.com/api/workorders/WTWO-0001");
var workOrder = await response.Content.ReadFromJsonAsync<WorkOrder>();
```

## Notes
- Current implementation uses in-memory storage
- Authentication/Authorization not yet implemented
- Consider adding filtering and pagination for large datasets
- Status tracking workflow needs to be expanded for real-world scenarios
