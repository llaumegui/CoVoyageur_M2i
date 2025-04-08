import React from 'react';
import { Link } from 'react-router-dom';
import './404Page.css';
const NotFoundPage = () => {
    return (
        <div className="not-found-page">
            <img src="https://http.cat/404" alt="404-not-found" title='404-error-httpcats.org' />
            <p className="gui-le-déglingo">Guillaume a dit : "c'est bientôt le week end</p>
            <p className="developper-message">La page demandée n'existe pas... MIAOU?!</p>
            <Link to="/" className="button-back">Retour à l'accueil</Link>
        </div>
    );
};

export default NotFoundPage;