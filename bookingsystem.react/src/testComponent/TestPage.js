

import React, {useState, useEffect} from "react";
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





const TestPage = ({ IsAuthenticated, state, onClickTrue, onClickFalse, allCart, changeCart, iSmodalLoginWindowActive }) => {
    const [name, setName] = useState("NoAnswer");
    console.log("ReRender TestPage");
    console.log( state);
    // console.log(actionCreator.setIsAuthenticated(true));
    //let element = allCart.map((cart)=><p key={cart.id}>ID  {cart.id} =  {cart.quantity} </p>)
  
    //console.log(element);
    const load =async () => {

        try {
            let result = await axios.get("https://localhost:44324/api/admin/testuser");
            setName(result.data)
        } catch (e) {
            console.log(e);
            console.log("error on test    /api/admin/testuser");
        }
    }

return (
    <div>
        <p>IsAuthenticated  {IsAuthenticated + ''}</p>

    <button type="button" onClick={onClickTrue}> true </button> 
    <button type="button" onClick={onClickFalse}> false </button>
    {/*{element}*/}
        <ButtonWith id={2} />

        <p>iSmodalLoginWindowActive  {iSmodalLoginWindowActive + ''}</p>
        <p onClick={load} >Name from {name}</p>
    </div>
)}

 const mapStateToProps=state=> ({    
    IsAuthenticated: state.isAuthenticated,
    /*allCart:  state.cartMap,*/
     state: state,
     iSmodalLoginWindowActive: state.iSmodalLoginWindowActive
 });

const mapDispatchToProps=dispatch=> (
{        
    onClickTrue: () => dispatch(actionCreator.setIsAuthenticated(true)),
    onClickFalse: () => dispatch(actionCreator.setIsAuthenticated(false)),
    // changeCart: ()=> dispatch(
    //     actionCreator.addToCart({id:11, quantity:100}))
});

var Testpageauth = connect(mapStateToProps, mapDispatchToProps)(TestPage);
export default Testpageauth;