import React from 'react';

import MainTableForArtEvents from '../../components/MainTableForArtEvents/MainTableForArtEvents.js';
import UniversalHeader from '../../components/UniversalHeader/UniversalHeader.js';



// import './App.css';

// import works from './works';
// import Header from './components/Header/Header';
// import About from './components/About/About';
// import PortfolioItem from './components/PortfolioItem/PortfolioItem';
// import ContactForm from './components/ContactForm/ContactForm';
// import UniversalHeader from './components/UniversalHeader/UniversalHeader';
// import MainTableForArtEvents from './components/MainTableForArtEvents/MainTableForArtEvents';

function HomePage() {
    return (
        <div className='app'>
            {/* <UniversalHeader children = {<MainTableForArtEvents/>} />             */}
            <MainTableForArtEvents/>
        </div>
    );
}
export default HomePage;