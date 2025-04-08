import React from 'react';
import NavBar from '../../Components/NavBar/NavBar';
import './HomePage.css';
import SearchBar from '../../Components/SearchBar/SearchBar';
const HomePage = () => {
    return (
        <>
            <NavBar></NavBar>
            <img src="\Images\CoVoyagerImageBackground01.jpg" alt="ImageBackground" className="background-image-home" />
            <SearchBar></SearchBar>
        </>
    );
};

export default HomePage;