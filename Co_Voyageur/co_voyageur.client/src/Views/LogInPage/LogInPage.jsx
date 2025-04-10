import React from 'react';
import NavBar from '../../Components/NavBar/NavBar';
const LogInPage = () => {
    return (
        <>
        <NavBar></NavBar>
            <section className='section-form-style section-background-style-login'>
                <form className='form-style'>
                    <h1>Se connecter</h1>
                    <input type="text" placeholder='E mail'/>
                    <input type="password" placeholder='Mot de passe'/>
                    <button className='button-submit-style'>Se connecter</button>
                    <a href='/signup' className="go-to-signin-page">Pas encore de compte? Inscrivez vous!</a>
                </form>
            </section>
        </>
    );
};

export default LogInPage;