import React from 'react'
import { IoMdNotificationsOutline } from "react-icons/io";

export default function NotifyCard() {
    return (
        <div className='flex justify-between rounded-2xl border-black border-2 mb-10 h-20'>
            <div className='justify-self-center  bg-white rounded-l-2xl w-[25%]  
                            overflow-hidden pt-5 pl-5'>
                <IoMdNotificationsOutline className="text-3xl" />
            </div>
            <div className='justify-self-center w-[75%]  bg-gray-200 rounded-r-2xl '>
                <div className='font-bold mb-2 mt-2'>
                    Title of Notification
                </div>
                <div className='mb-2 mt-2'>
                    Description of Notification
                </div>

            </div>
        </div>
    )
}
