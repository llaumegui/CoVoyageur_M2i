import React from 'react';
import './HelloUser.css';
const HelloUser = () => {
    const username = "John Doe";
    return (
        <>
        <div className='hello-user'>
            <p>Hello {username}</p>
            <img src="https://picsum.photos/50" alt="randompic" className='random-image' />
        </div>
            
        </>
    );
};

export default HelloUser;