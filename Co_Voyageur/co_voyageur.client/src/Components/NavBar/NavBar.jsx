import React from 'react';
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
            <img src="../Images/Logo.png" alt="Logo" className="navbar__logo" onClick={goToHomePage} />
            <div className='navbar__right'>
                <a href="/submit-travel">Proposer un trajet</a>
                <a href="/search">Rechercher</a>
                <img src="../Images/Account.png" alt="Logo" className="navbar__account" onClick={goToLogInPage}/>
            </div>

        </nav>
    );
};

export default NavBar;