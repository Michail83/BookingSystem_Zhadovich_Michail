import React, { useState } from "react";
import Cart from "./Cart";
import styled from "styled-components";
import {useNavigate } from "react-router-dom";

import { BlueButton } from "../StyledComponent/Button/BlueButton";


const Message = styled.div`
    font-size: 2rem;    
`;
const СustomizedBlueButton = styled(BlueButton)`
    text-align: center;

`;
const ButtonBlock = styled.div`
display: flex;
justify-content: center;
`;

const WrapFor_Cart_SuccessHandler = () => {
    const [isSuccess, setIsSuccess] = useState();
    const navigate = useNavigate();

    var result;
    if (isSuccess == undefined) {
        result = <Cart setIsSuccess={setIsSuccess} />
    }
    else if (isSuccess == true) {
        result = <div>
            <Message>Order was created successfully. See additional information on your email</Message>
            <ButtonBlock><СustomizedBlueButton onClick={()=>navigate("/")}>Events</СustomizedBlueButton></ButtonBlock>
            </div>
    } else {
        result = <div>
            <Message>Error. try later</Message>
            <ButtonBlock><СustomizedBlueButton onClick={() => setIsSuccess()}>Again</СustomizedBlueButton></ButtonBlock>
        </div>
    }

    return (
        <>
            {result}
        </>
    )
}
export default WrapFor_Cart_SuccessHandler;