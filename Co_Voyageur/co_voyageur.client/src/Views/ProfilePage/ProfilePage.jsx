import React from 'react';
import NavBar from '../../Components/NavBar/NavBar.jsx';
import HelloUser from '../../Components/HelloUser/HelloUser.jsx';
import UpdateProfile from '../../Components/UpdateProfile/UpdateProfile.jsx';
const ProfilePage = () => {
    return (
        <>
        <NavBar></NavBar>
        <HelloUser></HelloUser>
        <UpdateProfile/>
        </>
    );
};

export default ProfilePage;