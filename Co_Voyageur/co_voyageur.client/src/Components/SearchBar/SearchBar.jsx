import React from 'react';
import './SearchBar.css';
const SearchBar = () => {
    return (
        <>
        <section className="search">
            <div className="search__container">
                <input type="text" placeholder="Départ" className="search__container-input"/>
                <input type="text" placeholder="Arrivée" className="search__container-input"/>
                <input type="date" className="search__container-input" />
                <input type="number" placeholder="Nombre de passagers" min="1" max="8" className="search__container-input" />
                <button>Rechercher</button>
            </div>
        </section>
        </>
    );
};

export default SearchBar;