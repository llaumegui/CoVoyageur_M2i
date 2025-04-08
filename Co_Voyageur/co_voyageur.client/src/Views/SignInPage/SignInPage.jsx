import React from 'react';
import NavBar from '../../Components/NavBar/NavBar';
import './SignInPage.css';
const LogInPage = () => {
    return (
        <>
        <NavBar></NavBar>
        <section className='signIn-form'>
                <form action="">
                    <h1>Inscription</h1>
                    <input type="text" placeholder='E mail'/>
                    <input type="password" placeholder='Mot de passe'/>
                    <input type="password" placeholder='Confirmer le mot de passe' />
                    <button>Inscription</button>
                    <a href='/login'>Déjà incrit? Connectez vous!</a>
                </form>
            </section>
        </>
    );
};

export default LogInPage;