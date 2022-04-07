import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams } from "react-router-dom";
// import  LoadCustomArtEvent from "../../components/DetailsList/LoadCustomArtEvent";

import urls from '../../API_URL'
import OpenAirDetails from '../../components/DetailsList/OpenAirDetails'
import PartyDetails from '../../components/DetailsList/PartyDetails'
import ClassicMusicDetails from '../../components/DetailsList/ClassicMusicDetails'

 function LoginCallback() {

    let params = useParams();
    // const [eventType, setEventType] = useState("");
    let resultString = params.string;     //  string or number
    // let url = new URL(urls.artEvents(id));

    // useEffect(async ()=>{
    //     // error handling
    //     const result = await axios.get(url);
    //     setEventType(result.data.typeOfArtEvent);
    // });   

    // switch (eventType) {
        
    //     case "OpenAir":
    //     return(<OpenAirDetails id={id} url= {urls.openairs(id)} />);

    //     case "Party": 
    //     return(<PartyDetails id={id} url= {urls.parties(id)} />);

    //     case "ClassicMusic":
    //     return(<ClassicMusicDetails id={id} url= {urls.classicmusic(id)} />);

    //     default: 
    //     return(
    //         <p>...Loading</p>
    //     );            
    // } 
    return (<p>{resultString}</p>)    
}
export default LoginCallback;