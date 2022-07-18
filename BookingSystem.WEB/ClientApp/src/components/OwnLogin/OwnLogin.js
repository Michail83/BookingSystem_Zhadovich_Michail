import React, { useState, useEffect } from "react";
// import { useNavigate } from "react-router-dom";
import axios from "axios";
import { connect } from "react-redux";
import urls from "../../API_URL"
import actionCreator from "../../Store/ActionsCreators/actionCreator";
import {tryLoadAuthData} from "../../function/tryLoadAuthData"

import ExternalLoginList from "../ExternalLogin/ExternalLoginList"; 

const OwnLogin =  ({setNoActive}) => {

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [rememberMe, setRememberMe] = useState(false);
    const [result, setResult] = useState("");

    // let navigate = useNavigate();

    const LoginHadler = async (event)=>{
        event.preventDefault();
        // console.log( email,password );

        try {
            let result =await axios.post(urls.login(),{
                email: email,
                password: password,
                rememberMe: true
            });            
            setResult(result.data);            
            if (result.status ==200) {
                setNoActive();
                tryLoadAuthData();                
            }
        } catch (error) { 
            console.log( error);
            setResult( error.response.data);            
        }
    }
    return (
        <div className="OwnLogin" >
            <form onSubmit={LoginHadler} > 
                <label> Email <input type="email" value={email} onChange={(event)=>{setEmail(event.target.value)}}/></label>
                <label> Password <input type="password" value={password} onChange={(event)=>{setPassword(event.target.value) }}/></label>
                <label> Remember <input type="checkbox" value={rememberMe} onChange={(event)=>{setRememberMe(event.target.value)}}/></label>
                <button type="submit"  > Login</button>
            </form>
            <p>{result}</p>

        </div>
    )
}

const mapStateToProps = state => ({
    // IsAuthenticated: state.auth.isAuthenticated,    
    // isLoginWindowActive: state.state.iSmodalLoginWindowActive
});
const mapDispatchToProps = dispatch => (
    {
       setNoActive:()=> dispatch(actionCreator.setModalWindowForLoginActive(false))        
    });

var OwnLogin_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(OwnLogin);


export default OwnLogin_ReduxWrapped;