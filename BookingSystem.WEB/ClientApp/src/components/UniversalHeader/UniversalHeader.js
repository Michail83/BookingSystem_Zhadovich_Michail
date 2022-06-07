import React from "react";
import { Link, useNavigate, useLocation } from "react-router-dom";
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
    & :first-child{
        padding:1%;
        margin:0;
    }
    background-color:lightblue;
    background-color: ${({navPath, currentPath})=>navPath==currentPath?"royalblue!important":"inherit"};
    &:hover{
        background-color:royalblue
    }
`;

const UniversalHeader = ({ isAdmin }) => {
    const location = useLocation();
    /* console.log(location);
    console.log(location.pathname=="/"); */

    return (
        <MainUniversalHeader>
            <UserNameField>
                <ModalWindowForLogin_ReduxWrapped />
                <DisplayUserName_ReduxWrapped />
            </UserNameField>
            <Navbar>

                {isAdmin ? <NavBarItem navPath="/Create" currentPath={location.pathname}><Link to="/Create">Create Event</Link></NavBarItem> : ""}
                
                <NavBarItem navPath="/" currentPath={location.pathname} ><Link to="/">Home</Link></NavBarItem>
                <NavBarItem navPath="/cart" currentPath={location.pathname}><LinkToCart /></NavBarItem>
                {isAdmin ? <NavBarItem navPath="/test" currentPath={location.pathname} ><Link to="/test">TestPage</Link></NavBarItem> : ""}
                <NavBarItem navPath="/orders" currentPath={location.pathname}><Link to="/orders">Orders</Link></NavBarItem>
                <div><LogInOutManager_connected /></div>
            </Navbar >
        </MainUniversalHeader>
    )
}

export default UniversalHeader;