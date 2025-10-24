import React from 'react'
import Button from '../../../components/button/Button'
import LineCharts from '../../../chart/LineChart'
import { FaRegClock } from "react-icons/fa6";

export default function Home() {
  return (
    <div>

      <div className='flex items-center justify-between'>
        <div>
          <div className='text-2xl font-bold mb-4'> Welcome , XYZ </div>
          <div className='mb-1'>As of Oct 5, 2025</div>
          <div>Zone : Bangalore North</div>
        </div>

        <div>
          <div className='mb-1'> Last Synced at 10:45 AM </div>
          <div>Data Source: Smart Meter #1023</div>
        </div>
      </div>


      <div className='flex items-center justify-between m-5'>
        <div className='text-2xl font-bold border-2 border-gray-500 p-12 rounded-xl w-72 h-52 flex flex-col items-center justify-center ml-8'>
          <div className="mb-4 w-12 h-12 flex items-center justify-center">
            <FaRegClock className="w-8 h-8" />
          </div>
          <div className='text-3xl'>256kWh</div>
        </div>
        <div className='text-2xl font-bold border-2 border-gray-500 p-12 rounded-xl w-72 h-52 flex flex-col items-center justify-center ml-8'>
          <div className="mb-4 w-12 h-12 flex items-center justify-center">
            <FaRegClock className="w-8 h-8" />
          </div>
          <div className='text-3xl'>1203 Due on 12 Oct</div>
        </div>
        <div className='text-2xl font-bold border-2 border-gray-500 p-12 rounded-xl w-72 h-52 flex flex-col items-center justify-center ml-8'>
          <div className="mb-4 w-12 h-12 flex items-center justify-center">
            <FaRegClock className="w-8 h-8" />
          </div>
          <div className='text-3xl'>Pending</div>
        </div>
      </div>

      <div className='flex items-center justify-between m-5'>
        <div className='text-2xl font-bold border-2 border-gray-500 p-12 rounded-xl w-72 h-52 flex flex-col items-center justify-center ml-8'>
          <div className="mb-4 w-12 h-12 flex items-center justify-center">
            <FaRegClock className="w-8 h-8" />
          </div>
          <div className='text-3xl'>Paid 1200 on 10 Sep</div>
        </div>
      </div>

      <div className='flex justify-between items-center mt-10'>
        <div className='font-bold text-xl'>
          Electricity consumption Overview
        </div>
        <div className="flex border border-gray-300 rounded-lg overflow-hidden">
          <Button className="px-6 py-2 bg-white hover:bg-gray-50 border-r border-gray-300 text-sm font-medium">
            Day
          </Button>
          <Button className="px-6 py-2 bg-white hover:bg-gray-50 border-r border-gray-300 text-sm font-medium">
            Week
          </Button>
          <Button className="px-6 py-2 bg-white hover:bg-gray-50 text-sm font-medium">
            Month
          </Button>
        </div>
      </div>
      <div>
        <LineCharts />
      </div>

      <div className='text-xl font-bold mb-4 text-left'> Quick Actions </div>
      <div className='flex justify-between'>
        <Button className='border-2 border-black rounded-2xl px-3 py-2 w-48'>Pay Bill</Button>
        <Button className='border-2 border-black rounded-2xl px-3 py-2 w-48'>View Bill History</Button>
        <Button className='border-2 border-black rounded-2xl px-3 py-2 w-48'>View Detailed Usage</Button>
        <Button className='border-2 border-black rounded-2xl px-3 py-2 w-48'>Manage Notifications</Button>
      </div>
    </div>
  )
}