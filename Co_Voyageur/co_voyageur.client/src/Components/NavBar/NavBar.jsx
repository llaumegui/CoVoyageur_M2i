import React from 'react';
import './NavBar.css';
import { useNavigate } from 'react-router-dom';
const NavBar = () => {
    const navigate = useNavigate();
    const goToLogInPage = () => {
        navigate('/login');
    }
    const goToHomePage = () => {
        navigate('/');
    }

    return (

        <nav>
            <img src="../Images/Logo.png" alt="Logo" className="navbar-logo" onClick={goToHomePage} />
            <div className='navbar-right'>
                <a href="/search">Rechercher</a>
               <img src="../Images/Account.png" alt="Logo" className="navbar-account" onClick={goToLogInPage}/>
            </div>

        </nav>
    );
};

export default NavBar;