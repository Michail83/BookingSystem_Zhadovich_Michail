import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import axios from "axios";
import urls from "../../API_URL"
// import RowInMainTable from "../RowInMainTable/RowInMainTable";    
import actionCreator from "../../Store/ActionsCreators/actionCreator";
// import "./Orders.css";
import ArtEventViewForOrder from "./ArtEventViewForOrder";
import styled from "styled-components";

const OrderBlock = styled.div`
    border: 2px solid black;
    margin: 1vh;
`;

const TimeBlock=styled.div`
    font-size: 2rem;
    margin: 0.5rem;
    padding-left: 3rem;
    border: 1px solid skyblue;
    border-radius: 6px;
    background-color: skyblue;
`;

const OrdersBase = ({getOrders, email}) => {
    const [orders, setOrders] = useState([]);

    useEffect(() => {
        getOrders(setOrders, email);
        
    }, [])
   
    let element;

    if (orders.length > 0) {
        element = orders.map((order) =>

            <OrderBlock key={order.id} className="order">
                <TimeBlock>{new Date(order.timeOfCreation).toLocaleString()}         {email}</TimeBlock>
                <div>
                    {order.listOfReservedEventTickets.map(reservedEventTickets => {

                        const newProps = { ...reservedEventTickets.artEventViewModel, quantity: reservedEventTickets.quantity }
                        return <ArtEventViewForOrder key={reservedEventTickets.artEventViewModel.id + order.id} {...newProps} />

                    })}
                </div>
            </OrderBlock>
        )
    } else {
        element = <div>NO ORDERS</div>
    }   
    return (
        <div>
            {element}
        </div>
    )

}
export default OrdersBase;
