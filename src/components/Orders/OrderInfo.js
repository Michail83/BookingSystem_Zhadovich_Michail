import React from "react";

const OrderInfo =(props)=>{
    return (<div>
        <span>booked: </span>
        <span>{props.quantity}</span> 
        </div>)
}

export default OrderInfo;