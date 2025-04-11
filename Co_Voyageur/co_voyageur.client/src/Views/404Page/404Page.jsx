import React from 'react';
import { Link } from 'react-router-dom';
import './404Page.css';
const NotFoundPage = () => {
    return (
        <div className="not-found">
            <img src="https://http.cat/404" alt="404-not-found" className='not-found__image'/>
            <h1 className="not-found__message">La page demandée n'existe pas... MIAOU?!</h1>
            <button><Link to={"/"}>Retour à la page d'accueil</Link></button>
        </div>
    );
};

export default NotFoundPage;