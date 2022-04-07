import React from "react";
import { Link, useNavigate } from "react-router-dom";
import "./UniversalHeader.css";
import LogInOutManager_connected from "../LoginOutManager/LoginOutManager.js"
import LinkToCart from '../Cart/cartButton/LinkToCartFromHeader'
import ModalWindowForLogin_ReduxWrapped from "../ModalWindowForLogin/ModalWindowForLogin"




class UniversalHeader extends React.Component {
    constructor(props){
        super(props)
    }

    render() {
        return (<div>
            {/* <div  style={{ height: "100px", backgroundColor: "greenyellow", textAlign: "center" }}>  */}
            <div className="main-header">
                <ModalWindowForLogin_ReduxWrapped/>
                {/* <div style={{padding:"20px", display: "inline-block"}}> <p>Типа шапка</p> </div> */}

                <div className="nav-block"><Link to="/Create">Create Event</Link></div>
                <div className="nav-block"><Link to="/">Home</Link></div>
                <LinkToCart/>
                 
                <div className="nav-block"><Link to="/test">TestPage</Link></div>

                <LogInOutManager_connected />

                {/* <div className="nav-block"><Link to="/login">Login</Link></div> 
                <div className="nav-block"><LogoutBtn/></div>               */}

            </div >          
        </div>);        
    }
}
export default UniversalHeader;