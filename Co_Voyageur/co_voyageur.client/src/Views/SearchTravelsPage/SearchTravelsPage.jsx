import React from 'react';
import NavBar from '../../Components/NavBar/NavBar';
import SearchBar from '../../Components/SearchBar/SearchBar';
import Filters from '../../Components/Filters/Filters';
const SearchTravelsPage = () => {
    return (
        <>
        <NavBar></NavBar>
        <img src="\Images\CoVoyagerImageBackground02.jpg" alt="ImageBackground" className="hero" />
        <SearchBar/>
        <section className='bento'>
        <Filters></Filters>
        {/*Ajouter ici le composant une fois la recherche effectuée*/}
        </section>
        </>
    );
};

export default SearchTravelsPage;