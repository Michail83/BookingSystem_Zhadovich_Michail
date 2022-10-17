import React, { useState } from "react";
import styled from "styled-components";
import { dateTimeStringToLocaleDateTime } from "../../function/dateTimeStringToLocaleDateTime";
import ArtEventViewForOrder from "./ArtEventViewForOrder";
import { BaseButton } from "../StyledComponent/Button/BaseButton";
import imageSelect from "../../icons/icons8-drop-down24.png";

const OrderBlockDiv = styled.div`
    border: 2px solid black;
    /* margin: 0.7em; */
`;
const OrderHeader = styled.div`
    display:flex;
    flex-flow: row nowrap;    
    flex: 1 1 600px;
   
    font-size: 2rem;
    margin: 0.5rem;
    padding-left: 3rem;
    border: 1px solid skyblue;
    border-radius: 6px;
    background-color:    ${({ isPaid})=>isPaid?"#4ae059":"skyblue" };

        
    
`;
const OrderHeaderItem1 = styled.div`
    display: flex;
    flex-flow: column nowrap;
    flex: 1 1 600px;

    justify-content:flex-start;
    align-items:stretch;    
`;
const OrderHeaderItem2 = styled(OrderHeaderItem1)`
    flex-flow: row nowrap;
    justify-content:center;
    align-items:center;

        
`;
const BuyButton = styled(BaseButton)`
    width: 400px;
    height: 3rem;
    border: 1px solid black;
    background-color: yellow;
    font-size:1.5rem;

`;
const MyChevron = styled.div`
    position:relative;
    top:  ${({showOrders})=>showOrders?"1rem":"-1rem"};
    width:40px;
    height:40px;
    border: 3px solid black;
    border-top: 0;
    border-left:0;

    transform:        rotate(${({showOrders})=>showOrders?"225deg":"45deg"});
    margin-left:5rem;
`;



const OrderBlock = (props) => {
    const [showOrders, setShowOrders] = useState(false);
    const showOrdersHandler = () => setShowOrders(!showOrders)
     // console.log(props);
        
    const getTotalSum =()=> props.listOfReservedEventTickets.reduce((sum, current) => {
        sum = sum + current.quantity * current.artEventViewModel.price;
        return sum;
    }, 0)

    const renderPayButton = ()=>{
        if (props.isPaid) {
            return <div>Order was paid</div>
        }  else if (props.setOrderIdForBuy) {
            return <BuyButton onClick={(event)=>{event.stopPropagation();   props.setOrderIdForBuy(props.id)}}>Buy Now</BuyButton>
        }         
        
    }
    return (
        <OrderBlockDiv key={props.id} >

            <OrderHeader onClick={showOrdersHandler} isPaid={props.isPaid}>
                <OrderHeaderItem1>
                    <div>Created at: {dateTimeStringToLocaleDateTime(props.timeOfCreation)} </div>
                    {props.email ? <div> {props.email}</div> :<></> }
                    <div>Total in order:  {getTotalSum()} USD</div>
                </OrderHeaderItem1>
                <OrderHeaderItem2>
                    {renderPayButton()}
                    <MyChevron showOrders={showOrders} ></MyChevron>

                </OrderHeaderItem2>
            </OrderHeader>

            {showOrders && <div>
               
                {props.listOfReservedEventTickets.map(reservedEventTickets => {
                    const newProps = { ...reservedEventTickets.artEventViewModel, quantity: reservedEventTickets.quantity }
                    return <ArtEventViewForOrder key={reservedEventTickets.artEventViewModel.id + props.id} {...newProps} />
                })}
            </div>}
        </OrderBlockDiv>
    )

}
export default OrderBlock;