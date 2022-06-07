import React, { Fragment } from "react";

import AddButton_ReduxWrapped from "./cartButton/AddButton";
import { useNavigate } from "react-router-dom";
import styled from "styled-components";
import { BlueButton } from "../StyledComponent/Button/BlueButton";
import ChangeValueInCartButton_ReduxWrapped from "./cartButton/changeValueInCartButton";





const CartArtEventViewButtonBlock = (props) => {
//    console.log(props);
    // const navigate = useNavigate();
    return <Fragment>
        <ChangeValueInCartButton_ReduxWrapped {...props.item}/>
    </Fragment>
}
export default CartArtEventViewButtonBlock;