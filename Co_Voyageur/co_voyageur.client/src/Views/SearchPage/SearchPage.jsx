import React from 'react';
import SearchBar from '../../Components/SearchBar/SearchBar.jsx';
import NavBar from '../../Components/NavBar/NavBar.jsx';
import './SearchPage.css';
import BackgroundBlob from '../../Components/BackgroundBlob/BackgroundBlob.jsx';
import Suggestions from '../../components/Suggestions/Suggestions.jsx';
const SearchPage = () => {
    return (
        <>
            <NavBar></NavBar>
            <BackgroundBlob/>
            <div className='SearchBar-container'>
            <SearchBar></SearchBar>
            </div>
            <div className="container">
            <h2 className="suggestions-title">Suggestions : </h2>
            <Suggestions/>
            </div>
        </>
    );
};

export default SearchPage;