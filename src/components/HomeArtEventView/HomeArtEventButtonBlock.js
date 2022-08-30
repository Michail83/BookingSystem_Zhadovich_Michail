import React, { Fragment } from "react";
import { useNavigate } from "react-router-dom";
import { BlueButton } from "../StyledComponent/Button/BlueButton";
import AddOrChangeValueButton_ReduxWrapped from "../Cart/cartButton/AddOrChangeValueButton";

const HomeArtEventButtonBlock = (props) => {

    const navigate = useNavigate();
    return <Fragment>
        <AddOrChangeValueButton_ReduxWrapped id={props.id} amountOfTickets={props.amountOfTickets} />
        <BlueButton onClick={() => navigate(`/details/${props.id}`)}>Details</BlueButton>
    </Fragment>
}
export default HomeArtEventButtonBlock;