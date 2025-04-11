import React from 'react';
import { useNavigate } from 'react-router-dom';
import './NavBar.css';
const NavBar = () => {
    const navigate = useNavigate();
    const goToLogInPage = () => {
        navigate('/login');
    }
    const goToHomePage = () => {
        navigate('/');
    }

    return (

        <nav className='navbar'>
            <img src="../Images/Logo.png" alt="Logo" className="navbar__logo" onClick={goToHomePage} />
            <div className='navbar__right'>
                <a href="/submit-travel" className="navbar__link">Proposer un trajet</a>
                <a href="/search" className="navbar__link">Rechercher</a>
                <img src="../Images/add_travel.png" alt="" className="navbar__phone"/>
                <img src="../Images/search.svg" alt="" className="navbar__phone"/>
                {/*AJOUTER 2 LOGOS POUR LE FORMAT MOBILE EN DISPLAY NON SUR LE FORMAT DESKTOP CSS EN SPACE BETWEEN*/ }
                <img src="../Images/Account.png" alt="Logo" className="navbar__account" onClick={goToLogInPage}/>
            </div>

        </nav>
    );
};

export default NavBar;