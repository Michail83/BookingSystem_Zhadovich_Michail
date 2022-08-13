import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { connect } from "react-redux";
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

    const [userName, setUserName] = useState("qwe");
    const [email, setEmail] = useState("Sklif83@tut.by");
    const [password, setPassword] = useState("qwe123");
    const [error, SetError] = useState([]);
    // const [confirmPassword, setConfirmPassword] = useState();
    let navigate = useNavigate();


    const submitHandler = async (event) => {
        event.preventDefault();
        try {
            
            let result = await axios.post(urls.register(), {
                userName: userName,
                email: email,
                password: password
            });
            navigate("/");
           
        } catch (error) {

            switch (error.response.status) {
                case 400:
                    console.log(error.response.data);
                    let data = error.response.data;
                    console.log(error.response.data);
                    let errorsList = data.map((item) => {
                        return (<li>{item.description} </li>)
                    });
                    console.log(errorsList);
                    SetError(errorsList);
                    break;
                case 503:
                    SetError("Mail cannot send, , try later...")
                    break;

            }
        }
    }

    return (
        <MainBlock>
            <form onSubmit={submitHandler}>
                <LabelBlock>
                    <LabelBlock>
                        <Label>Name</Label>
                        <Input type="text" required onChange={(event) => setUserName(event.target.value)} />
                    </LabelBlock>
                </LabelBlock>

                <LabelBlock>
                    <LabelBlock>
                        <Label>Email</Label>
                        <Input type="email" required onChange={(event) => setEmail(event.target.value)} />
                    </LabelBlock>
                </LabelBlock>

                <LabelBlock>
                    <LabelBlock> 
                        <Label>Password</Label>
                        <Input type="password" id="password" required minLength={4} onChange={(event) => setPassword(event.target.value)} />
                    </LabelBlock>
                </LabelBlock>
                <button type="submit"> Register</button>
            </form>
            <ul>
                {error}
            </ul>
        </MainBlock>
    )
}
export default Registration;