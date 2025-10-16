
import React from 'react'
import Input from '../Components/Input/Input'
import Button from '../Components/Button/Button'

export default function Login() {
  return (
    <div className='w-full justify-self-center p-40'>
        <h1 className='text-xl font-medium text-center mb-2'>Login Form</h1>
        <div className='justify-self-center '>
            <Input type='email' placeholder='email' className='mb-4'></Input>
            <Input type='password' placeholder='password' className='mb-4'></Input>

        </div>

        <div className='w-full flex justify-center '>
            <Button className='w-1/4 font-medium py-2 px-2 bg-blue-300 rounded-2xl'>Login</Button>
        </div>
        
    </div>
  )
}
