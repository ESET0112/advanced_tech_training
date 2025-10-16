import { PieChart, Pie, Cell, Tooltip, Legend } from 'recharts';

const COLORS = ['#0088FE', '#00C49F', '#FFBB28', '#FF8042', '#8884D8'];

// Define the data array
const data = [
    { month: "jan", sales: 4000 },
    { month: "feb", sales: 3600 },
    { month: "mar", sales: 2000 },
    { month: "apr", sales: 6000 },
    { month: "may", sales: 5400 },
];

function PieCharts() {
    return (
        <PieChart width={500} height={300}>
            <Pie
                data={data}
                cx={200}
                cy={150}
                labelLine={false}
                label={({ month, sales }) => `${month}: ${sales}`}
                outerRadius={80}
                fill="#8884d8"
                dataKey="sales"
            >
                {data.map((entry, index) => (
                    <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
                ))}
            </Pie>
            <Tooltip />
            <Legend />
        </PieChart>
    );
}

export default PieCharts;