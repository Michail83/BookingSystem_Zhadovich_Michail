import React, { useState, useEffect } from "react"

import './DetailsList.css'

import loadData from './Functions/LoadData';
import deleteFunc from './Functions/DeleteArtEvent'

function ClassicMusicDetails(props) {
    const [classicMusicData, setpartclassicMusic] =  useState();
    
    useEffect(()=>{
        loadData(props.url,setpartclassicMusic);
        }, []
    );

    return(
        <div className="common-block">                
            <div>{classicMusicData?.eventName} </div>
            <div>{classicMusicData?.amountOfTickets}</div>
            <div>{classicMusicData?.date}</div>
            <div>{classicMusicData?.place}</div>
            <div>{classicMusicData?.voice}</div>
            <div>{classicMusicData?.concertName}</div>  
            <button onClick={()=>deleteFunc(props.id)} value={"DELETE"}>del</button>                         
            
        </div>
    );    
}
export default ClassicMusicDetails;