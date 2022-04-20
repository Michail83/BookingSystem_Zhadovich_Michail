


import React, { useState, useEffect } from "react";
// import { Link, useNavigate } from "react-router-dom"
// import "../UniversalHeader/UniversalHeader"
import axios from "axios";
// import LogoutBtn from "../Logout/LogoutBtn"
// import urls from "../../API_URL"
// import state from '../../Store/store'
import { connect } from "react-redux";
// import SetIsAuthenticated from "../Store/ActionsCreators/SetIsAuthenticated";
import actionCreator from "../Store/ActionsCreators/actionCreator";
// import store from "../Store/store";
// import state from '../Store/store'
// import store from "../Store/store";
import ButtonWith from "../components/Cart/cartButton/AddButton"
import urls from "../API_URL"

import * as keys from "../CONST/KeysForLocalStorage"


/*import parseMapFromJson from "../function/parseMapFromJson"*/
import { parseMapFromJson } from "../function/getCartMapFromLocalStorage"





const TestPage = ({ IsAuthenticated, state, onClickTrue, onClickFalse, allCart, changeCart, iSmodalLoginWindowActive }) => {
    const [name, setName] = useState("NoAnswer");
    const [logInfo, setlogInfo] = useState("NoLog");
    /*const [storage, setStorage] = useState("None");*/

    //console.log("ReRender TestPage");
    //console.log(state);
    // console.log(actionCreator.setIsAuthenticated(true));
    //let element = allCart.map((cart)=><p key={cart.id}>ID  {cart.id} =  {cart.quantity} </p>)

    //console.log(element);
    const load = async () => {

        try {
            let result = await axios.get("https://localhost:5001/api/admin/testuser");
            setName(result.data)
        } catch (e) {
            console.log(e);
            console.log("error on test    /api/admin/testuser");
        }
    }
    const loadLogInfo = async () => {

        try {
            let result = await axios.get("https://localhost:5001/account/LogInfo");
            setlogInfo(result.data)
        } catch (e) {
            console.log(e);
            console.log("error on test    /account/LogInfo");
        }
    }

    const logLocalStorage = () => {
        let json_cartMap = localStorage.getItem("cart");

        console.log(json_cartMap);
        let cartMap = parseMapFromJson(json_cartMap);
        console.log(cartMap);
    }

    return (
        <div>
            <p>IsAuthenticated  {IsAuthenticated + ''}</p>

            <button type="button" onClick={onClickTrue}> true </button>
            <button type="button" onClick={onClickFalse}> false </button>
            <button type="button" onClick={logLocalStorage}> getStorage </button>
                        

            {/*{element}*/}
            <ButtonWith id={2} />

            <p>iSmodalLoginWindowActive  {iSmodalLoginWindowActive + ''}</p>
            <p onClick={load} >Name from {name}</p>
            <p onClick={loadLogInfo} >logInfo     {logInfo}</p>

            <button onClick={()=>localStorage.removeItem(keys.localStorage_cartMap)}>Clear Storage</button>

        </div>
    )
}

const mapStateToProps = state => ({
    IsAuthenticated: state.auth.isAuthenticated,
    
    iSmodalLoginWindowActive: state.iSmodalLoginWindowActive
});

const mapDispatchToProps = dispatch => (
    {
        onClickTrue: () => dispatch(actionCreator.setAuth({
            isAuthenticated: true,
        })),
        onClickFalse: () => dispatch(actionCreator.setAuth({
            isAuthenticated: false,
        }
        )),
        // changeCart: ()=> dispatch(
        //     actionCreator.addToCart({id:11, quantity:100}))
    });

var Testpageauth = connect(mapStateToProps, mapDispatchToProps)(TestPage);
export default Testpageauth;







// export const setCartMapToLocalStorage = (cartMap) => {
//     if (cartMap.size) {
//         let cart_obj = Object.fromEntries(cartMap.entries());
//         localStorage.setItem(keys.localStorage_cartMap, JSON.stringify(cart_obj));
//     } else {
//         localStorage.removeItem(keys.localStorage_cartMap);
//     }

    

// }
 






//previous




//import React, {useState, useEffect} from "react";
//// import { Link, useNavigate } from "react-router-dom"
//// import "../UniversalHeader/UniversalHeader"
//// import axios from "axios";
//// import LogoutBtn from "../Logout/LogoutBtn"
//// import urls from "../../API_URL"
//// import state from '../../Store/store'
//import { connect } from "react-redux";
//// import SetIsAuthenticated from "../Store/ActionsCreators/SetIsAuthenticated";
//import actionCreator from "../Store/ActionsCreators/actionCreator";
//// import store from "../Store/store";
//// import state from '../Store/store'
//// import store from "../Store/store";
//import ButtonWith from "../components/Cart/cartButton/AddButton" 





//const TestPage = ({ IsAuthenticated, state, onClickTrue, onClickFalse, cartMap, changeCart })=>{
//    console.log("ReRender TestPage");
//    console.log( state);
//    // console.log(actionCreator.setIsAuthenticated(true));
//    //let element = allCart.map((cart)=><p key={cart.id}>ID  {cart.id} =  {cart.quantity} </p>)
  
//    //console.log(element);

//return (
//    <div>
//    <p>IsAuthenticated  {IsAuthenticated+''}</p> 
//    <button type="button" onClick={onClickTrue}> true </button> 
//    <button type="button" onClick={onClickFalse}> false </button>
//    {/*{element}*/}
//    <ButtonWith id={2}/>
//    </div>
//)}

// const mapStateToProps=state=> ({    
//    IsAuthenticated: state.isAuthenticated,
//     cartMap:  state.cartMap,
//    state:state,        
// });

//const mapDispatchToProps=dispatch=> (
//{        
//    onClickTrue: () => dispatch(actionCreator.setIsAuthenticated(true)),
//    onClickFalse: () => dispatch(actionCreator.setIsAuthenticated(false)),
//    // changeCart: ()=> dispatch(
//    //     actionCreator.addToCart({id:11, quantity:100}))
//});

//var Testpageauth = connect(mapStateToProps, mapDispatchToProps)(TestPage);
//export default Testpageauth;