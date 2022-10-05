import React from "react";
import { connect } from "react-redux";
import actionCreator from "../../Store/ActionsCreators/actionCreator";
import "./ModalWindowForLogin.css";
import ExternalLoginList from "../ExternalLogin/ExternalLoginList";
import { Link } from "react-router-dom";
import OwnLogin from "../OwnLogin/OwnLogin";

import { CSSTransition } from 'react-transition-group';

import styled from "styled-components";

const TestNoActive = styled.div`
   height: 100vh;
    width: 100vw;   
    background-color: rgba(0,0,0,0.4);
    position: fixed;
    top: 0;
    left: 0;
    display:flex;
    justify-content: center;
    align-items:center;    
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

const ModalWindowForLogin = ({ isActive, setNoActive }) => {
    let nodeRef = React.useRef(null);
    let ModalWindow = TestNoActive;

    return (
        
            <CSSTransition
                in={isActive}
                timeout={300}
                nodeRef={nodeRef}        //findDomNode is deprecated in strictmode
                classNames="modal"
                unmountOnExit
            >
                <ModalWindow onMouseDown={setNoActive} >
                    <ModalContent onMouseDown={(e) => e.stopPropagation()} >
                        {/* <ExternalLoginList /> */}
                        <OwnLogin />
                        <div>
                            <Link to={"/Registration"} onClick={setNoActive}>Registration</Link>
                        </div>

                    </ModalContent>
                </ModalWindow>
            </CSSTransition>
       
    )
}

const mapStateToProps = state => ({
    IsAuthenticated: state.auth.isAuthenticated,
    isActive: state.state.iSmodalLoginWindowActive
});
const mapDispatchToProps = dispatch => (
    {
        setNoActive: () => dispatch(actionCreator.setModalWindowForLoginActive(false))
    });

var ModalWindowForLogin_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(ModalWindowForLogin);
export default ModalWindowForLogin_ReduxWrapped;