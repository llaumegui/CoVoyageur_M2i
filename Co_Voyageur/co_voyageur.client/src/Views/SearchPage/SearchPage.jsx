import React from 'react';
import SearchBar from '../../Components/SearchBar/SearchBar.jsx';
import NavBar from '../../Components/NavBar/NavBar.jsx';
import './SearchPage.css';
import BackgroundBlob from '../../Components/BackgroundBlob/BackgroundBlob.jsx';
import Suggestions from '../../Components/Suggestions/Suggestions.jsx';
const SearchPage = () => {
    return (
        <>
            <NavBar></NavBar>
            <BackgroundBlob/>
            <div className='SearchBar-container'>
            <SearchBar></SearchBar>
            </div>
            <Suggestions/>

        </>
    );
};

export default SearchPage;