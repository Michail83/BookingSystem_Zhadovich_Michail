import React, { useState, useEffect } from "react" 

import loadData from "./Functions/LoadData";
import deleteArtEvent from "./Functions/DeleteArtEvent";

// import urls from '../../API_URL'
import './DetailsList.css'

function OpenAirDetails(props) {
    const [openAirData, setOpenAirData] =  useState();
    
    useEffect(()=>{
        // let url = new URL(urls.openairs(parseInt(props.id)));        
       // url = url+"/"+parseInt(props.id);

        loadData(props.url,setOpenAirData);
        }, []
    );
    
    return(
        <div className="common-block">               
                <div>{openAirData?.eventName} </div>
                <div>{openAirData?.amountOfTickets}</div>
                <div>{openAirData?.date}</div>
                <div>{openAirData?.place}</div>
                <div>{openAirData?.headLiner}</div> 
                <button onClick={()=>deleteArtEvent(props.id)} value={"DELETE"}>del</button>        
                <div>there are image or map later</div>
        </div>
    );    
}
export default OpenAirDetails;