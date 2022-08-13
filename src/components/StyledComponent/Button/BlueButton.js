import styled from "styled-components";
export const BlueButton = styled.button`
    border: 0;
    background-color:lightskyblue;
    border-radius: 3% 3%;
   
    margin: 0.5rem 3%;
    height: 10%; 
    &:not(:disabled):hover{
        background-color: lightblue;
        /* border: 1px solid white */
    }
`;