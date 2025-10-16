import { BrowserRouter } from 'react-router-dom'
import Navbar from './Components/Navbar/Navbar'
import Login from './Pages/Login'

function App() {
  return (
    <BrowserRouter>
    <div className='h-full w-full flex flex-col'>
      <div className="h-[10%] w-full">
        <Navbar />
      </div>
      <div className='h-[90%] w-full pt-20'>
        <Login/>
      </div>

    </div>
      
    </BrowserRouter>
  )
}

export default App