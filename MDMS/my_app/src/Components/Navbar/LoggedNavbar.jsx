import React from 'react'
import { IoMdNotificationsOutline } from "react-icons/io";
import { CgProfile } from "react-icons/cg";
import ToggleButton from '../button/ToggleButton';
import Button from '../button/Button';

export default function LoggedNavbar() {
  return (
    <div className="bg-gray-300 h-full flex items-center justify-between px-4">
      <div className="text-xl font-bold">
        MDMS
      </div>
      <div className='flex justify-between items-center p-4 gap-6'>
        <div>
          <Button>
            <IoMdNotificationsOutline className="text-3xl" />
          </Button>
          
        </div>
        <div>
          <ToggleButton/>
        </div>
        <div>
          <button className="bg-transparent px-3 py-1 rounded-xl border-2 border-gray-400">
          en ▼
        </button>
        </div>
        <div>
          <Button>
            <CgProfile className="text-3xl" />

          </Button>
          
        </div>
        

      </div>

    </div>
  )
}