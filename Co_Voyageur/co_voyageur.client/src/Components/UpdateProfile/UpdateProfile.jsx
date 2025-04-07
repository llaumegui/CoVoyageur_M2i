import React, { useState } from 'react';
import './UpdateProfile.css';
const UpdateProfile = () => {
    const email = "J******@*********"
    const password = "*********"
    return (
    <>
    <div className='update-profile'>
        <span>Email:</span>
        <span>{email}</span>
        <button>Modifier</button>
        <span>Password:</span>
        <span>{password}</span>
        <button>Modifier</button>
    </div>
    </>
    );
};

export default UpdateProfile;