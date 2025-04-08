import React, { useState } from 'react';
import './Filters.css';
const Filters = () => {
    const [selectedFilter, setSelectedFilter] = useState(null);
    const resetFilters = (event) => {
        setSelectedFilter(null);
    }
    return (
        <>
        
        <div className='filters'>
            <h2 className='filter-title'>Filtres</h2>

            <div>
                <input type="radio" className='input-radio' id="lowest-price" name="filter" value="lowest-price" checked={selectedFilter === 'lowest-price'} onChange={(e)=>setSelectedFilter(e.target.value)}/>
            </div>
            <label for="lowest-price" >Lowest Price</label>
<hr />
            <div>
                <input type="radio" className='input-radio' id="soonest" name="filter" value="soonest" checked={selectedFilter === 'soonest'} onChange={(e)=>setSelectedFilter(e.target.value)}/>
            </div>
            <label for="soonest">Soonest</label>
            <hr />
            <div>
                <input type="radio" className='input-radio' id="max-passengers" name="filter" value="max-passengers" checked={selectedFilter === 'max-passengers'} onChange={(e)=>setSelectedFilter(e.target.value)} />
                
            </div>
            <label for="max-passengers">Max passengers</label>
            <button className='reset-button' onClick={resetFilters}>Effacer les filtres</button>
            
        </div>
        </>
    );
};

export default Filters;