import React from 'react';
import NavBar from '../../Components/NavBar/NavBar';
import './HomePage.css';
import SearchBar from '../../Components/SearchBar/SearchBar';
import { useNavigate } from 'react-router-dom';
const HomePage = () => {
    const navigate = useNavigate();
    const goToLogInPage = () => {
        console.log("Image clicked, navigating to login page...");
        navigate('/login');
    }
    return (
        <>
            <NavBar></NavBar>
            <img src="\Images\CoVoyagerImageBackground01.jpg" alt="ImageBackground" className="background-image-home" onClick={goToLogInPage}/>
            <SearchBar></SearchBar>
        </>
    );
};

export default HomePage;