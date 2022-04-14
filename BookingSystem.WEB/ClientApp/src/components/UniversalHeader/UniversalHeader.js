import React from "react";
import { Link, useNavigate } from "react-router-dom";
import "./UniversalHeader.css";
import LogInOutManager_connected from "../LoginOutManager/LoginOutManager.js"
import LinkToCart from '../Cart/cartButton/LinkToCartFromHeader'
import ModalWindowForLogin_ReduxWrapped from "../ModalWindowForLogin/ModalWindowForLogin";
import DisplayUserName_ReduxWrapped from "../DisplayUserName/DisplayUserName";

const UniversalHeader = () => {

    return (
        <div className="main-universal-header">
            <div className="userNameField">
            <ModalWindowForLogin_ReduxWrapped />
            <DisplayUserName_ReduxWrapped/>
            </div>           

            <div className="nav-bar">
                <div className="nav-block" style={{ marginLeft:"auto" }}><Link to="/Create">Create Event</Link></div>
                <div className="nav-block"><Link to="/">Home</Link></div>
                <div className="nav-block"><LinkToCart /></div>
                <div className="nav-block"><Link to="/test">TestPage</Link></div>
                <div className="nav-block" style={{ marginLeft: "auto" }}><LogInOutManager_connected /></div>
            </div >
        </div>
        )
}

export default UniversalHeader;

//class UniversalHeader extends React.Component {
//    constructor(props) {
//        super(props)
//    }

//    render() {
//        return (<div>
            
//            <div className="main-header">

//                <ModalWindowForLogin_ReduxWrapped />
//                <div className="nav-block"><Link to="/Create">Create Event</Link></div>
//                <div className="nav-block"><Link to="/">Home</Link></div>
//                <LinkToCart />
//                <div className="nav-block"><Link to="/test">TestPage</Link></div>
//                <LogInOutManager_connected />
//            </div >
//        </div>);
//    }
//}
















































////import React from "react";
////import { Link, useNavigate } from "react-router-dom";
////import "./UniversalHeader.css";
////import LogInOutManager_connected from "../LoginOutManager/LoginOutManager.js"
////import LinkToCart from '../Cart/cartButton/LinkToCartFromHeader'


////class UniversalHeader extends React.Component {
////    constructor(props){
////        super(props)
////    }

////    render() {
////        return (<div>
////            {/* <div  style={{ height: "100px", backgroundColor: "greenyellow", textAlign: "center" }}>  */}
////            <div className="main-header">

////                {/* <div style={{padding:"20px", display: "inline-block"}}> <p>Типа шапка</p> </div> */}

////                <div className="nav-block"><Link to="/Create">Create Event</Link></div>
////                <div className="nav-block"><Link to="/">Home</Link></div>
////                <LinkToCart/>
////                {/* <LogInOutManager_connected/> */}
////                <div className="nav-block"><Link to="/test">TestPage</Link></div>

////                {/* <div className="nav-block"><Link to="/login">Login</Link></div> 
////                <div className="nav-block"><LogoutBtn/></div>               */}

////            </div >
////          {this.props.children}
////        </div>);        
////    }
////}
////export default UniversalHeader;