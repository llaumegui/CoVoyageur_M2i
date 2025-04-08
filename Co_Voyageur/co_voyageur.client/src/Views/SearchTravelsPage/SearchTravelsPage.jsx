import React from 'react';
import NavBar from '../../Components/NavBar/NavBar';
import SearchBar from '../../Components/SearchBar/SearchBar';
import './SearchTravelsPage.css';
import ResultCard from '../../Components/ResultCard/ResultCard';
import Filters from '../../Components/Filters/Filters';
const SearchTravelsPage = () => {
    return (
        <>
        <NavBar></NavBar>
        <img src="\Images\CoVoyagerImageBackground02.jpg" alt="ImageBackground" className="background-image-searchTravels" />
        <SearchBar/>
        <Filters></Filters>
        <ResultCard/>

        </>
    );
};

export default SearchTravelsPage;