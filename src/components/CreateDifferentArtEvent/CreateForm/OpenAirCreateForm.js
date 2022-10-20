import React, { Fragment, useEffect, useState } from "react";
// import { useForm } from "react-hook-form";
// import API_URL from "../../API_URL";
// import axios from "axios";
// import { Input, Form, Label, ErrorMessage, SubmitButton } from "./StyledComponentsForCreateEvents"
// import { MapAbsoluteContainer } from "../StyledComponent/Map/MapAbsoluteContainer";
import { defaultValuesCreateArtEvent } from "../../../CONST/DefaultValuesCreateArtEvent";
// import YandMAP_CreateEvent from "../YandMAP/YandMAP_CreateEvent";
// import styled from "styled-components";
// import { unAuthorizedHandler } from "../../function/unAuthorizedHandler";



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
    
    return <OpenAirBaseForm options={options} />
}

export default OpenAirCreateForm;