import React, { useState } from 'react';
const Filters = () => {
    const [selectedFilter, setSelectedFilter] = useState(null);
    const resetFilters = (event) => {
        setSelectedFilter(null);
    }
    //Appliquer ici le système de filtres (trier tableau en fonction de la ressource)
    return (
        <>
        <div className='filter'>
            <h2>Filtres</h2>
                <div className='filter__input'>
                    <input type="radio" className='filter__radio' id="lowest-price" name="filter" value="lowest-price" checked={selectedFilter === 'lowest-price'} onChange={(e)=>setSelectedFilter(e.target.value)}/>
                    <label for="lowest-price" className='filter__label' >Prix croissant</label>
                </div>
                <div className='filter__input'>
                    <input type="radio" className='filter__radio' id="soonest" name="filter" value="soonest" checked={selectedFilter === 'soonest'} onChange={(e)=>setSelectedFilter(e.target.value)}/>
                    <label for="soonest" className='filter__label'>Le plus tôt</label>
                </div>
                <div className='filter__input'>
                    <input type="radio" className='filter__radio' id="max-passengers" name="filter" value="max-passengers" checked={selectedFilter === 'max-passengers'} onChange={(e)=>setSelectedFilter(e.target.value)} />
                    <label for="max-passengers" className='filter__label'>Passagers décroissant</label>
                </div>
            <button className='card__footer-button-edit' onClick={resetFilters}>Effacer les filtres</button>   
        </div>
        </>
    );
};

export default Filters;