import React from "react";
import { defaultValuesCreateArtEvent } from "../../../CONST/DefaultValuesCreateArtEvent";
import onSubmitPartyCreateFunction from "../OnSubmitFunction/onSubmitPartyCreateFunction"
import PartyBaseForm from "../BaseForms/PartyBaseForm";

const PartyCreateForm = ({setStatusOfCreating})=>{

    const options = {};
    options.defaultValues = { ...defaultValuesCreateArtEvent, ageLimitation: "" };
    options.disabledValues = {
        eventName:false,
        date:false,
        amountOfTickets:false,
        place:false,
        price:false,
        ageLimitation:false,
        image:false
    
    };
    options.onSubmitFunction = onSubmitPartyCreateFunction(setStatusOfCreating);
    options.submitName = "Create";
    options.image = {isRequired:true};

    
    return <PartyBaseForm options={options} />
}

export default PartyCreateForm;