import React, { useState, useEffect } from "react" 
import  axios from "axios"; 
import urls from '../../API_URL'
import CreateLinkToExternalProvider from "./CreateLinkToExternalProvider" 

function ExternalLoginList(prop) {

    const [externalProviderList, SetExternalProviderList ] = useState(null);
    useEffect(()=>{        
        loadProvider();        
        },[]
    ); 

    const  loadProvider = async ()=>{
        try {
            var url = urls.getExternalProviderName()
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
        <div>{showLoading()}</div>
    );
}
export default ExternalLoginList;