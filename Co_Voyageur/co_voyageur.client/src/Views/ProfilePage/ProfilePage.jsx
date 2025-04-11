import React from 'react';
import NavBar from '../../Components/NavBar/NavBar.jsx';
import HelloUser from '../../Components/HelloUser/HelloUser.jsx';
import Bento from '../../Components/Profile/Bento/Bento.jsx';
const ProfilePage = () => {
    return (
        <>
        <NavBar></NavBar>
        <HelloUser></HelloUser>
        <section className="profile">
        <Bento></Bento>
        </section>
        </>
    );
};

export default ProfilePage;