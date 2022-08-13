import React, { useState, useEffect } from "react" 
import  axios from "axios"; 
import urls from '../../API_URL'
import CreateLinkToExternalProvider from "./CreateLinkToExternalProvider";
import styled from "styled-components";

const DivWrap = styled.div`

    display:flex;
    flex-direction:column;
    width:100%;
    margin-bottom: 1rem;
    /* margin-top: 1rem; */

    /* & :first-child{
        margin-left:auto;
    }
    &:last-child{
        margin-right:auto;
    } */
`;

function ExternalLoginList(prop) {

    const [externalProviderList, SetExternalProviderList ] = useState(null);
    useEffect(()=>{        
        loadProvider();        
        },[]
    ); 

    const  loadProvider = async ()=>{
        try {
            let url = urls.getExternalProviderName()
            // console.log(url);
            const result =   await axios.get(url);
            // console.log(result.data);
            SetExternalProviderList(result.data);

        } catch (error) {
            console.log(error);
        }        
    }

    const showLoading = ()=>{
        let items;
        const returnUrl = prop.returnUrl ?? "http://localhost:5001/"           
        if (externalProviderList) {
            items = externalProviderList.map((provider)=>(<CreateLinkToExternalProvider key={provider} providerName ={provider} returnUrl = {returnUrl}/>));
        } else {            
            items = <div> Loading...</div>
        }
        return items;
    }


    return(
        <DivWrap>{showLoading()}</DivWrap>
    );
}
export default ExternalLoginList;