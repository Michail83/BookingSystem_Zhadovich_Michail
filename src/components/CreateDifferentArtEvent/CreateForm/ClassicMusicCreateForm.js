import React from "react";

import { defaultValuesCreateArtEvent } from "../../../CONST/DefaultValuesCreateArtEvent";
import onSubmitClassicMusicCreateFunction from "../OnSubmitFunction/onSubmitClassicMusicCreateFunction";

import ClassicMusicBaseForm from "../BaseForms/ClassicMusicBaseForm";

const ClassicMusicCreateForm = ({setStatusOfCreating})=>{

    const options = {};
    options.defaultValues = { ...defaultValuesCreateArtEvent, voice: "", concertName:"" };
    options.disabledValues = {
        eventName:false,
        date:false,
        amountOfTickets:false,
        place:false,
        price:false,
        voice:false,
        concertName:false,
        image:false
    
    };
    options.onSubmitFunction = onSubmitClassicMusicCreateFunction(setStatusOfCreating);
    options.submitName = "Create";
    options.image = {isRequired:true};
    
    return <ClassicMusicBaseForm options={options} />
}

export default ClassicMusicCreateForm;