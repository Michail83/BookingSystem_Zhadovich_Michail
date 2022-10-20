import React, { Fragment, useEffect, useState } from "react";
// import { useForm } from "react-hook-form";
import api_url from "../../../API_URL";
import axios from "axios";
// import { Input, Form, Label, ErrorMessage, SubmitButton } from "./StyledComponentsForCreateEvents"
// import { MapAbsoluteContainer } from "../StyledComponent/Map/MapAbsoluteContainer";
// import { defaultValuesCreateArtEvent } from "../../../CONST/DefaultValuesCreateArtEvent";
// import YandMAP_CreateEvent from "../YandMAP/YandMAP_CreateEvent";
// import styled from "styled-components";
// import { unAuthorizedHandler } from "../../function/unAuthorizedHandler";



import onSubmitOpenAirEditFunction from "../OnSubmitFunction/onSubmitOpenAirEditFunction";
import OpenAirBaseForm from "../BaseForms/OpenAirBaseForm";





const OpenAirEditForm = ({setStatusOfCreating, id})=>{

    console.log(setStatusOfCreating);


    const [values, setValues] = useState(); 
    useEffect(()=>{
        loadOpenAir();
    },[]);
    // console.log("OpenAirEditForm");
    const loadOpenAir =async ()=>{

        try {
            let result = await axios.get(api_url.openairs(id))
            setValues(result.data);

        } catch (error) {
            
        }
    }
    const createElement=()=>{
        if (values) {
            // console.log(values);
            const options = {};
    options.defaultValues = { ...values};

    console.log(options.defaultValues);
    
    options.disabledValues = {
        eventName:true,
        date:true,
        amountOfTickets:false,
        place:true,
        price:false,
        headliner:true,
        image:true    
    };
    options.onSubmitFunction = onSubmitOpenAirEditFunction(setStatusOfCreating, values.id );
    options.submitName = "Update";
    
    return <OpenAirBaseForm options={options} />  
        } else return <div>loading...</div>
    }
    
    return <>
        {createElement()}
    </>

    
}

export default OpenAirEditForm;