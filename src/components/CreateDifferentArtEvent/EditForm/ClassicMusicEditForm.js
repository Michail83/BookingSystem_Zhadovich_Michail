import React, { useEffect, useState } from "react";
import api_url from "../../../API_URL";
import axios from "axios";


import onSubmitClassicMusicEditFunction from "../OnSubmitFunction/onSubmitClassicMusicEditFunction"



import ClassicMusicBaseForm from "../BaseForms/ClassicMusicBaseForm";

const ClassicMusicEditForm = ({setStatusOfCreating, id})=>{ 
    const [values, setValues] = useState(); 
    useEffect(()=>{
        loadClassicMusic();
    },[]);
    
    const loadClassicMusic =async ()=>{

        try {
            let result = await axios.get(api_url.classicmusics(id))
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
        voice:true,
        concertName: true,
        image:true    
    };
    options.onSubmitFunction = onSubmitClassicMusicEditFunction(setStatusOfCreating, values.id );
    options.submitName = "Update";
    options.image = {isRequired:false};
    
    return <ClassicMusicBaseForm options={options} />  
        } else return <div>loading...</div>
    }    
    return <>
        {createElement()}
    </>    
}

export default ClassicMusicEditForm;