import React from "react";
import { useNavigate } from "react-router-dom";
import { BlueButton } from "../StyledComponent/Button/BlueButton";

export const DetailsButton =({id})=>{
    const navigate = useNavigate();

    return(        
        <BlueButton onClick={() => navigate(`/details/${id}`)}>Details</BlueButton>        
    )
}