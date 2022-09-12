import React,{useEffect, useState} from "react";

import { useForm } from "react-hook-form"; 
// import { ErrorMessage } from "@hookform/error-message";

// import createNewArtEvent from "../createNewArtEvent";
import API_URL from "../../API_URL";
import axios from "axios";
import {Input, Form, Label, ErrorMessage,SubmitButton} from "./StyledComponentsForCreateEvents"
import { defaultValuesCreateArtEvent } from "../../CONST/DefaultValuesCreateArtEvent";

const defaultValues = {...defaultValuesCreateArtEvent, voice:"",concertName:"" } ;

// ////////////////////////////////////////////////////////////////////
const ClassicMusicCreateForm =({setStatusOfCreating})=>{
    console.log("render");

    // const [statusOfCreating, setStatusOfCreating] = useState("");

    const {
        register,       
        handleSubmit,
        formState,
        formState: { isSubmitSuccessful,errors }, 
        reset
    } = useForm(
        {defaultValues: defaultValues 
    });

    useEffect(() => {
    if (formState.isSubmitSuccessful) {
      reset({ ...defaultValues });
    }
  }, [formState, reset]);

    const onSubmit =async (data, event)=>{ 
        event.preventDefault()       
        try {
            let result = await axios.post(API_URL.classicmusics(),data); 
            if (result.status==200) setStatusOfCreating(true);
        } catch (error) {
            console.log(error);
        }
    }

    return(
       <Form onSubmit={handleSubmit(onSubmit)}>
        <Label> ArtEvent name</Label>
        <Input type={"text"} {...register("eventName", {required: true, minLength:2})}  />
        {errors.eventName?.type==="required"&& <ErrorMessage>ArtEvent name is required</ErrorMessage>}
        {errors.eventName?.type ==="minLength" && <ErrorMessage>min length is 2</ErrorMessage>}
        
        <Label> Date and Time</Label>
        <Input type={"datetime-local"} {...register("date", {required: true})}  />
        {errors.date?.type==="required"&& <ErrorMessage>Date is required</ErrorMessage>}
       
        <Label> Amount Of Tickets</Label>
        <Input type={"number"} {...register("amountOfTickets", {required: true, min:1 })}  />
        {errors.amountOfTickets?.type==="required"&& <ErrorMessage>quantity of tickets cannot be zero or lesser </ErrorMessage>}
        {errors.amountOfTickets?.type==="min"&& <ErrorMessage>quantity of tickets cannot be zero or lesser</ErrorMessage>}

        <Label> Place</Label>
        <Input type={"text"} {...register("place", {required: true, minLength:5})}  />
        {errors.place?.type==="required"&& <ErrorMessage>Place is required</ErrorMessage>}
        {errors.place?.type==="minLength"&& <ErrorMessage>min length is 5 symbol's</ErrorMessage>}    
        
        <Label> Latitude</Label>
        <Input type={"number"} {...register("latitude", {required: true})}  />        
        
        <Label> Longitude</Label>
        <Input type={"number"} {...register("longitude", {required: true})}  />
        {errors.longitude?.type==="required"||errors.latitude?.type==="required"?<ErrorMessage>Please enter the coordinates</ErrorMessage>:""}
        
        
        <Label> Voice</Label>
        <Input type={"text"} {...register("voice", {required: true, minLength:2})}  />
        {errors.voice?.type==="required"&& <ErrorMessage>Voice is required</ErrorMessage>}
        {errors.voice?.type==="minLength"&& <ErrorMessage>min length is 2 symbol's</ErrorMessage>} 
        

        <Label> Concert Name</Label>
        <Input type={"text"} {...register("concertName", {required: true, minLength:2})}  />
        {errors.concertName?.type==="required"&& <ErrorMessage>Concert Name is required</ErrorMessage>}
        {errors.concertName?.type==="minLength"&& <ErrorMessage>min length is 2 symbol's</ErrorMessage>} 
        


        <SubmitButton type={"submit"} /> 
        {/* <span>{statusOfCreating&&"Successfully created"}</span> */}
        </Form>
    )
}
export default ClassicMusicCreateForm;




