import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import actionCreator from "../../Store/ActionsCreators/actionCreator";
import "./ModalWindowForLogin.css"
import ExternalLoginList from "../ExternalLogin/ExternalLoginList"


const ModalWindowForLogin =  ({ isActive, setNoActive }) => {
    return (
        <div className={isActive ? "modal active" : "modal" } onClick={setNoActive} >
            <div className="modalcontent" onClick={(e) => e.stopPropagation()} >
                <ExternalLoginList/>
            </div>
        </div>
    )
}

const mapStateToProps = state => ({
    IsAuthenticated: state.isAuthenticated,
    state: state,
    isActive: state.iSmodalLoginWindowActive
});

const mapDispatchToProps = dispatch => (
    {
        setNoActive:()=> dispatch(actionCreator.setModalWindowForLoginActive(false))        
    });


var ModalWindowForLogin_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(ModalWindowForLogin);
export default ModalWindowForLogin_ReduxWrapped;