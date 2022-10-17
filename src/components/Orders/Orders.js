import React from "react";


import OrdersBase from "./OrdersBase";
import { getOrders } from "./getOrders";



const Orders = (props) => {
   return <OrdersBase {...props} getOrders={getOrders}/>

}
export default Orders;
