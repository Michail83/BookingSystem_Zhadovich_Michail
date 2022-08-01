import React from "react";
import { Link, useNavigate, useLocation } from "react-router-dom";
import { connect } from 'react-redux';

import "./UniversalHeader.css";
import LogInOutManager_connected from "../LoginOutManager/LoginOutManager.js"
import LinkToCart from '../Cart/cartButton/LinkToCartFromHeader'
import ModalWindowForLogin_ReduxWrapped from "../ModalWindowForLogin/ModalWindowForLogin";
import DisplayUserName_ReduxWrapped from "../DisplayUserName/DisplayUserName";
import styled from "styled-components";



const MainUniversalHeader = styled.div`
    position: fixed;
    box-sizing: border-box;
    top: 0;
    z-index: 1000;
    width: 100%;
    height: 13vh;
    background-color: white;
    padding: 1rem 1rem;
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

    & div {    
    margin: 5px;
    padding: 2px;
    border: 0px solid black;
    border-radius: 3px;
    font-size: 1.5rem;
    background-color:white;    
}   
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


const NavBarItem = styled.div`
    width: 13%;
    cursor: pointer;
    & :first-child{
        padding:1%;
        margin:0;
    }
    /* background-color:white; */
    background-color: ${({ navPath, currentPath }) => navPath == currentPath ? "royalblue" : "inherit"};
    &:hover{
        background-color:royalblue
    }
`;
const LogInOutItem =styled.div`
background-color:lightblue;
`;

const UniversalHeader = ({ isAdmin, cartMap }) => {
    const location = useLocation();
    const navigate = useNavigate();

    /* console.log(location);
    console.log(location.pathname=="/"); */

    return (
        <MainUniversalHeader>
            <UserNameField>
                <ModalWindowForLogin_ReduxWrapped />
                <DisplayUserName_ReduxWrapped />
            </UserNameField>
            <Navbar>

                {isAdmin ? <NavBarItem onClick={()=>navigate("/Create")} navPath="/Create" currentPath={location.pathname}>Create Event</NavBarItem> : ""}

                <NavBarItem onClick={()=>navigate("/")} navPath="/" currentPath={location.pathname} >Home</NavBarItem>
                {cartMap.size !=0 ? <NavBarItem onClick={()=>navigate("/cart")} navPath="/cart" currentPath={location.pathname}>Cart </NavBarItem>:""}
                {isAdmin ? <NavBarItem onClick={()=>navigate("/test")} navPath="/test" currentPath={location.pathname} >TestPage</NavBarItem> : ""}
                <NavBarItem onClick={()=>navigate("/orders")} navPath="/orders" currentPath={location.pathname}>Orders</NavBarItem>
                <LogInOutItem><LogInOutManager_connected /></LogInOutItem>
            </Navbar >
        </MainUniversalHeader>
    )
}

const mapStateToProps = state => ({
    isAdmin: state.auth.isAdmin,
    cartMap: state.cart.cartMap
    // isActive: state.state.iSmodalLoginWindowActive
});
const mapDispatchToProps = dispatch => (
    {
        addDeleteArtEventButtonToState:()=>dispatch(actionsCreator.setDeleteArtEventButton(DeleteArtEventButton))
        // setNoActive:()=> dispatch(actionCreator.setModalWindowForLoginActive(false))        
    });
var UniversalHeader_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(UniversalHeader);
export default UniversalHeader_ReduxWrapped;