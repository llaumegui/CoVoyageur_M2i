import React from 'react';
import NavBar from '../../components/NavBar/NavBar';
import './HomePage.css';
import SearchBar from '../../components/SearchBar/SearchBar';
import Card from '../../components/Card/Card';
import Footer from '../../components/Footer/Footer';

const HomePage = () => {
    
    return (
        <>
            <NavBar></NavBar>
            <img src="\Images\CoVoyagerImageBackground01.jpg" alt="ImageBackground" className="background-image-home"/>
            <SearchBar></SearchBar>
            <div className='container'>
            <Card />
            <Card />
            <Card />
            </div>
            <Footer/>
            
        </>
    );
};

export default HomePage;