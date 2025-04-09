import React from 'react';
import HeaderCar from '../CarInfos/HeaderCar.jsx';
import HeaderUser from '../UserInfos/HeaderUser.jsx';
import HeaderReviews from '../Reviews/HeaderReviews.jsx';
import HeaderFavs from '../Favs/HeaderFavs.jsx';

import BodyCar from '../CarInfos/BodyCar.jsx';
import BodyUser from '../UserInfos/BodyUser.jsx';
import BodyReviews from '../Reviews/BodyReviews.jsx';
import BodyFavs from '../Favs/BodyFavs.jsx';

import FooterCar from '../CarInfos/FooterCar.jsx';
import FooterUser from '../UserInfos/FooterUser.jsx';


const UpdateProfile = () => {
    return (
    <>
    {/* Bento#1 => CarInfos */}
        <section className="card">
            <div className="card-header">
                <HeaderCar/>
            </div>
            <div className="card-body">
                <BodyCar/>
            </div>
            <div className="card-footer">
                <FooterCar/>
            </div>
        </section>

        {/* Bento#2 => UserInfos */}
        <section className="card big-card">
            <div className="card-header">
                <HeaderUser/>
            </div>
            <div className="card-body">
                <BodyUser/>
            </div>
            <div className="card-footer">
                <FooterUser/>
            </div>
        </section>
        {/* Bento#3 => Reviews */}
        <section className="card big-card">
            <div className="card-header">
                <HeaderReviews/>
            </div>
            <div className="card-body">
                <BodyReviews/>
            </div>
        </section>
        {/* Bento#2 => Favs */}
        <section className="card">
            <div className="card-header">
                <HeaderFavs/>
            </div>
            <div className="card-body">
                <BodyFavs/>
            </div>
        </section>
    </>
    );
};

export default UpdateProfile;