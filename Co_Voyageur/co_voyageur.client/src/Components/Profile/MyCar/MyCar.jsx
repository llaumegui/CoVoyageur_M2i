import React from 'react';
import '../Card.css';
const MyCar = () => {
    const car = {
        model: 'Toyota Corolla',
        capacity: 4,
        color: 'Blue',
        plate: 'AB-123-CD'
    };
    return (
        <div className='card'>
            <div className='card__header'>
                <h2 className='card__header-title'>Mon véhicule</h2>
                <button>+</button>
            </div>
            <div className='card__body'>
                <p>Marque: {car.model}</p>
                <p>Capacité: {car.capacity}</p>
                <p>Couleur: {car.color}</p>
                <p>Immatriculation: {car.plate}</p>
            </div>
            <div className='card__footer'>
                <button className='card__footer-button-edit'>Modifier</button>
            </div>
        </div>
    );
};

export default MyCar;