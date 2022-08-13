import React, { useState, useEffect } from "react" 

import { YandMap } from "../YandMAP/YandMAP";

import loadData from "./Functions/LoadData";


import './DetailsList.css'

function OpenAirDetails(props) {
    const [openAirData, setOpenAirData] =  useState();
    
    useEffect(()=>{
        loadData(props.url,setOpenAirData);
        }, []
    );
    
    return (
        <div className="mainDetails">
            <div className="dataBlock">
                <div>{openAirData?.eventName} </div>
                <div>{openAirData?.amountOfTickets}</div>
                <div>{openAirData?.date}</div>
                <div>{openAirData?.place}</div>
                <div>{openAirData?.headLiner}</div>
                {/* {props.deleteButton ? <props.deleteButton /> : ""}                 */}
            </div>
            <div className="mapBlock">
                {openAirData ? <YandMap artEventItems={[openAirData]} /> : ""}
            </div>

        </div>

    );    
}
// export default OpenAirDetails;