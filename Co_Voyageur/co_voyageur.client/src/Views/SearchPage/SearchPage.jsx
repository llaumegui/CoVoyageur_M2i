import React from 'react';
import SearchBar from '../../Components/SearchBar/SearchBar.jsx';
import NavBar from '../../Components/NavBar/NavBar.jsx';
import Suggestions from '../../Components/Suggestions/Suggestions.jsx';
const SearchPage = () => {
    return (
        <>
            <NavBar></NavBar>
            <img src="\Images\CoVoyagerImageBackground03.webp" alt="ImageHero" className="hero"/>
            <SearchBar></SearchBar>
            <div>
            <Suggestions/>
            </div>

        </>
    );
};

export default SearchPage;