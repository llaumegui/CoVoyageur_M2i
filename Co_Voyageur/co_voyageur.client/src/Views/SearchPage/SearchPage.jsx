import React from 'react';
import SearchBar from '../../Components/SearchBar/SearchBar.jsx';
import NavBar from '../../Components/NavBar/NavBar.jsx';
import Suggestions from '../../Components/Suggestions/Suggestions.jsx';
const SearchPage = () => {
    return (
        <>
            <NavBar></NavBar>
            <img src="\Images\CoVoyagerImageBackground03.jpg" alt="ImageBackground" className="hero"/>
            <div className='SearchBar-container'>
            <SearchBar></SearchBar>
            </div>
            <Suggestions/>

        </>
    );
};

export default SearchPage;