import React from 'react';
import '../Card.css';
const Favorites = () => {
    // Pour chaque favoris ajouté afficher une carte favoris dans le body de cette carte
    return (
        <div className='card'>
        <div className='card__header'>
            <h2 className='card__header-title'>Trajets favoris</h2>
        </div>
        <div className='card__body'>
            {/* Afficher les cartes des favoris ici */}
        </div>
        <div className='card__footer'>
        </div>
    </div>
    );
};

export default Favorites;