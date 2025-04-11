import React from 'react';
const SearchBar = () => {
    return (
        <>
        <section className="section-search">
            <div className="search-bar-container">
                <input type="text" placeholder="Départ" className="search-bar-from" />
                <input type="text" placeholder="Arrivée" className="search-bar-to" />
                <input type="date" className="search-bar-date" />
                <input type="number" placeholder="Nombre de passagers" className="search-bar-passengers" min="1" max="8" />
                <button className="search-bar-button">Rechercher</button>
            </div>
        </section>
        </>
    );
};

export default SearchBar;