import React, { useState, useRef, useCallback, Fragment, useEffect } from "react"
import { connect } from "react-redux";
// import debounce from "lodash.debounce"

import checkCartItemQuerry from "../JsFunction/CheckCartItemQuerry";
import './changeValueButton.css'
import axios from "axios";


import actionCreator from "../../../Store/ActionsCreators/actionCreator";

import styled from "styled-components";

const MainBlock = styled.div`
    display: flex;
    flex-flow: column wrap;
    justify-content: space-around;
    /* align-items: center; */
    height: 100%;
    box-sizing: border-box;
    flex-basis: 90%;
`;
const FormForButton = styled.form`
    border-radius: 2px;
    display:flex;
    flex-flow: row nowrap;
    & :first-child{ margin-left: auto;}
    & :last-child{margin-right: auto; }
    
    & input,button{
        box-sizing: border-box;
    }
    & input{
        width: 60%;
    }
    & button{        
        width: 15%;
    }
`;

const DeleteButton = styled.div`
    text-align: center;
    color: white;
    opacity: 0.1;
    background-color: red;
    transition: 1s;
    border-radius: 4px;
    cursor: pointer;
    
    &:hover{
        opacity: 1;        
    }
`;
const ChangeValueInCartButton = ({ curentReduxValue, setCurrentReduxValue, deleteFromCart, deleteFromCartArray, id, amountOfTickets }) => {

    useEffect(() => {
        if (!curentReduxValue) {
            console.log('Errors were deleted from the CART!!!!!!');
            deleteFromCart(id);
            deleteFromCartArray(id);
        }
        if (curentReduxValue > amountOfTickets) {
            setCurrentReduxValue(id, amountOfTickets);
        }
    }, []);

    function onFormClick(event, id) {
        switch (event.target.id) {
            case "increment": {
                if (curentReduxValue < amountOfTickets) {
                    setCurrentReduxValue(id, curentReduxValue + 1)
                }
            }
                break;
            case "decrement": {
                if (curentReduxValue > 1) {
                    setCurrentReduxValue(id, curentReduxValue - 1)
                }
            }
                break;
            case "input":
                break;

            default:
                break;
        }
    }

    function onInputHandler(event, id) {
        let newValue = Number.parseInt(event.target.value, 10);

        if (Number.isNaN(newValue) || newValue > amountOfTickets || newValue < 1) {
            console.log("catch   !!!NaN!!!!   or invalid number")
        } else {
            setCurrentReduxValue(id, newValue)
        }
    }

    return (
        <MainBlock>
            <FormForButton className="changeValueButtonGroup" onClick={(event) => onFormClick(event, id)}>
                <button id="decrement" disabled={curentReduxValue < 2} type="button">-</button>
                <input id="input" onInput={(event) => onInputHandler(event, id)} onFocus={(event) => event.target.select()} type="text" min='1' max='100' value={curentReduxValue} />
                <button id="increment" disabled={curentReduxValue >= amountOfTickets} type="button">+</button>
            </FormForButton>
            <DeleteButton id="deletefromcart" onClick={() => { deleteFromCart(id); deleteFromCartArray(id); }}>DELETE </DeleteButton>
        </MainBlock>
    )
}

const mapStateToProps = (state, ownProps) => ({
    curentReduxValue: state.cart.cartMap.get(ownProps.id)
});

const mapDispatchToProps = dispatch => (
    {
        setCurrentReduxValue: (id, value) => (dispatch(actionCreator.changeCartItemValue({ id: id, quantity: value }))),
        deleteFromCart: (id) => (dispatch(actionCreator.deleteFromCart(id))),
        deleteFromCartArray: (id) => dispatch(actionCreator.deleteFromCartArray(id))
    });

var ChangeValueInCartButton_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(ChangeValueInCartButton);

export default ChangeValueInCartButton_ReduxWrapped;