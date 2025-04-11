import React from 'react';
import './MyCar/MyCar.jsx'
import './Bento.css'
import MyCar from './MyCar/MyCar.jsx';
import User from './User/User.jsx';
import Reviews from './Reviews/Review.jsx';
import Favorites from './Favorites/Favorites.jsx';
const Bento = () => {
    return (
        <>
        <h2>Hello User</h2>
        <section className='bento'>
            <MyCar/>
            <User/>
            <Reviews/>
            <Favorites/>
        </section>
        </>
    );
};

export default Bento;