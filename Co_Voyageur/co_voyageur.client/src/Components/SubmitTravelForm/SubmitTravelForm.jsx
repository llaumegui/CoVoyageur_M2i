import React from 'react';
const SubmitTravelForm = () => {
    return (
        <>
        <section className='section-form-style section-background-style-travel'>
            <form className='form-style'>
                <h1 className='submit-travel-form-title'>Proposer un trajet</h1>
                    <input type="text" required placeholder="Départ"  title="Ville de départ"/>
                    <input type="time" required placeholder="Heure de départ" title="Heure de départ"/>
                    <input type="text" required placeholder="Arrivée"  title="Ville d'arrivée"/>
                    <input type="time" required placeholder="Heure d'arrivée"  title="Heure d'arrivée"/>
                    <input type="number" required placeholder="Prix (€)"  title="Prix"/>
                    <button className="button-submit-style">En route !</button>
            </form>
        </section>
        </>
    );
};

export default SubmitTravelForm;