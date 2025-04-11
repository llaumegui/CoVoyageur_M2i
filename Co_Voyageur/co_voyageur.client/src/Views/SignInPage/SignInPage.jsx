import React, {useState} from 'react';
import NavBar from '../../Components/NavBar/NavBar';
import './SignInPage.css';
const SignInPage = () => {
    const [error, setError] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [displayForm, setDisplayForm] = useState(true);

    const emailChange = (e) => {
        setEmail(e.target.value);
    }

    const passwordChange = (e) => {
        setPassword(e.target.value);
    }

    const confirmPasswordChange = (e) => {
        setConfirmPassword(e.target.value);
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/; // Regex pour valider l'email
        const passwordRegex = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/; // Minimum 8 caractères avec au moins une lettre et un chiffre

        if(!email && !password && !confirmPassword) {
            setError('Veuillez remplir tous les champs!');
            return;
        }
        if (!emailRegex.test(email)) {
            setError('Email invalide!');
            return;
        }
        if (!passwordRegex.test(password)) {
            setError('Le mot de passe doit contenir au moins 8 caractères, une lettre et un chiffre!');
            return;
        }
        if (password !== confirmPassword) {
            setError('Les mots de passe ne correspondent pas!');
            return;
        }
        setError('');
        setDisplayForm(false);
    }

    return (
    <>
        <NavBar></NavBar>
        <section className="signin__container container">
                <form>
                    {displayForm && 
                    <>
                        <h1>Inscription</h1>
                        <input type="text" placeholder='E mail' value={email} onChange={emailChange} required/>
                        <input type="password" placeholder='Mot de passe' value={password} onChange={passwordChange} required/>
                        <input type="password" placeholder='Confirmer le mot de passe' value={confirmPassword} onChange={confirmPasswordChange} required/>
                        <button onClick={handleSubmit} className='button-submit-style'>Suivant</button>
                        <a href='/login' className="go-to-login-page">Déjà incrit? Connectez vous!</a>
                    </>
                    }
                    {!displayForm &&
                        <>
                        <h1>Suite de l'inscription</h1>
                        <input type="text" placeholder='Nom' required/>
                        <input type="text" placeholder='Prénom' required/>
                        <input type="text" placeholder='Téléphone' required/>
                        <button type='submit' className='button-submit-style'>S'inscrire</button>
                        </>
                    }                  
                </form>
                {error && <p className='error'>{error}</p>}
        </section>
    </>
        )
    };

export default SignInPage;