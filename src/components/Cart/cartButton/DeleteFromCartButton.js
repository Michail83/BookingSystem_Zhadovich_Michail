import React from "react"
import { connect } from "react-redux";
import actionCreator from "../../../Store/ActionsCreators/actionCreator";
import { RedButton } from "../../StyledComponent/Button/RedButton";

// import styled from "styled-components";

const DeleteFromCartButton = ({id, deleteFromCart, deleteFromCartArray}) => {
    return (
        <RedButton id="DeleteFromCartButton" onClick={() => { deleteFromCart(id); deleteFromCartArray(id); }}>DELETE </RedButton>
    )
}
const mapStateToProps = (state) => ({    
});

const mapDispatchToProps = dispatch => (
    {       
        deleteFromCart: (id) => (dispatch(actionCreator.deleteFromCart(id))),
        deleteFromCartArray: (id) => dispatch(actionCreator.deleteFromCartArray(id))
    });

var DeleteFromCartButton_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(DeleteFromCartButton);

export default DeleteFromCartButton_ReduxWrapped;