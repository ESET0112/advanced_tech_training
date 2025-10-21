import React from 'react'
import ToggleButton from '../button/ToggleButton'
import Button from '../button/Button'

export default function NotificationSettings() {
    return (
        <div>
            <div className="flex flex-col items-center justify-center ">
                <div className="text-xl font-bold mb-8">
                    You can get Notifications from
                </div>
                <div className='flex flex-col'>
                    <div className='flex justify-between items-center w-80 mb-6'>
                        <div className="text-lg">Email</div>
                        <div><ToggleButton /></div>
                    </div>
                    <div className='flex justify-between items-center w-80 mb-6'>
                        <div className="text-lg">SMS</div>
                        <div><ToggleButton /></div>
                    </div>
                    <div className='flex justify-between items-center w-80 mb-6'>
                        <div className="text-lg">Push</div>
                        <div><ToggleButton /></div>
                    </div>
                </div>
                <div className="w-full max-w-md">
                    <Button
                        //onClick={handleSave}
                        className='border-2 bg-black text-white rounded-2xl px-12 py-2 w-[60%] hover:bg-gray-800 transition-colors ' // Improved padding
                    >
                        Save & Continue
                    </Button>
                </div>
            </div>
        </div>
    )
}
