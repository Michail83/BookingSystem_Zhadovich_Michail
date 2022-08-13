import React, { useState, useEffect } from "react";
// import { useNavigate } from "react-router-dom";
import axios from "axios";
import { connect } from "react-redux";
import urls from "../../API_URL"
import actionCreator from "../../Store/ActionsCreators/actionCreator";
import { tryLoadAuthData } from "../../function/tryLoadAuthData"

import ExternalLoginList from "../ExternalLogin/ExternalLoginList";
import styled from "styled-components";

const LabelBlock = styled.div`
    
    margin-bottom: 0.3rem;
    align-self:center;
`;

const FlexForm = styled.div`
    display:flex;
    flex-direction:column;
    padding: 0.2rem;

`;

const Input = styled.input`    
    display: block;
    width: 100%;
    box-sizing: border-box;
    &:hover{
        /* box-shadow: 0px 0px 4px 2px rgba(34, 60, 80, 0.43); */
    }
    

`;
const Label = styled.label`
    display:block;
    width:100%;
`;

const SubmitButton = styled.button`
    display:block;
    width:100%;
    margin: 1.5em auto;
    font-size: 1em;
`;

const OwnLogin = ({ setNoActive }) => {

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [rememberMe, setRememberMe] = useState(true);
    const [result, setResult] = useState("");

    // let navigate = useNavigate();

    const LoginHadler = async (event) => {
        event.preventDefault();
        // console.log( email,password );

        try {
            let result = await axios.post(urls.login(), {
                email: email,
                password: password,
                rememberMe: true
            });
            setResult(result.data);
            if (result.status == 200) {
                setNoActive();
                tryLoadAuthData();
            }
        } catch (error) {
            console.log(error);
            setResult(error.response.data);
        }
    }

    return (
        <div className="OwnLogin" >
            <form onSubmit={LoginHadler} >
                <LabelBlock>
                    <Label> Email </Label>
                    <Input required type="email" value={email} onChange={(event) => { setEmail(event.target.value) }} />
                </LabelBlock>
                <LabelBlock>
                    <Label>Password</Label>
                    <Input required type="password" value={password} onChange={(event) => { setPassword(event.target.value) }} />
                </LabelBlock>


                <SubmitButton type="submit"  > Login</SubmitButton>

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
        setNoActive: () => dispatch(actionCreator.setModalWindowForLoginActive(false))
    });

var OwnLogin_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(OwnLogin);


export default OwnLogin_ReduxWrapped;


{/* <LabelBlock>
                <LabelBlock> Remember <input required type="checkbox" value={rememberMe} onChange={(event) => { setRememberMe(event.target.value) }} /></LabelBlock>
                </LabelBlock> */}