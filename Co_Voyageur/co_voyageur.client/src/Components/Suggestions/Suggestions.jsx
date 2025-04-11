import React from 'react';
import SuggestionsJSON from './Suggestions.json';
import './Suggestions.css';
const Suggestions = () => {
        let maxSuggestions = 6;
        let suggestions =0;
        let tabOfCountrys = [];
        let randomIndex1 = Math.floor(Math.random() * SuggestionsJSON.length);
        let randomIndex2 = Math.floor(Math.random() * SuggestionsJSON.length);
    
        while(suggestions < maxSuggestions) {
            let randomIndex1 = Math.floor(Math.random() * SuggestionsJSON.length);
            let randomIndex2 = Math.floor(Math.random() * SuggestionsJSON.length);
            while (randomIndex2 === randomIndex1) {
                randomIndex2 = Math.floor(Math.random() * SuggestionsJSON.length);
            }
            const countryPair = `${SuggestionsJSON[randomIndex1].name} > ${SuggestionsJSON[randomIndex2].name}`;
            tabOfCountrys.push(countryPair);
            suggestions++;
        }
        
        return (
            <div className="suggestion">
                <h2 className="suggestion__title">Suggestions : </h2>
                {tabOfCountrys.map((country, index) => (    
                    <button key={index} className="suggestion__item">
                        {country}
                    </button>
                ))}
                <p>Vous pouvez cliquer sur une suggestion afin de compléter le formulaire automatiquement.</p>
            </div>
        );
};

export default Suggestions;