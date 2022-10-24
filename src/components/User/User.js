import React, { useState } from "react";
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
    width:12rem;
`;
const IsLockedDiv = styled(baseDiv)`

`;
const BlueButton = styled(BaseButton)`
    width:7rem;
    background-color: lightskyblue;
   &:not(:disabled):hover{
    outline: 1px solid black; 
   } 
`;

const lockbuttonHandler = async (id, reloadData) => {
    try {
        let result = await axios.get(api_url.toggleUserLock(id));
        if (result.status === 200) {
            reloadData();
        }
    } catch (error) {
        console.log(error)
    }
}

const ResetPasswordButton = styled(BaseButton)`
    background-color: #e85656;
    width:110px;
`;
const ResetPasswordButtonDisabled = styled(BaseButton)`
    background-color: #9e9e9e;
    width:110px;
`;
// const resetPasswordButtonDisabled = styled(resetPasswordButton)`
//     :disabled
// `;

const User = (props) => {
    const [showOrder, setShowOrder] = useState("");
    const showOrderButtonHandler = () => {
        if (showOrder) {
            setShowOrder("");
        }
        else {
            setShowOrder(true);
        }
    }

    const ShowOrderButton = () => {
        if (props.ordersCount === 0) {
            return <BlueButton disabled>No Orders</BlueButton>
        } else if (showOrder) {
            return <BlueButton onClick={showOrderButtonHandler}>Hide</BlueButton>
        } else {
            return <BlueButton onClick={showOrderButtonHandler}>Show orders</BlueButton>
        }
    }

    const lockButton = () => {
        let button;
        if (props.isLocked) {
            button = <UnLockButton onClick={() => { lockbuttonHandler(props.id, props.loadData) }}>Unlock</UnLockButton>
        } else {
            button = <LockButton onClick={() => { lockbuttonHandler(props.id, props.loadData) }} >Lock</LockButton>
        }
        return (<IsLockedDiv>
            {button}
        </IsLockedDiv>
        )
    }
    const resetPasswordHandler = async (email, reloadData) => {
        try {
            let result = await axios.get(api_url.removePasswordByAdmin(email));
            if (result.status === 200) {                
                reloadData()
            }
            reloadData()
        } catch (error) {
            console.log(error);
        }
    }
    const resetPasswordButton = () => {
        let resetButton;
    if (props.hasPassword) {
      resetButton =   <ResetPasswordButton onClick={() => resetPasswordHandler(props.email, props.loadData)} >Reset Password</ResetPasswordButton>
    } else resetButton = <ResetPasswordButtonDisabled>Was resetted</ResetPasswordButtonDisabled>
        return resetButton;
    }
    return (
        <>
            <MainUser>
                <UserNameDiv>{props.userName}</UserNameDiv>
                <EmailDiv>{props.email}</EmailDiv>
                {ShowOrderButton()}
                {resetPasswordButton()}
                {lockButton()}
            </MainUser>
            {showOrder && <AdminOrders email={props.email} />}
        </>
    )
}
export default User;