import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import axios from "axios";
import urls from "../../API_URL"
// import RowInMainTable from "../RowInMainTable/RowInMainTable";    
import actionCreator from "../../Store/ActionsCreators/actionCreator";
// import "./Orders.css";
import OrderItem from "./OrderItem";
import styled from "styled-components";



const OrderBlock = styled.div`
    border: 2px solid black;
    margin: 1vh;
`;

const TimeBlock=styled.div`
    font-size: 3vh;
    margin: 1vh;
    padding-left: 3rem;
`;


const Orders = () => {
    const [orders, setOrders] = useState([]);

    useEffect(() => {
        getOrders();
        console.log(orders);
    }, [])

    const getOrders = async () => {
        try {
            let result = await axios.get(urls.getOrders());
            setOrders(result.data);
            console.log(result.data);


        } catch (error) {
            console.log("Orders.getOrders  error =  " + error)
        }
    }
    let element;
    console.log(orders.length);
    console.log(orders);

    if (orders.length > 0) {
        element = orders.map((order) =>

            <OrderBlock key={order.id} className="order">
                <TimeBlock>{new Date(order.timeOfCreation).toLocaleString()}</TimeBlock>
                <div>
                    {order.listOfReservedEventTickets.map(reservedEventTickets => {

                        const newProps = { ...reservedEventTickets.artEventViewModel, quantity: reservedEventTickets.quantity }
                        return <OrderItem key={reservedEventTickets.artEventViewModel.id + order.id} {...newProps} />

                    })}
                </div>
            </OrderBlock>
        )
    } else {
        element = <div>NO ORDERS</div>
    }
    // element = <div>NO ORDERS</div>
    return (
        <div>
            {element}
        </div>
    )

}
export default Orders;
