const Input = ({ type, placeholder, className = '' }) => {
    return (
        <input
            type={type}
            placeholder={placeholder}
            className={`w-full px-4 py-2 bg-gray-300 rounded-2xl focus:ring-2 
      focus:ring-blue-500 focus:bg-white ${className}`}>
        
        </input>
    )
}

export default Input;