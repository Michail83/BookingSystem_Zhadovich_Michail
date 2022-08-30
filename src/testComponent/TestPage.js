


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

import { YMaps, Map, Placemark } from "react-yandex-maps";
import YandMap_ReduxWrapped from "../components/YandMAP/YandMAP";
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

    return (
        <MainDiv>
            <YMaps>                
                <div>                    
                    <Map defaultState={{ 
                        center: [53.89364559280405,27.567232262565565], 
                        zoom: 9,
                        controls: ['zoomControl', 'fullscreenControl'],
                        }}
                        modules={['control.ZoomControl', 'control.FullscreenControl', 'geoObject.addon.balloon', 'geoObject.addon.hint']}
                    >
                        <Placemark
                        modules={['geoObject.addon.balloon']}
                        defaultGeometry={[53.89364559280405,27.567232262565565]}
                        properties= {{
                            balloonContentHeader: "1balloonContentHeader",
                            balloonContentBody: "test balloonContentBody",
                            balloonContentFooter: "balloonContentFooter",
                            hintContent: "test hintContent"
                        }}
                        options ={{
                            preset : 'islands#redIcon',                            
                        }}
                        />
                         <Placemark
                        modules={['geoObject.addon.balloon']}
                        defaultGeometry={[53.902575777784925,27.561308296096712]}
                        properties= {{
                            balloonContentHeader: "ПРА!!!",
                            balloonContentBody: "ПЛО!!!!!!",
                            balloonContentFooter: "ЗАВ!!!!",
                            hintContent: "HINT"
                        }}
                        options ={{
                            preset : 'islands#icon',                        
                        }}
                        />
                        </Map>
                </div>
            </YMaps>
            <button  onClick={()=>localStorage.clear()} >Clear localStorage</button>
            <button  onClick={()=>console.log(process.env.NODE_ENV)} >Get NODE_ENV</button>
            
            <AbsoluteMessage>WARNING TEST</AbsoluteMessage>
            {console.log(createArrayWithPageNumber(10, 100,10, 2,1))}
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

