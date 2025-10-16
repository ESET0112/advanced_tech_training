import React, { useState } from 'react'
import { Link } from 'react-router-dom'
import Input from '../../components/input_form/Input'
import Button from '../../components/button/Button'

export default function Reset_Password() {
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')

  const handleUpdatePassword = () => {
    // Add your update password logic here
    console.log('Update password:', { email, password })
  }

  return (
    <div className="w-2/3 justify-self-center p-40">
      <h1 className="text-1xl font-medium text-center mb-2">Reset Password</h1>

      <div className="w-2/3 justify-self-center ">
        <Input
          type="email"
          placeholder="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          className="mb-4"
        />

        <Input
          type="password"
          placeholder="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          className="mb-6"
        />

        <div className="flex justify-between items-center py-2">
          <div>
            <Link to="/" className="text-blue-500 hover:text-blue-700 hover:underline text-xl">
              Login
            </Link>
          </div>
        </div>

        <Button onClick={handleUpdatePassword} className='border-2 border-black rounded-2xl pl-12 pr-12 pt-2 pb-2'>
          Update Password
        </Button>
      </div>
    </div>
  )
}