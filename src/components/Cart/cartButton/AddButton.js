import React from "react";
import { connect } from "react-redux";
import actionCreator from "../../../Store/ActionsCreators/actionCreator";
import { BlueButton } from "../../StyledComponent/Button/BlueButton";

const AddButton = ({ id,amountOfTickets, active, submitHandler }) => {

    return (
        <BlueButton
            disabled={active || !amountOfTickets}
            style={active || !amountOfTickets ? { backgroundColor: "lightgray" } : {}}
            onClick={() => { submitHandler(id) }}
            type="button"
        >Add to cart</BlueButton>
    )
}

const mapStateToProps = (state, ownProps) => ({
    active: state.cart.cartMap.has(ownProps.id),    
});
const mapDispatchToProps = dispatch => (
    {
        submitHandler: (id) => dispatch(actionCreator.addToCart(id)),
    });

var AddButton_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(AddButton);

export default AddButton_ReduxWrapped;