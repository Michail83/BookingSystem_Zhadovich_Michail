import React, { useState } from "react";

import axios from "axios";
import { connect } from "react-redux";
import urls from "../../API_URL";
import actionCreator from "../../Store/ActionsCreators/actionCreator";
import { tryLoadAuthData } from "../../function/tryLoadAuthData";
import CoutdownToRefreshConfirmation from "../CoutdownToRefreshConfirmation/CoutdownToRefreshConfirmation";

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

const WrongDataP = styled.p`
color:red;
`;

const OwnLogin = ({ setNoActiveModalWindow }) => {

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [rememberMe, setRememberMe] = useState(true);
    const [result, setResult] = useState("");
    const [isConfirmEnabled, SetIsConfirmEnabled] =useState(false);


    const LoginHadler = async (event) => {
        event.preventDefault();
        try {
            SetIsConfirmEnabled(false);
            let result = await axios.post(urls.login(), {
                email: email,
                password: password,
                rememberMe: rememberMe
            });
            setResult(result.data);
            
            if (result.status == 200) {
                setNoActiveModalWindow();
                tryLoadAuthData();
            }
        } catch (error) {
            setPassword("");            
            if (error.response.data.code ==="notconfirmed") {
                SetIsConfirmEnabled(true);                
            }else setResult(error.response.data.description);
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
            <div>
                {result && <WrongDataP >{result}</WrongDataP>}                
                {isConfirmEnabled && <p><CoutdownToRefreshConfirmation email={email} password={password}/></p>}

            </div>
        </div>
    )
}

const mapStateToProps = state => ({
    
});
const mapDispatchToProps = dispatch => (
    {
        setNoActiveModalWindow: () => dispatch(actionCreator.setModalWindowForLoginActive(false))
    });

var OwnLogin_ReduxWrapped = connect(null, mapDispatchToProps)(OwnLogin);

export default OwnLogin_ReduxWrapped;