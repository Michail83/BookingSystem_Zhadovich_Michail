import styled from "styled-components";

export const BigSuccessful = styled.div`
    width: 80%;
    border: 1px solid white;
    border-radius: 3px;
    margin: 2rem auto 0 auto;
    background-color: white;
    padding: 0.2rem;
`;

export const BigError = styled(BigSuccessful)`
background-color: blue;
color:red;
font-size:large;
`;