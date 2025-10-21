import React, { useState } from 'react'; 
import { GoPencil } from "react-icons/go";
import Button from '../button/Button';
import Input from '../input_form/Input';
import { FaRegUser } from 'react-icons/fa';


export default function Security() {
    const [formData, setFormData] = useState({
        current_password: '',
        new_password: '',
        confirm_password: ''
    });

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value
        });
    };

    return (
        <div className="flex flex-col items-center p-8"> 
           
            <div className="relative inline-block mb-8"> 
                <div className="flex justify-center items-center w-24 h-24 bg-gray-800 rounded-full"> {/* Added background */}
                    <FaRegUser className="text-7xl text-gray-600 " color='white'/>
                </div>

            </div>

            
            <div className="w-full max-w-md"> 
                <Input
                    type="password" 
                    name="current_password"
                    placeholder="Current Password"
                    value={formData.current_password}
                    onChange={handleChange}
                    className="mb-4 w-[60%]"
                />

                <Input
                    type="password"
                    name="new_password"
                    placeholder="New Password"
                    value={formData.new_passwordl}
                    onChange={handleChange}
                    className="mb-4 w-[60%]" 
                />
                
                <Input
                    type="password" 
                    name="confirm_password"
                    placeholder="Confirm Password"
                    value={formData.confirm_password}
                    onChange={handleChange}
                    className="mb-6 w-[60%]" 
                />

                <Button
                    //onClick={handleSave}
                    className='border-2 bg-black text-white rounded-2xl px-12 py-2 w-[60%] hover:bg-gray-800 transition-colors ' 
                >
                    Save & Continue
                </Button>
            </div>
        </div>
    );
}