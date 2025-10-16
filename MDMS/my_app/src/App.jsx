import React, { useState, useEffect } from 'react'
import './App.css'
import Navbar from './components/navbar/Navbar'
import Login from './pages/login_page/Login'
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Forgot_Password from './pages/forgot_password_page/Forgot_Password';
import Reset_Password from './pages/reset_password_page/Reset_Password';
import Home from './pages/home/Home';
import Layout from './components/Layout/Layout';
import BillTable from './pages/bills_payments/Bills';

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false)

  // If user was already logged in
  useEffect(() => {
    const loggedInStatus = sessionStorage.getItem('isLoggedIn')
    if (loggedInStatus === 'true') {
      setIsLoggedIn(true)
    }
  }, [])

  const handleLogin = () => {
    setIsLoggedIn(true)
    sessionStorage.setItem('isLoggedIn', 'true')
  }

  const handleLogout = () => {
    setIsLoggedIn(false)
    sessionStorage.removeItem('isLoggedIn')
  }

  return (
    <BrowserRouter>
      <div className="App h-screen w-screen">
        {isLoggedIn ? (
          // After login layout 
          <Layout onLogout={handleLogout}>
            <Routes>
              <Route path="/Home" element={<Home />} />
              <Route path="/Bills" element={<BillTable/>} />
              <Route path="/settings" element={<div>Settings Page</div>} />
              <Route path="/reports" element={<div>Reports Page</div>} />
              <Route path="*" element={<Home />} />
            </Routes>
          </Layout>
        ) : (
          // Before login layout
          <div className="h-full w-full flex flex-col">
            <div className="h-[10%] w-full">
              <Navbar />
            </div>
            <div className="h-[90%] w-full pt-20">
              <Routes>
                <Route path="/" element={<Login onLogin={handleLogin} />} />
                <Route path="/Forgot_Password" element={<Forgot_Password />} />
                <Route path="/Reset_Password" element={<Reset_Password />} />
              </Routes>
            </div>
          </div>
        )}
      </div>
    </BrowserRouter>
  )
}

export default App