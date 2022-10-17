import React from "react";
import { PayPalButtons, PayPalScriptProvider } from "@paypal/react-paypal-js";
import api_url from "../../../API_URL";
import axios from "axios";
import {useNavigate} from "react-router-dom";
import "./PayPalButton";
import styled from "styled-components";

const DivForPaypal = styled.div`
    margin: 0.5rem auto;
    width:400px;
`;

const PayPalButton = ({orderId, setOrderId}) => {
    const navigate = useNavigate();


    return (
        <DivForPaypal>
            <PayPalScriptProvider options={{ "client-id": "AZ8bS6AYWgjPjQkP7o4DLnr1hTiR8nkv2zFtKYi53Yw-Ir40eN8VMcRUvgatnDtqozvnZBxX0ewrx5YD" }}>
            <PayPalButtons createOrder={
                async (data, actions) => {
                    const response = await fetch(api_url.createPaypalOrder(orderId), {
                        method: "post",
                    });

                    const order = await response.json();
                    return order.id;
                }
            }
                onApprove={
                    async (data, actions) => {
                        const response = await fetch(api_url.capturePaypalOrder(data.orderID), {
                            method: "post",
                        });
                        const orderData = await response.json();  
                        if (orderData===true) {
                            console.log(orderData)  
                            setOrderId(undefined); 
                        }
                                                
                    }
                }
                showSpinner ={true}
                style ={{color:"blue"}}
                
                >
            </PayPalButtons>
        </PayPalScriptProvider>
        </DivForPaypal>
    )
}
export default PayPalButton;