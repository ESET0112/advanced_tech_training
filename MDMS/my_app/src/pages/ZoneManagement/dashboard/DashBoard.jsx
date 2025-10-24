import React from 'react'
import Button from '../../../components/button/Button'
import LineCharts from '../../../chart/LineChart'
import { TbActivityHeartbeat } from "react-icons/tb";
import { FiAlertOctagon } from "react-icons/fi";
import { FaArrowTrendUp } from "react-icons/fa6";

export default function DashBoard() {
  return (
    <div>
      <div className='flex items-center justify-between'>
        <div className='text-2xl font-bold mb-4'> Zone Dashboard </div>
      </div>

      <div className='flex items-center justify-between m-5'>
        <div className='text-2xl font-bold border-2 border-gray-500 p-12 rounded-xl w-72 h-52 flex flex-col items-center justify-center ml-8'>
          <div className="mb-4 w-12 h-12 flex items-center justify-center">
            <TbActivityHeartbeat className="w-8 h-8" />
          </div>
          <div className='text-3xl'>256</div>
          <div className='text-lg mt-2'><h2>Active Meters</h2></div>
        </div>
        <div className='text-2xl font-bold border-2 border-gray-500 p-12 rounded-xl w-72 h-52 flex flex-col items-center justify-center ml-8'>
          <div className="mb-4 w-12 h-12 flex items-center justify-center">
            <FaArrowTrendUp className="w-8 h-8" />
          </div>
          <div className='text-3xl'>55%</div>
          <div className='text-lg mt-2'><h2>Avg Usage</h2></div>
        </div>
        <div className='text-2xl font-bold border-2 border-gray-500 p-12 rounded-xl w-72 h-52 flex flex-col items-center justify-center ml-8'>
          <div className="mb-4 w-12 h-12 flex items-center justify-center">
            <FiAlertOctagon className="w-8 h-8" />
          </div>
          <div className='text-3xl'>26</div>
          <div className='text-lg mt-2'><h2>Pending Alert</h2></div>
        </div>
      </div>

      <div className='flex justify-between items-center mt-10'>
        <div className='font-bold text-xl'>
          Analytics Chart
        </div>
        <div className="flex border border-gray-300 rounded-lg overflow-hidden">
          <Button className="px-6 py-2 bg-white hover:bg-gray-50 border-r border-gray-300 text-sm font-medium">
            Week
          </Button>
          <Button className="px-6 py-2 bg-white hover:bg-gray-50 text-sm font-medium">
            Month
          </Button>
        </div>
      </div>
      <div className='w-full'>
        <LineCharts width={1000} height={400} />
      </div>

      <div className='flex'>
        <Button className='border-2 border-black rounded-2xl px-3 py-2 w-48 ml-10 mr-10'>Add meter</Button>
        <Button className='border-2 border-black rounded-2xl px-3 py-2 w-48 ml-10 mr-10'>Generate Report</Button>
      </div>
    </div>
  )
}