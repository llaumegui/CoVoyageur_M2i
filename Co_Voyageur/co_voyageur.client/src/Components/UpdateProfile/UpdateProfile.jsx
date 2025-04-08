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
        <button className="update-button">Modifier</button>
        <span>Mot de passe:</span>
        <span>{password}</span>
        <button className="update-button">Modifier</button>
    </div>
    </>
    );
};

export default UpdateProfile;