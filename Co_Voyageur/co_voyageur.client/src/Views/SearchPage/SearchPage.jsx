import React from 'react';
import SearchBar from '../../Components/SearchBar/SearchBar.jsx';
import './SearchPage.css';
import Suggestions from '../../components/Suggestions/Suggestions.jsx';
const SearchPage = () => {
    return (
        <>
            <NavBar></NavBar>
            <img src="\Images\CoVoyagerImageBackground03.webp" alt="ImageHero" className="hero"/>
            <SearchBar></SearchBar>
            <div className="container">
            <h2 className="suggestions-title">Suggestions : </h2>
            <Suggestions/>
            </div>
        </>
    );
};

export default SearchPage;