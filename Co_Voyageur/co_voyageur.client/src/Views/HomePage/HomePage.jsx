import { React, useState } from 'react';
import NavBar from '../../components/NavBar/NavBar';
import './HomePage.css';
import SearchBar from '../../Components/SearchBar/SearchBar';
import Card from '../../components/Card/Card';
import Suggestions from '../../components/Suggestions/Suggestions';
import Footer from '../../components/Footer/Footer';

const HomePage = () => {
    const about = `Bienvenue sur notre application de covoiturage, votre solution écologique et économique pour les trajets partagés. 
  Que ce soit pour aller au travail, faire des courses ou voyager avec des amis, notre plateforme vous connecte avec des passagers et des conducteurs à proximité pour partager des trajets, économiser de l'argent et réduire votre empreinte carbone.

  Fonctionnalités principales :
  - Correspondance de trajets simplifiée : Trouvez des conducteurs ou des passagers qui vont dans la même direction que vous en quelques clics seulement.
  - Disponibilité en temps réel : Consultez les trajets disponibles ou proposez votre propre trajet à tout moment, garantissant flexibilité et commodité.
  - Partage des frais : Divisez le coût de votre trajet avec vos compagnons de voyage, rendant les déplacements plus abordables pour tout le monde.
  - Sécurité et confiance : Nous priorisons la sécurité de nos utilisateurs en permettant la consultation des évaluations et avis des conducteurs et passagers.
  - Interface conviviale : Notre design simple et intuitif assure une expérience fluide du début à la fin.

  Rejoignez notre communauté et commencez à faire du covoiturage dès aujourd'hui pour réduire vos frais de transport et contribuer à un avenir plus vert et durable. Partagez un trajet, économisez de l'argent et faites une différence pour la planète – un covoiturage à la fois.`;

  const [isLoggedIn, setIsLoggedIn] = useState(false);

    return (
        <>
            <NavBar ></NavBar>
            <img src="\Images\CoVoyagerImageBackground01.webp" alt="ImageBackground" className="hero"/>
            <SearchBar></SearchBar>
            <div className='home-container'>
            <Card title="A propos" description={about}/>
            {isLoggedIn && (<Card title="Mes trajets" description="Voici vos trajets prévus." />)}
            <Card title="Suggestions" description={<Suggestions/>}/>
            </div>
            <Footer/>
            
        </>
    );
};

export default HomePage;