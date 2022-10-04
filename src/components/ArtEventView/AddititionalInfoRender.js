import React from "react";
import { StyledSpan } from "./StyledSpan";


export const AddititionalInfoRender = ({typeOfArtEvent, additionalInfo})=>{
    let result;
    switch (typeOfArtEvent) {
        case "ClassicMusic":
            result = <>
            <StyledSpan>Name of concert</StyledSpan>
            <p>{additionalInfo[0]}</p>
            <StyledSpan>Voice</StyledSpan>
            <p>{additionalInfo[1]}</p>
            </>
            
            break;
        case "OpenAir":
            result = <>
            <StyledSpan>Headliner</StyledSpan>
            <p>{additionalInfo[0]}</p>           
            </>
            
            break;
        case "Party":
            result = <>
            <StyledSpan>Age limit</StyledSpan>
            <p>{additionalInfo[0]}</p>           
            </>
            
            break;
    
        default:
            break;
            
    }
    return <>
    {result}</>;

}