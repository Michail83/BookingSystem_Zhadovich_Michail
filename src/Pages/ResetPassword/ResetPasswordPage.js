import React,{useState} from "react";
import styled from "styled-components";
import axios from "axios";
import api_url from "../../API_URL";

import { BaseButton } from "../../components/StyledComponent/Button/BaseButton";

import { MainBlock } from "../../components/StyledComponent/MainBlock";

const ThisMainBlock= styled(MainBlock)`
    display:flex;
    flex-flow: column nowrap;
    justify-content: center;
    align-items:center;
    width:350px;
`;
const ThisButton = styled(BaseButton)`
    display:block;
    width:100%;
`;
 const Input= styled.input`
    outline:1px solid whitesmoke;
    border-radius:2px;
    width:200px;
 `;
 const ThisForm = styled.form`
    margin: 0 auto;
    padding:0.5rem;
    width:80%;
    `;

const ResetPasswordPage =()=>{
    const [email, setEmail] = useState();
    const [result, setResult] = useState();

    const onClickHandler = async (event)=>{
        event.preventDefault();
        let result = await axios.get(api_url.resetPasswordByUser(email));
        if (result.status ===200) {
            setResult("Email with reset password link was sended.")
        }
    }
    return (
        <ThisMainBlock>
        <p>Please, enter your email and we will send email with link to recovering password</p>
        <ThisForm onSubmit={(event)=>{onClickHandler(event),setEmail("") }}>
        <Input type="email" required onChange={(event)=>setEmail(event.target.value)} />
        <button type="submit">Send</button>
        </ThisForm>
        
        {result??<p>{result}</p>}

    </ThisMainBlock>
    )
}
export default ResetPasswordPage;