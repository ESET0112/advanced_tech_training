import React from 'react'
import { useState } from 'react';

import Security from '../security/Security';
import NotificationSettings from '../notification_settings/NotificationSettings';
import ZoneSettings from '../zoneSettings/ZoneSettings';

export default function Tab2() {
  const [activeTab, setActiveTab] = useState('zoneSettings');

    const tabClasses = (tabName) => 
        `flex-1 text-center cursor-pointer transition-all duration-300 py-3 ${
            activeTab === tabName 
                ? 'text-violet-600 font-bold border-b-2 border-violet-600' 
                : 'text-gray-600 hover:text-violet-500'
        }`;

    return (
        <div className='mt-8'>
            
            <div className='flex justify-between border-b-2 border-gray-300'>
                
                <div 
                    className={tabClasses('zoneSettings')}
                    onClick={() => setActiveTab('zoneSettings')}
                >
                    <h3 className='text-lg font-semibold'>Security</h3>
                </div>
                <div 
                    className={tabClasses('Notifications')}
                    onClick={() => setActiveTab('notifications')}
                >
                    <h3 className='text-lg font-semibold'>Notifications</h3>
                </div>
            </div>

            
            <div className='w-full mt-6'>

                {activeTab === 'zoneSettings' && (
                    <ZoneSettings/>
                )}

                {activeTab === 'notifications' && (
                    <NotificationSettings/>
                )}
            </div>
        </div>
    );
}
