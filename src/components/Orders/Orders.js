import React from "react";


import OrdersBase from "./OrdersBase";
import { getOrders } from "./getOrders";



const Orders = () => {
   return <OrdersBase getOrders={getOrders}/>

}
export default Orders;
