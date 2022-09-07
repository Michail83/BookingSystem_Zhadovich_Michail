import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";

import urls from "../../API_URL"
import styled from "styled-components";

const LabelBlock = styled.div`
    
    margin-bottom: 0.3rem;
    align-self:center;
`;

const MainBlock = styled.div`
    max-width:400px;
    margin:17vh auto 0 auto;
    box-sizing:border-box;
    display:flex;
    flex-direction:column;
    flex-basis: 50%;
    align-items:stretch;
    padding: 0.2rem;
    border: 1px solid lightskyblue;
    border-radius: 3px;
    padding:1vh;

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


const Registration = () => {

    const [userName, setUserName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");    
    const [resultMessage, SetResultMessage] = useState([]);

    let navigate = useNavigate();

    const clearForm = () => {
        setUserName("");
        setEmail("");
        setPassword("");
    }


    const submitHandler = async (event) => {
        event.preventDefault();
        try {

            let result = await axios.post(urls.register(), {
                userName: userName,
                email: email,
                password: password
            });
            SetResultMessage(<li> Confirmation link was sended to your email. Please, go and click it </li>);
            clearForm();
            // navigate("/");

        } catch (error) {

            switch (error.response.status) {
                case 400:
                    setPassword("");

                    let data = error.response.data;

                    let errorsList = data.map((item, index) => {
                        return (<li key={index}>{item.description} </li>)
                    });

                    SetResultMessage(errorsList);
                    break;

                case 503:
                    SetResultMessage(<li>Mail cannot send, , try later...</li>)
                    break;
            }
        }
    }

    return (
        <MainBlock>
            <form onSubmit={submitHandler}>
                <LabelBlock>
                    {/* <LabelBlock> */}
                        <Label>Name</Label>
                        <Input type="text" required value={userName} onChange={(event) => setUserName(event.target.value)} />
                    </LabelBlock>
                {/* </LabelBlock> */}

                <LabelBlock>
                    {/* <LabelBlock> */}
                        <Label>Email</Label>
                        <Input type="email" required value={email} onChange={(event) => setEmail(event.target.value)} />
                    {/* </LabelBlock> */}
                </LabelBlock>

                <LabelBlock>
                    {/* <LabelBlock> */}
                        <Label>Password</Label>
                        <Input type="password" id="password" value={password} required minLength={4} onChange={(event) => setPassword(event.target.value)} />
                    {/* </LabelBlock> */}
                </LabelBlock>
                <button type="submit"> Register</button>
            </form>
            <ul>
                {resultMessage}
            </ul>
        </MainBlock>
    )
}
export default Registration;