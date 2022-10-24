import React,{useEffect, useState} from "react";
import axios from "axios";
import api_url from "../../API_URL";
import OrderBlock from "./OrderBlock";
import PayPalButton from "./PayPal/PayPalButton"

const OrderWithPayPal =({orderId, setOrderId})=>{   

const [order, setOrder] = useState();
    useEffect(()=>{
       loadData();       

    },[]);
    const loadData = async ()=>{
        try {
            let result = await axios.get(api_url.getOrder(orderId));
            setOrder(result.data);  

        } catch (error) {
            console.log("OrderWithPayPal  error =  " + error)
        }
    }
return (
    <>
    {order && 
    <>  
        <OrderBlock {...order}/>
        <PayPalButton orderId={orderId} style={{margin:"0, auto"}} setOrderId={setOrderId} />
    </> }
    </>
) 

}
export default OrderWithPayPal;