import React, { useState } from 'react'; 
import { GoPencil } from "react-icons/go";
import Button from '../button/Button';
import Input from '../input_form/Input';
import { FaRegUser } from 'react-icons/fa';


export default function Profile() {
    const [formData, setFormData] = useState({
        name: '',
        email: '',
        mobile: ''
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

               
                <Button
                    onClick={() => console.log('Edit profile image')}
                    className="absolute -top-1 -right-1 bg-violet-600 text-white p-2 rounded-full hover:bg-violet-700 transition-all duration-200 transform hover:scale-110 focus:outline-none focus:ring-2 focus:ring-violet-500 focus:ring-offset-2"
                >
                    <GoPencil className="w-4 h-4" />
                </Button>
            </div>

            
            <div className="w-full max-w-md"> 
                <Input
                    type="text" 
                    name="name"
                    placeholder="Name"
                    value={formData.name}
                    onChange={handleChange}
                    className="mb-4 w-[60%]"
                />

                <Input
                    type="email"
                    name="email"
                    placeholder="Email"
                    value={formData.email}
                    onChange={handleChange}
                    className="mb-4 w-[60%]" 
                />
                
                <Input
                    type="tel" 
                    name="mobile"
                    placeholder="Mobile No."
                    value={formData.mobile}
                    onChange={handleChange}
                    className="mb-6 w-[60%]" 
                />

                <Button
                    //onClick={handleSave}
                    className='border-2 bg-black text-white rounded-2xl px-12 py-2 w-[60%] hover:bg-gray-800 transition-colors ' // Improved padding
                >
                    Save & Continue
                </Button>
            </div>
        </div>
    );
}