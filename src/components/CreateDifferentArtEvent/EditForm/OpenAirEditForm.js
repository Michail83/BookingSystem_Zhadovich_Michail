import React, { Fragment, useEffect, useState } from "react";
import api_url from "../../../API_URL";
import axios from "axios";


import onSubmitOpenAirEditFunction from "../OnSubmitFunction/onSubmitOpenAirEditFunction";
import OpenAirBaseForm from "../BaseForms/OpenAirBaseForm";

const OpenAirEditForm = ({setStatusOfCreating, id})=>{ 
    const [values, setValues] = useState(); 
    useEffect(()=>{
        loadOpenAir();
    },[]);
    
    const loadOpenAir =async ()=>{

        try {
            let result = await axios.get(api_url.openairs(id))
            setValues(result.data);

        } catch (error) {
            
        }
    }
    const createElement=()=>{
        if (values) {
            
            const options = {};
    options.defaultValues = { ...values};
    
    options.disabledValues = {
        eventName:true,
        date:true,
        amountOfTickets:false,
        place:true,
        price:false,
        headliner:true,
        image:true    
    };
    options.image = {isRequired:false};
    options.onSubmitFunction = onSubmitOpenAirEditFunction(setStatusOfCreating, values.id );
    options.submitName = "Update";
        
    return <OpenAirBaseForm options={options}/>  
        } else return <div>loading...</div>
    }    
    return <>
        {createElement()}
    </>    
}

export default OpenAirEditForm;