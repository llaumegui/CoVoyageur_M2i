import React from 'react';
import '../Card.css';
const Review = () => {
    // Exemple de review, a adapter selon les données des reviews de l'utilisateur et connexion à la bdd
    return (
        <div className='card-large'>
            <div className='card-large__header'>
                <h2 className='card-large__header-title'>Mes avis</h2>
            </div>
            <div className='card-large__body'>
                <p>Nom d'utilisateur: DarkSasuke3000</p>
                <p>Commentaire: Agréable voyage </p>
                <p>Note: 5/5</p>
            </div>
            <div className='card-large__footer'>
            </div>
        </div>
    );
};

export default Review;