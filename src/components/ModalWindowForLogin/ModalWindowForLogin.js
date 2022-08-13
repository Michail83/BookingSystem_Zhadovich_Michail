import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import actionCreator from "../../Store/ActionsCreators/actionCreator";
import "./ModalWindowForLogin.css";
import ExternalLoginList from "../ExternalLogin/ExternalLoginList";
import { Link, useNavigate } from "react-router-dom";
import OwnLogin from "../OwnLogin/OwnLogin";

import {CSSTransition, TransitionGroup} from 'react-transition-group';

import styled from "styled-components";

const TestNoActive= styled.div`
   height: 100vh;
    width: 100vw;
    /* background-color: white; */
    /* opacity: 0.9; */
    background-color: rgba(0,0,0,0.4);
    position: fixed;
    top: 0;
    left: 0;
    display:flex;
    justify-content: center;
    align-items:center;
    /* transform: scale(0); */
    
`;
const TestActive= styled(TestNoActive)`
    /* transform: scale(1); */
    /* transition: all 1s; */
`;

const ModalContent = styled.div`
    display:flex;
    flex-direction:column;
    padding: 0.2rem;
    border-radius: 6px;
    background-color:rgba(237, 237, 237,1);
    
    width: 35%;
    
    border: 1px solid rgba(237, 237, 237,1);
    box-sizing: border-box;
    box-shadow: 0px 0px 20px 8px rgba(34, 60, 80, 0.2);
`;


const ModalWindowForLogin =  ({ isActive, setNoActive }) => {
    // let ModalWindow =isActive?TestActive:TestNoActive;
    let nodeRef = React.useRef(null);
    let ModalWindow =TestNoActive;
    
    return (
        <div>
            <CSSTransition
        in={isActive}
        timeout={300}
        nodeRef={nodeRef}        //finddomnode is deprecated in strictmode
        classNames="modal"
        unmountOnExit        
        >
            <ModalWindow onClick={setNoActive} >
                <ModalContent onClick={(e) => e.stopPropagation()} >
                    <ExternalLoginList />
                    <OwnLogin />
                    <div>
                        <Link to={"/Registration"}>Registration</Link>
                    </div>

                </ModalContent>
            </ModalWindow>
        </CSSTransition>

        </div>
        
    )
}

const mapStateToProps = state => ({
    IsAuthenticated: state.auth.isAuthenticated,    
    isActive: state.state.iSmodalLoginWindowActive
});
const mapDispatchToProps = dispatch => (
    {
        setNoActive:()=> dispatch(actionCreator.setModalWindowForLoginActive(false))        
    });

var ModalWindowForLogin_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(ModalWindowForLogin);
export default ModalWindowForLogin_ReduxWrapped;