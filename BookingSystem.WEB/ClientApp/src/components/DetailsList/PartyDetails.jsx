import React, { useState, useEffect } from "react" 

import loadData from './Functions/LoadData';
import deleteFunc from './Functions/DeleteArtEvent'
import './DetailsList.css'

function PartyDetails(props) {

    const [partyData, setpartyData] =  useState();

    useEffect(()=>{
        // let url = new URL(urls.openairs(parseInt(props.id)));        
       // url = url+"/"+parseInt(props.id);

        loadData(props.url,setpartyData);
        }, []
    );
    // useEffect(()=>{
    //     let url = new URL("https://localhost:44324/api");
    //     url.searchParams.set("id", parseInt(props.id));

    //     loadData(url,setpartyData);
    //     }, []);
    
    return(
        <div className="common-block">                
            <div>{partyData?.eventName} </div>
            <div>{partyData?.amountOfTickets}</div>
            <div>{partyData?.date}</div>
            <div>{partyData?.place}</div>
            <div>{partyData?.ageLimitation}</div>
            <button onClick={()=>deleteFunc(props.id)} value={"DELETE"}>del</button>
            <div>there will be  the PartyDetails </div>
        </div>
    );    
}
export default PartyDetails;