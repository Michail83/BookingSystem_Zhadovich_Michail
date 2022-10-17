import styled from "styled-components";
import { BaseButton } from "./BaseButton.js";

export const RedButton = styled(BaseButton)`
    
    background-color:pink; 
    /* opacity: 0.7; */
    transition: 1s;
    text-align: center;
    color: white;

    &:not(:disabled):hover{
        background-color: red;  
        opacity: 1;  
    }
`;