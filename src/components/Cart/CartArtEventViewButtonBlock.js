import React from "react";
import ChangeValueInCartButton_ReduxWrapped from "./cartButton/changeValueInCartButton";
import DeleteFromCartButton_ReduxWrapped from "./cartButton/DeleteFromCartButton";

const CartArtEventViewButtonBlock = (props) => {
    return <>
        <ChangeValueInCartButton_ReduxWrapped {...props} />
        <DeleteFromCartButton_ReduxWrapped id={props.id}/>
    </>
}
export default CartArtEventViewButtonBlock;