import styled from "styled-components";
import { BaseButton } from "./BaseButton.js";

export const BlueButton = styled(BaseButton)`
    
    background-color:lightskyblue; 
    &:not(:disabled):hover{
        background-color: lightblue;        
    }
`;