import React, { useState } from 'react';
import Modal from '../../components/Modal/Modal';
import FormComponent from '../FormComponent/FormComponent';
import './UpdateProfile.css';
const UpdateProfile = () => {
    const email = "J******@*********"
    const password = "*********"
    const [isOpen, setIsOpen] = useState(false);
    return (
    <>
    <div className='update-profile'>
        <span>Email:</span>
        <span>{email}</span>
        <button className="update-button" onClick={() => setIsOpen(!isOpen)}>Modifier</button>
        {isOpen && <Modal closeModal={() => setIsOpen(!isOpen)}><FormComponent /></Modal>}
        <span>Mot de passe:</span>
        <span>{password}</span>
        <button className="update-button" onClick={() => setIsOpen(!isOpen)}>Modifier</button>
        {isOpen && <Modal closeModal={() => setIsOpen(!isOpen)}><FormComponent /></Modal>}
    </div>
    </>
    );
};

export default UpdateProfile;