import React, { useState } from "react";
import Orders from "./Orders";
import OrderWithPayPal from "./OrderWithPayPal";

const WrapForPay = () => {
    const [orderId, setOrderId] = useState();

    return (
        <>
            {orderId == undefined ? <Orders orderIdForBuy={setOrderId} /> : <OrderWithPayPal orderId={orderId} setOrderId={setOrderId} />}
        </>
    )
}
export default WrapForPay;