import React from 'react';
import NavBar from '../../Components/NavBar/NavBar';
import SubmitTravelForm from '../../Components/SubmitTravelForm/SubmitTravelForm';
import './SubmitTravelPage.css';
const SubmitTravelPage = () => {
    return (
        <>
            <NavBar/>
            <img src="\Images\backgroundSubmitTravel.png" alt="backgroundSubmitTravel" className='background-image-submit-travel' />
            <h2 className="title-submit-travel-page">Proposer un trajet</h2>
            <SubmitTravelForm/>
        </>
    );
};

export default SubmitTravelPage;