import {React,Fragment} from "react";
import { connect } from "react-redux";

import AddButton_ReduxWrapped from "./AddButton";
import ChangeValueInCartButton_ReduxWrapped from "./changeValueInCartButton";
import DeleteFromCartButton_ReduxWrapped from "./DeleteFromCartButton";


const AddOrChangeValueButton = ({id, amountOfTickets, IsExistInCart }) => {
    
    console.log(amountOfTickets);
let result;
if (IsExistInCart) {
    result = 
    <Fragment>
        <ChangeValueInCartButton_ReduxWrapped id={id} amountOfTickets={amountOfTickets}/>
        
        <DeleteFromCartButton_ReduxWrapped id={id}/>
    </Fragment>    
} else {
    result = <AddButton_ReduxWrapped id={id} amountOfTickets={amountOfTickets}/>    
}
    return (
        result
    )
}

const mapStateToProps = (state, ownProps) => ({
    IsExistInCart: state.cart.cartMap.has(ownProps.id)
});

var AddOrChangeValueButton_ReduxWrapped = connect(mapStateToProps, null)(AddOrChangeValueButton);

export default AddOrChangeValueButton_ReduxWrapped;