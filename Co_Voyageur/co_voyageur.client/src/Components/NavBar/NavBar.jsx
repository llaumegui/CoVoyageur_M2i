import React from 'react';
import './NavBar.css';

const NavBar = () => {
    return (
        <nav>
            <img src="../Images/Logo.png" alt="Logo" className="navbar-logo" />
            <div className='navbar-right'>
                <a href="#">Rechercher</a>
                <img src="../Images/Account.png" alt="Logo" className="navbar-account" />
            </div>

        </nav>
    );
};

export default NavBar;