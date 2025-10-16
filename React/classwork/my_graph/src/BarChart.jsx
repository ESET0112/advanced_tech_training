import {BarChart,Bar,XAxis,YAxis,Legend,Tooltip,CartesianGrid} from 'recharts'
const data = [
    {month:"jan",sales:4000},
    {month:"feb",sales:3600},
    {month:"mar",sales:2000},
    {month:"apr",sales:6000},
    {month:"may",sales:5400},
]

function BarCharts(){
    return (
        <>
        <BarChart width = {500} height={300} data={data}> 
            <CartesianGrid strokeDasharray="3 3"/>
            <XAxis dataKey="month"/>
            <YAxis/>
            <Tooltip/>
            <Legend/>
            <Bar dataKey="sales" fill="#144"/>
        </BarChart>
        </>
    )
}
export default BarCharts;