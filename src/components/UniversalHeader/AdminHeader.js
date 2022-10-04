import React from "react";
import { useNavigate, useLocation } from "react-router-dom";
import { connect } from 'react-redux';


import LogInOutManager_connected from "../LoginOutManager/LoginOutManager.js"
import ModalWindowForLogin_ReduxWrapped from "../ModalWindowForLogin/ModalWindowForLogin";
import DisplayUserName_ReduxWrapped from "../DisplayUserName/DisplayUserName";

import styled from "styled-components";

import {Navbar,UserNameField,NavBarItem, MainUniversalHeader,LogInOutItem} from "../StyledComponent/Header/HeaderStyledComponent"

const AdminHeader = ({cartMap, isAuth }) => {
    const location = useLocation();
    const navigate = useNavigate();
    return (
        <MainUniversalHeader>
            <UserNameField>
                <ModalWindowForLogin_ReduxWrapped />                
            </UserNameField>
            <Navbar>
                <NavBarItem onClick={() => navigate("/Create")} navPath="/Create" currentPath={location.pathname}>Create Event</NavBarItem> 
                <NavBarItem onClick={() => navigate("/")} navPath="/" currentPath={location.pathname} >Events</NavBarItem>
                <NavBarItem onClick={() => navigate("/users")} navPath="/users" currentPath={location.pathname} >Users</NavBarItem>
                              
                
                <LogInOutItem>
                    <DisplayUserName_ReduxWrapped />
                    <LogInOutManager_connected />
                </LogInOutItem>
            </Navbar >
        </MainUniversalHeader>
    )
}

const mapStateToProps = state => ({
    // isAdmin: state.auth.isAdmin,
    cartMap: state.cart.cartMap,
    isAuth: state.auth.isAuthenticated

});
const mapDispatchToProps = dispatch => (
    {
    });
var AdminHeader_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(AdminHeader);
export default AdminHeader_ReduxWrapped;

                // {/* {isAdmin ? <NavBarItem onClick={() => navigate("/Create")} navPath="/Create" currentPath={location.pathname}>Create Event</NavBarItem> : ""} */}
                // {false ? <NavBarItem onClick={() => navigate("/test")} navPath="/test" currentPath={location.pathname} >TestPage</NavBarItem> : ""}

                // {cartMap.size != 0 ? <NavBarItem onClick={() => navigate("/cart")} navPath="/cart" currentPath={location.pathname}>Cart </NavBarItem> : ""}  

                // {isAuth ? <NavBarItem onClick={() => navigate("/orders")} navPath="/orders" currentPath={location.pathname}>Orders</NavBarItem> : ""}