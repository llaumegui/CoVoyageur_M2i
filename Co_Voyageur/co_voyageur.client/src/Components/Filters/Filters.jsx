import React from 'react';
import './Filters.css';
const Filters = () => {
    return (
        
        <div className='filters'>
            <input type="radio" id="lowest-price" name="filter" value="lowest-price" />
            <label for="lowest-price">Lowest Price</label>
            <input type="radio" id="soonest" name="filter" value="soonest" />
            <label for="soonest">Soonest</label>
            <input type="radio" id="max-passengers" name="filter" value="max-passengers" />
            <label for="max-passengers">Max passengers</label>
            
        </div>
    );
};

export default Filters;