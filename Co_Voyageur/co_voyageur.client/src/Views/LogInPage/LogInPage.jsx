import React from 'react';
import NavBar from '../../Components/NavBar/NavBar';
const LogInPage = () => {
    return (
        <>
        <NavBar></NavBar>
            <h1>Log In</h1>
            <input type="text" placeholder='Username'/>
            <input type="password" placeholder='Password'/>
            <button>Log In</button>
        </>
    );
};

export default LogInPage;