import React, { useState, useEffect } from "react";
import OrderBlock from "./OrderBlock";

const OrdersBase = ({ getOrders, email, orderIdForBuy }) => {     
            
    const [orders, setOrders] = useState([]);    

    useEffect(() => {
        getOrders(setOrders, email);
    }, [])

    const createOrders = () => {
        let element;
        if (orders.length > 0) {
            element = orders.map((order) => {
               
                let newProps = {...order, email:email, setOrderIdForBuy:orderIdForBuy }
                return (
                    <OrderBlock key={order.id} {...newProps}   />
                    
                )
            })
        } else {
            element = <div>NO ORDERS</div>
        }
        return element;
    }

    return (
        <div>
            {createOrders()}
        </div>
    )
}
export default OrdersBase;