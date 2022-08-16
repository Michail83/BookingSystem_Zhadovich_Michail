import React from "react";
import styled from "styled-components";
import API_URL from "../../API_URL";

const ExternalLink =  styled.a`
    display: inline-block;
    font-size: 1em;    
    
    /* margin: 1rem; */
    padding:1vh;
    border: 1px solid black;
    border-radius: 4px;
    text-align: center;
    margin: 0.8rem 0.2rem 0 0.2rem;
    text-decoration:none;
    &:hover{
        background-color:rgba(220, 220, 220,1)
    }
    &:visited{
        color:initial;
    }
    

`;


function CreateLinkToExternalProvider(props){
    if (!props.providerName) {
        return (
            <p>External provider not found</p>
        )        
    }

    let returnUrl = props.returnUrl;
    if (!props.returnUrl) {
        returnUrl =API_URL.base_api;
    }    
    const path = API_URL.getExternalLoginUrl(props.providerName,returnUrl);

return (
    <ExternalLink href={path}>{props.providerName}</ExternalLink>
)
}
export default CreateLinkToExternalProvider;