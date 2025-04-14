import React from 'react';
import NavBar from '../../Components/NavBar/NavBar';
import Footer from '../../components/Footer/Footer';
import './LogInPage.css';
const LogInPage = () => {
    return (
        <>
        <NavBar></NavBar>
        <section className='login-form'>
                <form action="">
                    <h1>Se connecter</h1>
                    <input type="text" placeholder='E mail'/>
                    <input type="password" placeholder='Mot de passe'/>
                    <button>Se connecter</button>
                    <a href='/signup'>Pas encore de compte? Inscrivez vous!</a>
                </form>
            </section>
            <Footer />
        </>
    );
};

export default LogInPage;