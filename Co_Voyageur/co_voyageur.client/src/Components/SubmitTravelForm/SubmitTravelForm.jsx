import React, { useState } from 'react';
import './SubmitTravelForm.css';
const SubmitTravelForm = () => {


    return (
        <>
        <div className='submit-travel-form-container'>
            <form className='submit-travel-form'>
                <h2 className='submit-travel-form-title'>Trajet</h2>

                    <input type="text" required placeholder="Départ" className="input-travel-form"/>
                    <input type="text" required placeholder="Arrivée" className="input-travel-form"/>
                    <input type="number" required placeholder="Prix (€)" className="input-travel-form"/>
                    <input type="time" required placeholder="Heure de départ" className="input-travel-form"/>
                    <input type="time" required placeholder="Heure d'arrivée" className="input-travel-form"/>
                    <input type="number" required placeholder="Nombre de passagers" className="input-travel-form"/>
                    <h2 className='submit-vehicle-form-title'>Véhicule</h2>
                    <input type="text" required placeholder="Type" className="input-travel-form"/>
                    <input type="text" required placeholder="Immatriculation" className="input-travel-form"/>
                    <input type="text" required placeholder="Couleur" className="input-travel-form"/>
                    <button className="button-submit-travel-form">En route !</button>
            </form>
        </div>
        </>
    );
};

export default SubmitTravelForm;