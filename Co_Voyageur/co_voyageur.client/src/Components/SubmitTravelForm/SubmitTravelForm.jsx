import React from 'react';
import './SubmitTravelForm.css';
const SubmitTravelForm = () => {
    return (
        <>
        <section className='travel__container'>
            <form>
                <h1>Proposer un trajet</h1>
                    <input type="text" required placeholder="Départ"  title="Ville de départ"/>
                    <input type="time" required placeholder="Heure de départ" title="Heure de départ"/>
                    <input type="text" required placeholder="Arrivée"  title="Ville d'arrivée"/>
                    <input type="time" required placeholder="Heure d'arrivée"  title="Heure d'arrivée"/>
                    <input type="number" required placeholder="Prix (€)"  title="Prix"/>
                    <button>En route !</button>
            </form>
        </section>
        </>
    );
};

export default SubmitTravelForm;