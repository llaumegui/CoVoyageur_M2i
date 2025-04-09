import React from 'react';
import './HelloUser.css';
const HelloUser = () => {
    const username = "John Doe";
    return (
        <>
        <div className='hello-user'>
            <p className="hello">Hello {username}</p>
        </div>
            
        </>
    );
};

export default HelloUser;