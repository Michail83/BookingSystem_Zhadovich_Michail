import styled from "styled-components";
import { BaseButton } from "./BaseButton";

export const BaseLockButton = styled(BaseButton)`
    text-align: center;   
    width:4.5rem;
    display:block;
    margin: 0 auto;

    &:hover{
        outline: 1px solid black;
    }
`;