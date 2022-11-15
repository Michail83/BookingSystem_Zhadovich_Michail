import React from "react";
import { useNavigate, useLocation } from "react-router-dom";
import { connect } from 'react-redux';

import LogInOutManager_connected from "../LoginOutManager/LoginOutManager.js"
import ModalWindowForLogin_ReduxWrapped from "../ModalWindowForLogin/ModalWindowForLogin";
import DisplayUserName_ReduxWrapped from "../DisplayUserName/DisplayUserName";


import {Navbar,UserNameField,NavBarItem, MainUniversalHeader,LogInOutItem} from "../StyledComponent/Header/HeaderStyledComponent"

const UniversalHeader = ({cartMap, isAuth }) => {
    const location = useLocation();
    const navigate = useNavigate();
    return (
        <MainUniversalHeader>
            <UserNameField>
                <ModalWindowForLogin_ReduxWrapped />                
            </UserNameField>
            <Navbar>
                <NavBarItem onClick={() => navigate("/")} navPath="/" currentPath={location.pathname} >Events</NavBarItem>
                {cartMap.size != 0 ? <NavBarItem onClick={() => navigate("/cart")} navPath="/cart" currentPath={location.pathname}>Cart </NavBarItem> : ""}                
                {isAuth ? <NavBarItem onClick={() => navigate("/orders")} navPath="/orders" currentPath={location.pathname}>Orders</NavBarItem> : ""}
                <LogInOutItem>
                    <DisplayUserName_ReduxWrapped />
                    <LogInOutManager_connected />
                </LogInOutItem>
            </Navbar >
        </MainUniversalHeader>
    )
}

const mapStateToProps = state => ({
    
    cartMap: state.cart.cartMap,
    isAuth: state.auth.isAuthenticated

});

var UniversalHeader_ReduxWrapped = connect(mapStateToProps, null)(UniversalHeader);
export default UniversalHeader_ReduxWrapped;