import React, { useState, useEffect } from "react"

import { YandMap } from "../YandMAP/YandMAP";

import './DetailsList.css'

import loadData from './Functions/LoadData';
import deleteFunc from './Functions/deleteArtEvent'

function ClassicMusicDetails(props) {
    const [classicMusicData, setpartclassicMusic] =  useState("");
    
    useEffect(()=>{
        loadData(props.url,setpartclassicMusic);
        }, []
    );

    return(
        <div className="mainDetails">                
            <div className="dataBlock">
                <div>{classicMusicData?.eventName} </div>
                <div>{classicMusicData?.amountOfTickets}</div>
                <div>{classicMusicData?.date}</div>
                <div>{classicMusicData?.place}</div>
                <div>{classicMusicData?.voice}</div>
                <div>{classicMusicData?.concertName}</div> 
                {props.deleteButton?<props.deleteButton/>:""} 
                {/* <button onClick={()=>deleteFunc(props.id)} value={"DELETE"}>del</button> */}
            </div>
            
            <div className="mapBlock">
                {classicMusicData?<YandMap artEventItems={[classicMusicData]} />:""}
            </div>                         
            
        </div>
    );    
}
export default ClassicMusicDetails;