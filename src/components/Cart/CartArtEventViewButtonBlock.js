import React, { Fragment } from "react";
import ChangeValueInCartButton_ReduxWrapped from "./cartButton/changeValueInCartButton";
import DeleteFromCartButton_ReduxWrapped from "./cartButton/DeleteFromCartButton";





const CartArtEventViewButtonBlock = (props) => {

    return <Fragment>
        <ChangeValueInCartButton_ReduxWrapped id={props.id} amountOfTickets={props.amountOfTickets}/>
        <DeleteFromCartButton_ReduxWrapped id={props.id}/>
    </Fragment>
}
export default CartArtEventViewButtonBlock;