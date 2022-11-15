import React from "react";

import { defaultValuesCreateArtEvent } from "../../../CONST/DefaultValuesCreateArtEvent";
import onSubmitOpenAirCreateFunction from "../OnSubmitFunction/onSubmitOpenAirCreateFunction";
import OpenAirBaseForm from "../BaseForms/OpenAirBaseForm";

const OpenAirCreateForm = ({setStatusOfCreating})=>{

    const options = {};
    options.defaultValues = { ...defaultValuesCreateArtEvent, headliner: "" };
    options.disabledValues = {
        eventName:false,
        date:false,
        amountOfTickets:false,
        place:false,
        price:false,
        headliner:false,
        image:false
    
    };
    options.onSubmitFunction = onSubmitOpenAirCreateFunction(setStatusOfCreating);
    options.submitName = "Create";
    options.image = {isRequired:true};
    
    return <OpenAirBaseForm options={options} />
}

export default OpenAirCreateForm;