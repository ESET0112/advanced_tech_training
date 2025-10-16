// components/Layout/Layout.jsx
import React from 'react'
import Navbar from '../navbar/Navbar'
import Sidebar from '../sidebar/Sidebar'

export default function Layout({ children }) {
  return (
    <div className="h-full w-full flex flex-col">
      {/* Navbar - 10% height */}
      <div className="h-[10%] w-full">
        <Navbar />
      </div>

      {/* Main Content Area with Sidebar - 90% height */}
      <div className="h-[90%] w-full flex">
        {/* Sidebar - 20% width */}
        <div className="w-1/5 bg-gray-100 border-r border-gray-300">
          <Sidebar />
        </div>

        {/* Main Content - 80% width */}
        <div className="w-4/5 p-6 overflow-auto">
          {children}
        </div>
      </div>
    </div>
  )
}