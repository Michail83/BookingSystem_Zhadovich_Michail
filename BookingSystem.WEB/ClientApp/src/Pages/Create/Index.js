import React, { useState, useEffect }  from 'react';
import UniversalHeader from '../../components/UniversalHeader/UniversalHeader.js';
import OpenAirCreateForm from '../../components/CreateDifferentArtEvent/OpenAirCreateForm.js';
import PartiesCreateForm from '../../components/CreateDifferentArtEvent/PartiesCreateForm.js'
import ClassicMusicCreateForm from '../../components/CreateDifferentArtEvent/ClassicMusicCreateForm'
import './Index.css';

// import './App.css';
// import works from './works';
// import Header from './components/Header/Header';
// import About from './components/About/About';
// import PortfolioItem from './components/PortfolioItem/PortfolioItem';
// import ContactForm from './components/ContactForm/ContactForm';
// import UniversalHeader from './components/UniversalHeader/UniversalHeader';
// import MainTableForArtEvents from './components/MainTableForArtEvents/MainTableForArtEvents';

function CreateEvent() {
const [currentTab, setcurrentTab ] = useState(0);
// const [Element, setElement ] = useState();

let Element;
switch (currentTab) {        
    case 0: Element = OpenAirCreateForm;    
    break;  
    case 1: Element = PartiesCreateForm; 
    break;  
    case 2: Element = ClassicMusicCreateForm;
    break;      
    default: 
    (
        <p>...Loading</p>        
    );
    break;            
} 
    return (
        <div>
            <div id='tabs'>
                <div className={currentTab===0?'active':''} onClick={()=>setcurrentTab(0)}>Open Airs</div>
                <div className={currentTab===1?'active':''} onClick={()=>setcurrentTab(1)}>Parties</div>
                <div className={currentTab===2?'active':''} onClick={()=>setcurrentTab(2)}>Classic Music</div>
            </div>
            <Element/>           
        </div>
    );
}
export default CreateEvent;