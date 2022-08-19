import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams } from "react-router-dom";

import urls from '../../API_URL';
import OpenAirDetails from '../../components/Details/OpenAirDetailsNEW';
import PartyDetails from '../../components/Details/PartyDetailsNEW';
import ClassicMusicDetails from '../../components/Details/ClassicMusicDetailsNEW';

 function DetailsPage() {
    let params = useParams();
    const [eventType, setEventType] = useState("");
    let id = parseInt(params.eventid); 
    let url = new URL(urls.getArtEvents(id));

    useEffect(async ()=>{
       
        const result = await axios.get(url);
        setEventType(result.data.typeOfArtEvent);
    });   

    switch (eventType) {
        
        case "OpenAir":
        return(<OpenAirDetails id={id} url= {urls.openairs(id)}/>);

        case "Party": 
        return(<PartyDetails id={id} url= {urls.parties(id)}/>);

        case "ClassicMusic":
        return(<ClassicMusicDetails id={id} url= {urls.classicmusics(id)}/>);

        default: 
        return(
            <p>...Loading</p>
        );            
    }     
}
export default DetailsPage;













// const [error, setError] = useState("");

    // let url = new URL("https://localhost:44324/apiArtEvents");
    // url.searchParams.set("id", parseInt(params.eventid));
    // let eventTypeReturn ;
    
    // console.log(url);

    // let eventType="";


    
    // loadData(url); 
    // console.log(eventType, 'eventType');   


    // fetch(url)
    // .then(response=>response.json)
    // .then(
    //     // (res)=>{console.log(res)},
    //     (res)=>{setEventType(res.typeOfArtEvent)},
    //     (error)=>{console.log("DetailsPage  Fetch error",error)}
    //     );

    // eventid

    // console.log(props);
    // const eventType = props.eventType;
    // if (eventType) {        
    // } else {
    //     console.log("else  DetailsPage");
    // }
    
    // loadData2(url);




    //  function loadData(url) {
    //      let artEvent;
    //      fetch(url)
    //          .then(res => res.json())
    //          .then(
    //              (result) => {
    //                 setEventType({
    //                      fetchResult: result
    //                  });
    //                  artEvent = result;
    //              },
    //              (error) => {
    //                 setError(error                         
    //                  );
    //              }
    //         );
    //  }
    // async function loadData2(url) {
    //     let result = await fetch(url);
    // if (result.ok) {
    //     eventTypeReturn =JSON.stringify(result);        
    // } 
    // return eventTypeReturn;
    // }