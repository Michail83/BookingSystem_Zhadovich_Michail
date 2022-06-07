import React, {useState, useRef, useCallback, Fragment} from "react"
import { connect } from "react-redux";
// import debounce from "lodash.debounce"

import checkCartItemQuerry from "../JsFunction/CheckCartItemQuerry";
import './changeValueButton.css'
import axios from "axios";


import actionCreator from "../../../Store/ActionsCreators/actionCreator";
// import { useState } from "react";



const ChangeValueInCartButton = ({ curentReduxValue, setCurrentReduxValue, deleteFromCart, deleteFromCartArray, id, amounOfTicket})=>{
//    console.log(id, amounOfTicket);
    
    function onFormClick(event, id) { 
        // let test = event;

         /*console.log(event.target.id) */

        switch (event.target.id) {
            case "increment":{
                // проверка значения на сервере
                if (curentReduxValue<amounOfTicket) {
                    setCurrentReduxValue(id,curentReduxValue+1)
                }                
            }                
                break;
            case "decrement":{
                // проверка значения на сервере
                if (curentReduxValue>1) {
                    setCurrentReduxValue(id,curentReduxValue-1)
                }
            }                
                 break;
            case "input":               
                break;
        
            default:
                break;
        }        
    }

    function onInputHandler(event, id ) {
            let newValue =  Number.parseInt(event.target.value, 10 );
        
            if (Number.isNaN(newValue) || newValue>amounOfTicket || newValue<1 ) {
                console.log("catch   !!!NaN!!!!   or invalid number")
            } else{
                setCurrentReduxValue(id, newValue)
            }        
    }


    // function onInputHandler(event, id ) {
              
    //     let newValue =  Number.parseInt(event.target.value, 10 );

        
    //     if (Number.isNaN(newValue) || newValue>maxValue || newValue<1 ) {
    //         console.log("catch   !!!NaN!!!!   or invalid number")
    //     } else{
    //         setCurrentReduxValue(id, newValue)
    //     }
    // }
    
    return (
        <Fragment>
            <form className="changeValueButtonGroup" onClick={(event) => onFormClick(event, id)}>
                <button id="decrement" disabled={curentReduxValue < 2} type="button">-</button>
                <input id="input" onInput={(event) => onInputHandler(event, id)} onFocus={(event) => event.target.select()} type="text" min='1' max='100' value={curentReduxValue} />
                <button id="increment" disabled={curentReduxValue > amounOfTicket - 1} type="button">+</button>
            </form>
            <button id="deletefromcart" onClick={() => { deleteFromCart(id); deleteFromCartArray(id);  }}>delete </button>
        </Fragment>
    )
}

const mapStateToProps=(state,ownProps)=> ({  
    curentReduxValue: state.cart.cartMap.get(ownProps.id)
 }); 

const mapDispatchToProps=dispatch=> (
{        
        setCurrentReduxValue: (id, value) => (dispatch(actionCreator.changeCartItemValue({ id: id, quantity: value }))),
        deleteFromCart: (id) => (dispatch(actionCreator.deleteFromCart(id))),
        deleteFromCartArray: (id) => dispatch(actionCreator.deleteFromCartArray(id))

});

var ChangeValueInCartButton_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(ChangeValueInCartButton);

export default ChangeValueInCartButton_ReduxWrapped;



// function test () {
//     var t;
  
//     $('#text-src').on('input', function(){
//       clearTimeout(t);
  
//       t = setTimeout(function(input) {
//         $('#text-dest').val($(input).val());
//       }, 1000, this);	
//     })
//   };