import React,{useEffect, useState} from "react";

import { useForm } from "react-hook-form"; 
// import { ErrorMessage } from "@hookform/error-message";

// import createNewArtEvent from "../createNewArtEvent";
import API_URL from "../../API_URL";
import axios from "axios";
import {Input, Form, Label, ErrorMessage,SubmitButton} from "./StyledComponentsForCreateEvents"
import { defaultValuesCreateArtEvent } from "../../CONST/DefaultValuesCreateArtEvent";

const defaultValues = {...defaultValuesCreateArtEvent, ageLimitation:""} ;

// ////////////////////////////////////////////////////////////////////
const PartyCreateForm =()=>{
    console.log("render");

    const [statusOfCreating, setStatusOfCreating] = useState("");

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
            let result = await axios.post(API_URL.parties(),data); 
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
        
        <Label> Latitude</Label>
        <Input type={"text"} {...register("latitude", {required: true})}  />        
        
        <Label> Longitude</Label>
        <Input type={"text"} {...register("longitude", {required: true})}  />
        {errors.longitude?.type==="required"||errors.latitude?.type==="required"?<ErrorMessage>Please enter the coordinates</ErrorMessage>:""}
        
        
        <Label> ageLimitation</Label>
        <Input type={"text"} {...register("ageLimitation", {required: true, min:0, max:99 })}  />
        {errors.ageLimitation?.type==="required"&& <ErrorMessage>headliner is required</ErrorMessage>}
        {errors.ageLimitation?.type==="min"||errors.ageLimitation?.type==="max"&& <ErrorMessage>Enter number between 0 and 99</ErrorMessage>}


        <SubmitButton type={"submit"} /> <span>{statusOfCreating&&"Successfully created"}</span>
        </Form>
    )
}
export default PartyCreateForm;




