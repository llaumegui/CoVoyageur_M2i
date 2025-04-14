import React, {useState} from 'react';
import NavBar from '../../Components/NavBar/NavBar';
import Footer from '../../components/Footer/Footer';
import './SignInPage.css';
const LogInPage = () => {
    const [error, setError] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');

    const emailChange = (e) => {
        setEmail(e.target.value);
    }

    const passwordChange = (e) => {
        setPassword(e.target.value);
    }

    const confirmPasswordChange = (e) => {
        setConfirmPassword(e.target.value);
    }

    const handleSubmit = () => {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/; // Regex pour valider l'email
        const passwordRegex = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/; // Minimum 8 caractères avec au moins une lettre et un chiffre

        if(!email && !password && !confirmPassword) {
            setError('Veuillez remplir tous les champs');
            return;
        }
        if (!emailRegex.test(email)) {
            setError('Email invalide');
            return;
        }
        if (!passwordRegex.test(password)) {
            setError('Le mot de passe doit contenir au moins 8 caractères, une lettre et un chiffre');
            return;
        }
        if (password !== confirmPassword) {
            setError('Les mots de passe ne correspondent pas');
            return;
        }
        setError('');
        
    }

    return (
        <>
        <NavBar></NavBar>
        <section className='signIn-form'>
                <form action={handleSubmit} >
                    <h1>Inscription</h1>
                    <input type="text" placeholder='E mail' value={email} onChange={emailChange}/>
                    <input type="password" placeholder='Mot de passe' value={password} onChange={passwordChange}/>
                    <input type="password" placeholder='Confirmer le mot de passe' value={confirmPassword} onChange={confirmPasswordChange} />
                    <button>Inscription</button>
                    {error && <p className="error">{error}</p>}
                    <a href='/login'>Déjà incrit? Connectez vous!</a>
                </form>
            </section>
            <Footer />
        </>
    );
};

export default LogInPage;