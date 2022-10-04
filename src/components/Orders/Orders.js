import React from "react";
// import { connect } from "react-redux";
// import axios from "axios";
// import urls from "../../API_URL"
// // import RowInMainTable from "../RowInMainTable/RowInMainTable";    
// import actionCreator from "../../Store/ActionsCreators/actionCreator";
// // import "./Orders.css";
// import OrderItem from "./OrderItem";
// import styled from "styled-components";

import OrdersBase from "./OrdersBase";
import { getOrders } from "./getOrders";

// const OrderBlock = styled.div`
//     border: 2px solid black;
//     margin: 1vh;
// `;

// const TimeBlock=styled.div`
//     font-size: 2rem;
//     margin: 0.5rem;
//     padding-left: 3rem;
//     border: 1px solid skyblue;
//     border-radius: 6px;
//     background-color: skyblue;
// `;

const Orders = () => {
   return <OrdersBase getOrders={getOrders}/>

}
export default Orders;
