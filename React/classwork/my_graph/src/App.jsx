import LineCharts from './LineChart';
import BarCharts from './BarChart';  // Relative import with correct path
import PieCharts from './PieChart';

function App() {
  return (
    <div className="App">
      <h1>Sales Data</h1>
      <BarCharts />
      <LineCharts/>
      <PieCharts/>
    </div>
  );
}

export default App;