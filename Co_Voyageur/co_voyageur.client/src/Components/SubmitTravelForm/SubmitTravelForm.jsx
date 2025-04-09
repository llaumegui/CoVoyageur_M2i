import React, { useState } from 'react';
import './SubmitTravelForm.css';
const SubmitTravelForm = () => {


    return (
        <>
        <div className='submit-travel-form-container'>
            <form className='submit-travel-form'>
                <h2 className='submit-travel-form-title'>Trajet</h2>
                    <input type="text" required placeholder="Départ" className="input-travel-form" title="Ville de départ"/>
                    <input type="text" required placeholder="Arrivée" className="input-travel-form" title="Ville d'arrivée"/>
                    <input type="number" required placeholder="Prix (€)" className="input-travel-form" title="Prix"/>
                    <input type="time" required placeholder="Heure de départ" className="input-travel-form" title="Heure de départ"/>
                    <input type="time" required placeholder="Heure d'arrivée" className="input-travel-form" title="Heure d'arrivée"/>
                    <button className="button-submit-travel-form button-submit-style">En route !</button>
            </form>
        </div>
        </>
    );
};

export default SubmitTravelForm;