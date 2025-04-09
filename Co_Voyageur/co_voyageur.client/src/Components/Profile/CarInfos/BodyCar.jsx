import React from 'react';

const BodyCar = () => {
    const carExemple = {
        model: "Peugeot 208",
        capacity: 5,
        color: "Rouge",
        registration: "AB-123-CD"
    }
    return (
        <>
            <p id="info"><strong>Modèle:</strong> {carExemple.model}</p>
            <p id="info"><strong>Capacité:</strong> {carExemple.capacity} personnes</p>
            <p id="info"><strong>Couleur:</strong> {carExemple.color}</p>
            <p id="info"><strong>Immatriculation:</strong> {carExemple.registration}</p>
        </>
    );
};

export default BodyCar;