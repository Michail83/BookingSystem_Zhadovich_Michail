import React, {useState, useRef, useCallback} from "react"
import { connect } from "react-redux";
// import debounce from "lodash.debounce"

import checkCartItemQuerry from "../JsFunction/CheckCartItemQuerry";
import './changeValueButton.css'
import axios from "axios";


import actionCreator from "../../../Store/ActionsCreators/actionCreator";
// import { useState } from "react";



const ChangeValueInCartButton =({curentReduxValue,setCurrentReduxValue, id, maxValue})=>{
   
    
    function onFormClick(event, id) { 
        // let test = event;

         console.log(event.target.id) 

        switch (event.target.id) {
            case "increment":{
                // проверка значения на сервере
                if (curentReduxValue<maxValue) {
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
        
            if (Number.isNaN(newValue) || newValue>maxValue || newValue<1 ) {
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
        <form className="changeValueButtonGroup" onClick={(event)=>onFormClick(event,id)}>
            <button id="decrement" disabled={curentReduxValue<2} type="button">-</button>

            <input id="input" onInput={(event)=>onInputHandler(event,id)} onFocus={(event)=> event.target.select()} type= "text" min='1' max='100' value={curentReduxValue} />

            <button id="increment" disabled={curentReduxValue>maxValue-1} type="button">+</button>           
        </form>
    )
}

const mapStateToProps=(state,ownProps)=> ({  
    curentReduxValue : state.cartMap.get(ownProps.id)       
 }); 

const mapDispatchToProps=dispatch=> (
{        
    setCurrentReduxValue: (id, value) => (dispatch(actionCreator.changeCartItemValue({id:id,quantity:value }) )),

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