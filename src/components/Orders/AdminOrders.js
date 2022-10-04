import React from "react";

import OrdersBase from "./OrdersBase";
import { getOrdersForAdmin } from "./getOrdersForAdmin";


const AdminOrders = ({email}) => {
   return <OrdersBase getOrders={getOrdersForAdmin} email={email}/>
}
export default AdminOrders;
