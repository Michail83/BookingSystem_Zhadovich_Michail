import React from "react";
import ArtEventView from "../ArtEventView/ArtEventView";
import OrderInfo from "./OrderInfo";


const OrderItem =(props)=>{
    console.log(props);

    let newProps ={...props,buttonBlock: OrderInfo } 

    return (
        <ArtEventView {...newProps}/>
    )
}
export default OrderItem;