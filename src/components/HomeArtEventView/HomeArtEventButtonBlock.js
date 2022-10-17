import React from "react";
import AddOrChangeValueButton_ReduxWrapped from "../Cart/cartButton/AddOrChangeValueButton";
import { DetailsButton } from "../Buttons/DetailsButton"

const HomeArtEventButtonBlock = (props) => {

    return (
        <>
            <AddOrChangeValueButton_ReduxWrapped {...props}/>
            <DetailsButton id={props.id}>Details</DetailsButton>
        </>
    )
}
export default HomeArtEventButtonBlock;