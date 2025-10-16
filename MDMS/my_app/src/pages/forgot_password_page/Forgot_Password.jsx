import React, { useState } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import Input from '../../components/input_form/Input'
import Button from '../../components/button/Button'

export default function Forgot_Password() {
  const navigate = useNavigate()
  const [email, setEmail] = useState('')

  const handleResetLink = () => {
    // Reset password logic
    
    
    // Navigate to Reset_Password page
    navigate('/Reset_Password')
  }

  const handleEmailChange = (e) => {
    setEmail(e.target.value)
  }

  return (
    <div className="w-2/3 justify-self-center p-40">
      <h1 className="text-2xl font-medium text-center mb-6">Forgot Password</h1>
      

      <div className="w-2/3 justify-self-center mx-auto">
        <Input
          type="email"
          name="email"
          placeholder="email"
          value={email}
          onChange={handleEmailChange}
          className="mb-6"
        />

        <div className="text-left mb-8">
          <Link to="/" className="text-blue-500 hover:text-blue-700 hover:underline text-lg">
            Login
          </Link>
        </div>

        <div className="text-center">
          <Button 
            onClick={handleResetLink} 
            className='border-2 border-black rounded-2xl pl-12 pr-12 pt-2 pb-2'
          >
            Send Reset Link
          </Button>
        </div>
      </div>
    </div>
  )
}