import React from 'react';

const BodyUser = () => {
    const userExemple = {
        firstname: "John",
        lastname: "Doe",
        email:"johndoe@exemple.com",
        password: "password123",
        phone: "0123456789",
    }
    return (
        <>
            <p id="info"><strong>Nom d'utilisateur:</strong> {userExemple.firstname} {userExemple.lastname}</p>
            <p id="info"><strong>Email:</strong> {userExemple.email}</p>
            <p id="info"><strong>Mot de passe:</strong> {userExemple.password}</p>
            <p id="info"><strong>Téléphone:</strong> {userExemple.phone}</p>
        </>
    );
};

export default BodyUser;