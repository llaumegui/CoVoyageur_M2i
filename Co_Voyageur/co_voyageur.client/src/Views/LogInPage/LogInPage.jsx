import React from 'react';
import NavBar from '../../Components/NavBar/NavBar';
import './LogInPage.css';
const LogInPage = () => {
    return (
        <>
        <NavBar></NavBar>
        <section className='login-form'>
                <form action="">
                    <h1>Log In</h1>
                    <input type="text" placeholder='Username'/>
                    <input type="password" placeholder='Password'/>
                    <button>Log In</button>
                    <a href='/'>Pas encore de compte? Inscrivez vous!</a>
                </form>
            </section>
        </>
    );
};

export default LogInPage;