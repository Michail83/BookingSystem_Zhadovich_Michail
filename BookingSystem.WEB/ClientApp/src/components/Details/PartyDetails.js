import React, { useState, useEffect } from "react" 

import { YandMap } from "../YandMAP/YandMAP";

import loadData from './Functions/LoadData';
import deleteFunc from './Functions/deleteArtEvent'
import './DetailsList.css'

function PartyDetails(props) {

    const [partyData, setpartyData] =  useState();

    useEffect(()=>{        
        loadData(props.url,setpartyData);
        }, []
    );
    
    
    return(
    <div className="mainDetails">
            <div className="dataBlock">
                <div>{partyData?.eventName} </div>
                <div>{partyData?.amountOfTickets}</div>
                <div>{partyData?.date}</div>
                <div>{partyData?.place}</div>
                <div>{partyData?.ageLimitation}</div>
                {props.deleteButton ? <props.deleteButton /> : ""}
            </div>
            <div className="mapBlock">
                {partyData ? <YandMap artEventItems={[partyData]} /> : ""}
            </div>
        </div>
    );    
}
// export default PartyDetails;