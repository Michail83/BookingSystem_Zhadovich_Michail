import React from "react";
import AddOrChangeValueButton_ReduxWrapped from "../Cart/cartButton/AddOrChangeValueButton";
import { DetailsButton } from "../Buttons/DetailsButton"

const HomeArtEventButtonBlock = (props) => {

    return (
        <>
            <AddOrChangeValueButton_ReduxWrapped id={props.id} amountOfTickets={props.amountOfTickets} />
            <DetailsButton id={props.id}>Details</DetailsButton>
        </>
    )
}
export default HomeArtEventButtonBlock;