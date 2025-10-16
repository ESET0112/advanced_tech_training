ASSIGNMENT 1: Pie Chart with API Data

Objective: Create a Pie Chart that displays product sales data fetched from a JSON API server.
 
Tasks:
 
Explore Pie Chart in Recharts documentation and understand its usage
 
Create a db.json file in your project's parent folder with different products and their sales data
 
Install json-server globally and start the server
 
Use data fetching to get this JSON data and create a pie chart to visualize the product sales distribution
 
Commands you'll need:
 
npm install -g json-server
json-server --watch db.json --port 3001
 
Requirements:
 
JSON file should contain at least 5 different products with sales numbers
 
Use useEffect and fetch API to get the data
 
Display the pie chart with product names and sales percentages
 
Make sure the chart is properly styled and labeled
 
Example JSON structure:
 
json
{
  "products": [
    {"id": 1, "name": "Product A", "sales": 45},
    {"id": 2, "name": "Product B", "sales": 30}
  ]
}