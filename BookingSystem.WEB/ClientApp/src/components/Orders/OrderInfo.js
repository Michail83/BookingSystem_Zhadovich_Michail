import React from "react";

const OrderInfo =(props)=>{
    console.log(props);

    return (<div>
        <span>booked: </span>
        <span>{props.quantity}</span> 
        </div>)
}

export default OrderInfo;