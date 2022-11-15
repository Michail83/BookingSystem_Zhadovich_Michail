


import React, { useState, useEffect, useRef } from "react";
// import { Link, useNavigate } from "react-router-dom"
// import "../UniversalHeader/UniversalHeader"
import axios from "axios";
// import LogoutBtn from "../Logout/LogoutBtn"
// import urls from "../../API_URL"
// import state from '../../Store/store'
import { connect } from "react-redux";
// import SetIsAuthenticated from "../Store/ActionsCreators/SetIsAuthenticated";
import actionCreator from "../Store/ActionsCreators/actionCreator";
import store from "../Store/store";

import ButtonWith from "../components/Cart/cartButton/AddButton"
import urls from "../API_URL";


import { YMaps, Map, Placemark } from "react-yandex-maps";
import YandMap, { YandMAP_TEST } from "../components/YandMAP/YandMAP_TEST";
import YandMAP_TEST_JS  from "../components/YandMAP/YandMAP_CreateEvent";

import ReactDOM from "react-dom";
import * as keys from "../CONST/KeysForLocalStorage"


/*import parseMapFromJson from "../function/parseMapFromJson"*/
import { parseMapFromJson } from "../function/getCartMapFromLocalStorage";
import styled from "styled-components";

import createArrayWithPageNumber from "../components/PaginationPanel/CreateArrayWithPageNumber"

const MainDiv = styled.div`
margin-top: 15vh;
`;

const AbsoluteMessage = styled.div`
    position: absolute;
    z-index:1000;
    opacity:0.4;
    font-size: 6vw;
    color: pink;
    top:45%;
    left: 45%;
`;



const TestPage = ({ IsAuthenticated, state, onClickTrue, onClickFalse, allCart, changeCart, iSmodalLoginWindowActive }) => {
    // const [name, setName] = useState("NoAnswer");
    // const [logInfo, setlogInfo] = useState("NoLog");
    /*const [storage, setStorage] = useState("None");*/

    //console.log("ReRender TestPage");
    //console.log(state);
    // console.log(actionCreator.setIsAuthenticated(true));
    //let element = allCart.map((cart)=><p key={cart.id}>ID  {cart.id} =  {cart.quantity} </p>)

    //console.log(element);
    // const load = async () => {

    //     try {
    //         let result = await axios.get("https://localhost:5001/api/admin/testuser");
    //         setName(result.data)
    //     } catch (e) {
    //         console.log(e);
    //         console.log("error on test    /api/admin/testuser");
    //     }
    // }
    // const loadLogInfo = async () => {

    //     try {
    //         let result = await axios.get("https://localhost:5001/account/LogInfo");
    //         setlogInfo(result.data)
    //     } catch (e) {
    //         console.log(e);
    //         console.log("error on test    /account/LogInfo");
    //     }
    // }

    // const logLocalStorage = () => {
    //     let json_cartMap = localStorage.getItem("cart");

    //     console.log(json_cartMap);
    //     let cartMap = parseMapFromJson(json_cartMap);
    //     console.log(cartMap);
    // }

    const ref1 = useRef();
    const ref2 = useRef();


    return (
        <MainDiv>

            {/* <YandMAP_TEST_JS>

            </YandMAP_TEST_JS> */}
            
            <button  onClick={()=>localStorage.clear()} >Clear localStorage</button>
            <button  onClick={()=>console.log(process.env.NODE_ENV)} >Get NODE_ENV</button>
     
            <button onClick={()=>{store.dispatch(actionCreator.changeCartItemValue({id:47, quantity:""})) }}>send to cart</button>
            <div>
                <span></span>
                <span></span>
            </div>
            
            
            <AbsoluteMessage>WARNING TEST</AbsoluteMessage>            
        </MainDiv> 
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

