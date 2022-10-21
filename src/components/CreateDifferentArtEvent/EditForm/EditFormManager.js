// import React, { Fragment, useEffect, useState } from "react";
// // import { useForm } from "react-hook-form";
// // import API_URL from "../../API_URL";
// // import axios from "axios";
// // import { Input, Form, Label, ErrorMessage, SubmitButton } from "./StyledComponentsForCreateEvents"
// // import { MapAbsoluteContainer } from "../StyledComponent/Map/MapAbsoluteContainer";
// // import { defaultValuesCreateArtEvent } from "../../../CONST/DefaultValuesCreateArtEvent";
// // import YandMAP_CreateEvent from "../YandMAP/YandMAP_CreateEvent";
// // import styled from "styled-components";
// // import { unAuthorizedHandler } from "../../function/unAuthorizedHandler";

// import axios from "axios";
// import api_url from "../../../API_URL";
// import OpenAirEditForm from "./OpenAirEditForm";


// const EditFormManager=(props)=>{
    
//         const getArtEvent = async(url)=>{
    
//             try {
//                 const result = await axios.get(url)
//                 return result.data;
//             } catch (error) {
//                 return null;
//             }        
//         };
//     let result;
//     switch (props.artEventType) {

//         case "ClassicMusic":        
//         result =  await getArtEvent(api_url.classicmusics(id));
//         break;

//         case "Party":
//         result = await getArtEvent(api_url.parties(id));            
//         break;

//         case "OpenAir": 
//         result = await getArtEvent(api_url.openairs(id));  
//         return <OpenAirEditForm  setStatusOfCreating={props.setStatusOfCreating} defaulValues={result}/>

//         default:
//             break;
//     }
// }
// export default EditFormManager;