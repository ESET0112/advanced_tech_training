import React, { useState } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import Input from '../../components/input_form/Input'
import Button from '../../components/button/Button'

export default function Login({ onLogin }) {
  const navigate = useNavigate()
  const [formData, setFormData] = useState({
    email: '',
    password: ''
  })

  const handleLogin = () => {
    if (formData.email === "nil13.cs@gmail.com" && formData.password === "1234") {
      onLogin() // Triggers layout change in App.jsx
      navigate('/Home')
    } else {
      alert('Invalid email or password')
    }
  }

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    })
  }



  return (
    <div className="w-2/3 justify-self-center p-40">
      <h1 className="text-1xl font-medium text-center mb-2">LogIn Form</h1>

      <div className="w-2/3 justify-self-center ">
        <Input
          type="email"
          name="email"
          placeholder="email"
          value={formData.email}
          onChange={handleChange}
          className="mb-4"
        />

        <Input
          type="password"
          name="password"
          placeholder="password"
          value={formData.password}
          onChange={handleChange}
          className="mb-6"
        />

        <div className="flex justify-between items-center py-2">
          <div className='flex items-center'>
            <input type="checkbox" className="mr-2 w-4 h-4" />
            <p className="text-xl">Remember Me</p>
          </div>
          <div>
            <Link to="/Forgot_Password" className="text-blue-500 hover:text-blue-700 hover:underline text-xl">
              Forgot Password?
            </Link>
          </div>
        </div>

        <Button
          onClick={handleLogin}
          className='border-2 border-black rounded-2xl pl-12 pr-12 pt-2 pb-2'
        >
          login
        </Button>
      </div>
    </div>
  )
}