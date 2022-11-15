import React from "react";

const OrderInfo = (props) => {
    return (
        <>
        <div>
            <span>booked: </span>
            <span>{props.quantity}</span>
        </div>
        <div>Total:{props.quantity* props.price} USD</div>
        </>
        )
}

export default OrderInfo;