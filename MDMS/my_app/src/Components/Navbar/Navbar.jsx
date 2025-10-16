import React from 'react'

export default function Navbar() {
  return (
    <div className="bg-gray-300 h-full flex items-center justify-between px-4">
      <div className="text-xl font-bold">
        MDMS
      </div>
      <button className="bg-transparent px-3 py-1 rounded border border-gray-400">
        en
      </button>
    </div>
  )
}