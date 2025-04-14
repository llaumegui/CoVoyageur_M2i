import React from 'react';
import NavBar from '../../Components/NavBar/NavBar';
import SearchBar from '../../Components/SearchBar/SearchBar';
import About from '../../Components/About/About';

const HomePage = () => {
    
    return (
        <>
            <NavBar ></NavBar>
            <img src="\Images\CoVoyagerImageBackground01.webp" alt="ImageBackground" className="hero"/>
            <SearchBar></SearchBar>
            <About />
        </>
    );
};

export default HomePage;