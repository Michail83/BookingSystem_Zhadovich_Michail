import React from "react";
import ArtEventView from "../ArtEventView/ArtEventView";
import OrderInfo from "./OrderInfo";


const ArtEventViewForOrder =(props)=>{
   

    let newProps ={...props,buttonBlock: OrderInfo } 

    return (
        <ArtEventView {...newProps}/>
    )
}
export default ArtEventViewForOrder;