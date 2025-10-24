import React from 'react'
import ToggleSelectButton from '../button/ToggleSelectButton'
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
                        <div><ToggleSelectButton /></div>
                    </div>
                    <div className='flex justify-between items-center w-80 mb-6'>
                        <div className="text-lg">SMS</div>
                        <div><ToggleSelectButton /></div>
                    </div>
                    <div className='flex justify-between items-center w-80 mb-6'>
                        <div className="text-lg">Push</div>
                        <div><ToggleSelectButton /></div>
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
