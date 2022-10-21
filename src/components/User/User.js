import React,{useState} from "react";
import styled from "styled-components";
import axios from "axios";

import { LockButton } from "../StyledComponent/Button/RedLockButton";
import { UnLockButton } from "../StyledComponent/Button/BlueUnLockButton";
import api_url from "../../API_URL";
import AdminOrders from "../Orders/AdminOrders";
import { BaseButton } from "../StyledComponent/Button/BaseButton";




const MainUser = styled.div`
    width:100%;
    min-width:500px;
    display: flex;
    flex-flow : row nowrap ;
    align-items: center;
    justify-content: space-between;
    border-bottom: 1px solid lightskyblue;
    &:hover{
        background-color:#f7f7f7;
    }
`;
const baseDiv = styled.div`
    padding: 4px;
`;
const EmailDiv = styled(baseDiv)`
    
    width:23rem;

`;
const UserNameDiv = styled(baseDiv)`
    /* flex: 0 0 10rem; */
    width:12rem;
`;
const IsLockedDiv = styled(baseDiv)`

    /* flex: 0 0 5rem; */
    /* width:5rem; */
`;
const BlueButton = styled(BaseButton)`
    width:7rem;
    background-color: lightskyblue;
   &:not(:disabled):hover{
    outline: 1px solid black; 
   } 
`;
// const OrdersCountDiv = styled.div`
//     width: 5rem;

//     border: 1px solid red;
// `;

const lockbuttonHandler =async (id, reloadData)=>{
    

    try {
        let result = await axios.get(api_url.toggleUserLock(id));
        if (result.status===200) {
            reloadData();
        }

    } catch (error) {
        console.log(error)
    }
}

const User = (props) => {
    const [showOrder, setShowOrder] = useState("");
    let ordersCountButton;
    const showOrderHandler =()=>{
        if (showOrder) {
            setShowOrder("");
            // ordersCountButton=<Bluebutton disabled>No Orders</Bluebutton>
        }
        else {
            setShowOrder(true);
            // ordersCountButton=<Bluebutton onClick={showOrderHandler}>Show Orders</Bluebutton>
        }
    }
   
    const ShowOrderButtonHandler=()=>{
        

        if (props.ordersCount===0){
            return  <BlueButton disabled>No Orders</BlueButton>
        } else if (showOrder) {
            return  <BlueButton onClick={showOrderHandler}>Hide</BlueButton>
        } else {
            return  <BlueButton onClick={showOrderHandler}>Show orders</BlueButton>
        }

    }

    const lockButton = props.isLocked?
    <UnLockButton onClick={()=>{lockbuttonHandler(props.id, props.loadData)}}>Unlock</UnLockButton> 
    
    :<LockButton onClick={()=>{lockbuttonHandler(props.id, props.loadData)}} >Lock</LockButton> ;

    return (

       <>
        <MainUser>
            <UserNameDiv>{props.userName}</UserNameDiv>
            <EmailDiv>{props.email}</EmailDiv>

            {ShowOrderButtonHandler()}
            {/* <OrdersCountDiv onClick={showOrderHandler}>Orders:{props.ordersCount}</OrdersCountDiv> */}
            <IsLockedDiv>                
                {lockButton}                
            </IsLockedDiv>
        </MainUser>
        {showOrder && <AdminOrders email={props.email}/>}
       </>
    )
}
export default User;