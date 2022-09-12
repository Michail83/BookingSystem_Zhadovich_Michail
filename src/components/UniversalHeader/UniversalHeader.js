import React from "react";
import { useNavigate, useLocation } from "react-router-dom";
import { connect } from 'react-redux';


import LogInOutManager_connected from "../LoginOutManager/LoginOutManager.js"
import ModalWindowForLogin_ReduxWrapped from "../ModalWindowForLogin/ModalWindowForLogin";
import DisplayUserName_ReduxWrapped from "../DisplayUserName/DisplayUserName";
import styled from "styled-components";

const MainUniversalHeader = styled.div`
    position: fixed;
    box-sizing: border-box;
    top: 0rem;
    z-index: 1000;
    width: 100%;
    height: 6rem;
    background-color: white;
    padding: 0 1rem 1rem 1rem;
    margin: 0;   
`;
const Navbar = styled.div`
    background-color: lightskyblue;
    text-align: center; 
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
    height: 60px;  
    border-radius: 3px;  

    

    /* & div {    
    margin: 5px;
    padding: 2px;
    border: 0px solid black;
    border-radius: 3px;
    font-size: 1.5rem;        
}    */
    & div:first-child{
        margin-left: auto;
    }
    & div:last-child{
        margin-left: auto;
        background-color:lightskyblue; 
    }
`;
const UserNameField = styled.div`    
    margin: 1vw 1vh;
    display: flex;
    flex-direction: row;
    justify-content: end;
    align-items:flex-start
`;
const BaseNavBarItem = styled.div`
    margin: 5px;
    padding: 2px;
    border: 0px solid black;
    border-radius: 3px;
    
`;

const NavBarItem = styled(BaseNavBarItem)`
    width: 13%;
    cursor: pointer; 
    font-size: 1.5rem;  
    
    background-color: ${({ navPath, currentPath }) => navPath == currentPath ? "royalblue" : "white"};
    &:hover{
        background-color:royalblue
    }
`;
const LogInOutItem = styled(BaseNavBarItem)`
display: flex;
background-color:lightblue;
`;
const UniversalHeader = ({ isAdmin, cartMap, isAuth }) => {
    const location = useLocation();
    const navigate = useNavigate();
    return (
        <MainUniversalHeader>
            <UserNameField>
                <ModalWindowForLogin_ReduxWrapped />                
            </UserNameField>
            <Navbar>

                {isAdmin ? <NavBarItem onClick={() => navigate("/Create")} navPath="/Create" currentPath={location.pathname}>Create Event</NavBarItem> : ""}

                <NavBarItem onClick={() => navigate("/")} navPath="/" currentPath={location.pathname} >Events</NavBarItem>
                {cartMap.size != 0 ? <NavBarItem onClick={() => navigate("/cart")} navPath="/cart" currentPath={location.pathname}>Cart </NavBarItem> : ""}
                {isAdmin ? <NavBarItem onClick={() => navigate("/test")} navPath="/test" currentPath={location.pathname} >TestPage</NavBarItem> : ""}
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
    isAdmin: state.auth.isAdmin,
    cartMap: state.cart.cartMap,
    isAuth: state.auth.isAuthenticated

});
const mapDispatchToProps = dispatch => (
    {
    });
var UniversalHeader_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(UniversalHeader);
export default UniversalHeader_ReduxWrapped;