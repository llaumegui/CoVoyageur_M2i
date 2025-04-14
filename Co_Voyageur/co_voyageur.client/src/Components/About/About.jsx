import './About.css';
import { Link } from 'react-router-dom';

const About = () => {
    return (
        <>
            <section className='about'>
                <h2 className='title'>
                    Bienvenue
                </h2>
                <p>
                Bienvenue sur notre application de covoiturage, votre solution écologique et économique pour les trajets partagés. 
                Que ce soit pour aller au travail, faire des courses ou voyager avec des amis, notre plateforme vous connecte avec des passagers et des conducteurs à proximité pour partager des trajets, économiser de l'argent et réduire votre empreinte carbone.                    
                </p>
                <hr></hr>
                <h2 className='title'>
                    Fonctionnalités
                </h2>
                <ul>
                    <li>- Correspondance de trajets simplifiée : Trouvez des conducteurs ou des passagers qui vont dans la même direction que vous en quelques clics seulement.</li>
                    <li>- Disponibilité en temps réel : Consultez les trajets disponibles ou proposez votre propre trajet à tout moment, garantissant flexibilité et commodité.</li>
                    <li>- Partage des frais : Divisez le coût de votre trajet avec vos compagnons de voyage, rendant les déplacements plus abordables pour tout le monde.</li>
                    <li>- Sécurité et confiance : Nous priorisons la sécurité de nos utilisateurs en permettant la consultation des évaluations et avis des conducteurs et passagers.</li>
                    <li>- Interface conviviale : Notre design simple et intuitif assure une expérience fluide du début à la fin.</li>
                </ul>
                <hr></hr>
                <h2 className='title'>Rejoignez-nous !</h2>
                <p>Rejoignez notre communauté et commencez à faire du covoiturage dès aujourd'hui pour réduire vos frais de transport et contribuer à un avenir plus vert et durable. Partagez un trajet, économisez de l'argent et faites une différence pour la planète – un covoiturage à la fois.</p>
                <div className='inscription'><button ><Link to={"/signup"}>Inscription</Link></button></div>
            </section>
        </>
    )
}

export default About