import React, {useState, useEffect} from "react";
import { connect } from "react-redux";
import axios from "axios";
import urls from "../../API_URL"
import RowInMainTable from "../RowInMainTable/RowInMainTable";    
import actionCreator from "../../Store/ActionsCreators/actionCreator";
import "./Orders.css"


const Orders = ()=>{
   const [orders, setOrders] = useState([]);

    useEffect(()=>{
        getOrders();        
    },[])

    const getOrders = async ()=>{
        try {
            let result = await axios.get(urls.getOrders());
            setOrders(result.data);
            

        } catch (error) {
            console.log("Orders.getOrders  error =  " + error)
        }        
    }
    let element;
    console.log(orders.length);
    if (orders.length > 0 ) {
        console.log(orders);
        element = orders.map((order)=>        
            <div key={order.id} className="order">
                 <div className="orderdatetime">{order.timeOfCreation}</div>
                 <div className="orderdata">
                     {order.listOfReservedEventTickets.map(reservedEventTickets=>(
                         <div key={reservedEventTickets.artEventViewModel.id} className="orderitem_flex">
                             <div className="quantity">{reservedEventTickets.quantity} </div>
                             <div className="artevent" >
                                 <table>
                                 <RowInMainTable key={reservedEventTickets.artEventViewModel.id} item={reservedEventTickets.artEventViewModel} buttonType = {"noButton"}/>
                                 </table>
                           
                             </div>
                         </div>
                     ))}
                 </div>        
             </div>
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
export default Orders;
