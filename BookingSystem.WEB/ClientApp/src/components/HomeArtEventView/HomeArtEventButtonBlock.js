import React, { Fragment } from "react";

import AddButton_ReduxWrapped from "../Cart/cartButton/AddButton";
import { useNavigate } from "react-router-dom";
import styled from "styled-components";
import { BlueButton } from "../StyledComponent/Button/BlueButton";


// const BlueButton = styled.button`
//     border: 0;
//     background-color: rgba(30, 117, 204, 0.877);
//     border-radius: 3% 3%;
   
//     margin: 0.5rem 3%;
//     height: 10%;; 
// `;




const HomeArtEventButtonBlock = (props) => {
    // console.log(props);
    const navigate = useNavigate();
    return <Fragment>
        <AddButton_ReduxWrapped id={props.item.id}  />
        <BlueButton onClick={() => navigate(`/details/${props.item.id}`)}>Details</BlueButton>
    </Fragment>
}
export default HomeArtEventButtonBlock;