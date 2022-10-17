import React, { useEffect } from "react"
import { connect } from "react-redux";
import actionCreator from "../../../Store/ActionsCreators/actionCreator";

import styled from "styled-components";

const FormForButton = styled.form`
    border-radius: 2px;
    border: 0;
    display:flex;
    flex-flow: row nowrap;
    width: auto;
    margin: 0.5rem;
    max-width: 200px;
    box-sizing: border-box;
    & :first-child{ margin-left: auto;}
    & :last-child{margin-right: auto; }
    
    & input,button{
        box-sizing: border-box;
    }
    & input{
        width: 75%;
        &:focus{            
            outline:none;
        }
    }
    & button{        
        width: 25px;
    }
`;
const PriceWrap =styled.div`
    margin: 0.5rem;
`;
const ChangeValueInCartButton = ({ curentReduxValue, setCurrentReduxValue, id, price, amountOfTickets, deleteFromCart, deleteFromCartArray }) => {

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

    function onInputHandler(event, id, input) {
        let newValue = Number.parseInt(event.target.value, 10);

        if (Number.isNaN(newValue) || newValue < 1) {
        } else {
            if (newValue > amountOfTickets) {
                setCurrentReduxValue(id, amountOfTickets)
            } else {
                setCurrentReduxValue(id, newValue)
            }
        }
    }

    return (
        <>
            <FormForButton id="ChangeValueInCartButton" onClick={(event) => onFormClick(event, id)}>
                <button id="decrement" disabled={curentReduxValue < 2} type="button">-</button>
                <input id="input" onInput={(event) => onInputHandler(event, id)} onFocus={(event) => event.target.select()} type="text" min='1' max='100' value={curentReduxValue} />
                <button id="increment" disabled={curentReduxValue >= amountOfTickets} type="button">+</button>
            </FormForButton>
            <PriceWrap>Total cost: {curentReduxValue*price} USD</PriceWrap>
            
        </>
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