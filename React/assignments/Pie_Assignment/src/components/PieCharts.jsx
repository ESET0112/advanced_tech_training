import { PieChart, Pie, Cell, Tooltip, Legend, ResponsiveContainer } from 'recharts';
import { useState, useEffect } from 'react';

const COLORS = ['#0088FE', '#00C49F', '#FFBB28', '#FF8042', '#8884D8'];

function PieCharts() {
    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    // Fetch data from JSON server
    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch('http://localhost:3001/products');
                if (!response.ok) {
                    throw new Error('Failed to fetch data');
                }
                const products = await response.json();
                setData(products);
                setLoading(false);
            } catch (err) {
                setError(err.message);
                setLoading(false);
                console.error('Error fetching data:', err);
            }
        };

        fetchData();
    }, []);

    // Calculate total sales for percentage calculation
    const totalSales = data.reduce((sum, product) => sum + product.sales, 0);

    // Format data for the pie chart with percentages
    const chartData = data.map(product => ({
        name: product.name,
        value: product.sales,
        percentage: totalSales > 0 ? ((product.sales / totalSales) * 100).toFixed(1) : 0
    }));

    if (loading) {
        return (
            <div style={{ 
                display: 'flex', 
                justifyContent: 'center', 
                alignItems: 'center', 
                height: '400px',
                fontSize: '18px',
                color: '#666'
            }}>
                📊 Loading product sales data...
            </div>
        );
    }

    if (error) {
        return (
            <div style={{ 
                display: 'flex', 
                justifyContent: 'center', 
                alignItems: 'center', 
                height: '400px',
                color: 'red',
                fontSize: '16px',
                flexDirection: 'column',
                gap: '10px'
            }}>
                ❌ Error loading chart data
                <div style={{ fontSize: '14px', color: '#666' }}>
                    Make sure json-server is running on port 3001
                </div>
                <button 
                    onClick={() => window.location.reload()}
                    style={{
                        padding: '8px 16px',
                        backgroundColor: '#0088FE',
                        color: 'white',
                        border: 'none',
                        borderRadius: '4px',
                        cursor: 'pointer'
                    }}
                >
                    Retry
                </button>
            </div>
        );
    }

    return (
        <div style={{ 
            width: '100%', 
            height: 500,
            padding: '20px',
            backgroundColor: 'white',
            borderRadius: '8px',
            boxShadow: '0 2px 10px rgba(0,0,0,0.1)'
        }}>
            <h2 style={{ 
                textAlign: 'center', 
                marginBottom: '30px',
                color: '#333',
                fontSize: '24px',
                fontWeight: '600'
            }}>
                Product Sales Distribution
            </h2>
            
            <ResponsiveContainer width="100%" height="80%">
                <PieChart>
                    <Pie
                        data={chartData}
                        cx="50%"
                        cy="50%"
                        labelLine={false}
                        label={({ name, percentage }) => `${name}: ${percentage}%`}
                        outerRadius={140}
                        innerRadius={60}
                        fill="#8884d8"
                        dataKey="value"
                        paddingAngle={2}
                    >
                        {chartData.map((entry, index) => (
                            <Cell 
                                key={`cell-${index}`} 
                                fill={COLORS[index % COLORS.length]} 
                                stroke="#fff"
                                strokeWidth={2}
                            />
                        ))}
                    </Pie>
                    <Tooltip 
                        formatter={(value) => [`${value} units`, 'Sales']}
                        labelFormatter={(name) => `Product: ${name}`}
                    />
                    <Legend 
                        verticalAlign="bottom" 
                        height={36}
                        iconType="circle"
                    />
                </PieChart>
            </ResponsiveContainer>
            
            <div style={{ 
                textAlign: 'center', 
                marginTop: '15px',
                color: '#666',
                fontSize: '14px'
            }}>
                Total Sales: {totalSales} units
            </div>
        </div>
    );
}

export default PieCharts;