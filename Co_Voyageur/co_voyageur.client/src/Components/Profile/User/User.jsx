import React from 'react';
import '../Card.css';
const User = () => {
    const user = {
        firstname: 'John',
        lastname: 'Doe',
        email: 'jdoe@mail.com',
        password: 'password123',
        phone: '1234567890',
    }
    return (
        <div className='card-large'>
            <div className='card-large__header'>
                <h2 className='card-large__header-title'>Mon Profil</h2>
            </div>
            <div className='card-large__body'>
                <p>Nom d'utilisateur: {user.firstname} {user.lastname}</p>
                <p>Email: {user.email}</p>
                <p>Mot de passe: {user.password}</p>
                <p>Téléphone {user.phone}</p>
            </div>
            <div className='card-large__footer'>
                <button className='card-large__footer-button-edit'>Modifier</button>
            </div>
        </div>
    );
};

export default User;