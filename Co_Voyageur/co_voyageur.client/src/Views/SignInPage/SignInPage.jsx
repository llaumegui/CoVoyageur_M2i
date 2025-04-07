import React from 'react';
import NavBar from '../../Components/NavBar/NavBar';
import './SignInPage.css';
const LogInPage = () => {
    return (
        <>
        <NavBar></NavBar>
        <section className='signIn-form'>
                <form action="">
                    <h1>Sign in</h1>
                    <input type="text" placeholder='Username'/>
                    <input type="password" placeholder='Password'/>
                    <input type="password" placeholder='Confirm Password' />
                    <button>Sign In</button>
                    <a href='/login'>Déjà incrit? Connectez vous!</a>
                </form>
            </section>
        </>
    );
};

export default LogInPage;