import React, { useState } from "react";
import { connect } from "react-redux";
import actionCreator from "../../Store/ActionsCreators/actionCreator";
import { FieldsNameForCreateArtEvent } from "../../CONST/FieldsNameForBaseCreateForm";
import BaseCreateForm_ReduxWrapped from "./BaseCreateForm";
import API_URL from "../../API_URL";
import { HEADLINER } from "../../CONST/FieldsNameForOPENAIRCreateForm";
import OpenAirCreateFormDifferentPart_ReduxWrapped from "./OpenAirCreateFormDifferentPart_reduxWrapped";
import sendNewArtEventFunction from "./createNewArtEvent";

const OpenAirCreateFormNew = ()=>{
    // console.log("check");
    let url = API_URL.openairs();
    let type = "creatingOpenAir";   /////////
    
    return (
    <BaseCreateForm_ReduxWrapped Different={OpenAirCreateFormDifferentPart_ReduxWrapped} sendFunction={()=>sendNewArtEventFunction(url,type)}/>)
}
export default OpenAirCreateFormNew;


