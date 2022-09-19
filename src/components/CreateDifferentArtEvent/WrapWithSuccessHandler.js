import React, { Fragment, useState, useEffect } from "react";
import styled from "styled-components";
import { BlueButton } from "../StyledComponent/Button/BlueButton"


const BigSuccessful = styled.div`
    width: 80%;
    border: 1px solid white;
    border-radius: 3px;
    margin: 2rem auto 0 auto;
    background-color: white;
    padding: 0.2rem;
`;
const BigError = styled(BigSuccessful)`

background-color: blue;
color:red;
font-size:large;
`;

const WrapWithSuccessHandler = ({ CreateForm }) => {
    const [statusOfCreating, setStatusOfCreating] = useState(null);
    
        let result = <BigSuccessful>Event was created successfully. Do you want to create <BlueButton onClick={() => setStatusOfCreating(null)}>More </BlueButton> </BigSuccessful>

        if (statusOfCreating==null) result = <CreateForm setStatusOfCreating={setStatusOfCreating} />
        else if (statusOfCreating==false) result= <BigError>Event was not created. Something wrong in data that you entered<BlueButton onClick={() => setStatusOfCreating(null)}>Again </BlueButton> </BigError>
        
    return (
        <Fragment>
            {result}
        </Fragment>
    )
}
export default WrapWithSuccessHandler;