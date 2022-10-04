import React, { Fragment, useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import API_URL from "../../API_URL";
import axios from "axios";
import { Input, Form, Label, ErrorMessage, SubmitButton, Select } from "./StyledComponentsForCreateEvents"
import { defaultValuesCreateArtEvent } from "../../CONST/DefaultValuesCreateArtEvent";
import YandMAP_CreateEvent from "../YandMAP/YandMAP_CreateEvent";
import styled from "styled-components";
import { unAuthorizedHandler } from "../../function/unAuthorizedHandler";

import { VoiseList } from "../../CONST/VoiseList";

const AbsoluteContainer = styled.div`
    position:absolute;
    width:100vw;
    height: calc(100vh - 7.5rem);    
    top:6.5rem;
    left:0;    
    background-color: #a0e0e8;
`;

const MapHeader = styled.h3`
    text-align: center;
`;
const defaultValues = { ...defaultValuesCreateArtEvent, voice: "", concertName: "" };

const ClassicMusicCreateForm = ({ setStatusOfCreating }) => {
    const [isMapShow, setIsMapShow] = useState(false);

    const {
        register,
        handleSubmit,
        formState,
        setValue,
        formState: { isSubmitSuccessful, errors },
        reset
    } = useForm(
        {
            defaultValues: defaultValues
        });

    useEffect(() => {
        if (formState.isSubmitSuccessful) {
            reset({ ...defaultValues });
        }
    }, [formState, reset]);

    const onSubmit = async (data, event) => {
        event.preventDefault()
        const config = {
            headers: {
                'content-type': 'multipart/form-data',
            },
        };
        const formData = new FormData();

        formData.append('EventName', data.eventName);
        formData.append('Date', data.date);
        formData.append('AmountOfTickets', data.amountOfTickets);
        formData.append('Place', data.place);
        formData.append('Latitude', data.latitude);
        formData.append('Longitude', data.longitude);
        formData.append('voice', data.voice);
        formData.append('concertName', data.concertName);
        formData.append('Image', data.image[0]);
        try {
            let result = await axios.post(API_URL.classicmusics(), formData, config);
            if (result.status == 200) setStatusOfCreating(true);
        } catch (error) {
            setStatusOfCreating(false);
            unAuthorizedHandler(error.response.status);
        }
    }
    const setPlace = (place) => {
        setValue("place", place);
    }
    const setCoord = (coord) => {
        setValue("latitude", coord[0]);
        setValue("longitude", coord[1]);
    }

    const onClickOnPlace = (event) => {
        event.preventDefault();
        setIsMapShow(true);
        event.currentTarget.blur();
    }

    return (
        <Fragment>
            <Form onSubmit={handleSubmit(onSubmit)}>
                <Label> ArtEvent name</Label>
                <Input type={"text"} {...register("eventName", { required: true, minLength: 2 })} />
                {errors.eventName?.type === "required" && <ErrorMessage>ArtEvent name is required</ErrorMessage>}
                {errors.eventName?.type === "minLength" && <ErrorMessage>min length is 2</ErrorMessage>}

                <Label> Date and Time</Label>
                <Input type={"datetime-local"} {...register("date", { required: true })} />
                {errors.date?.type === "required" && <ErrorMessage>Date is required</ErrorMessage>}

                <Label> Amount Of Tickets</Label>
                <Input type={"number"} {...register("amountOfTickets", { required: true, min: 1 })} />
                {errors.amountOfTickets?.type === "required" && <ErrorMessage>quantity of tickets cannot be zero or lesser </ErrorMessage>}
                {errors.amountOfTickets?.type === "min" && <ErrorMessage>quantity of tickets cannot be zero or lesser</ErrorMessage>}

                <Label> Place</Label>
                <Input type={"text"} {...register("place", { required: true, minLength: 5 })} onClick={onClickOnPlace} placeholder={"click and choose place on the map"} />
                {errors.place?.type === "required" && <ErrorMessage>Place is required</ErrorMessage>}

                <Input style={{ position: "absolute", visibility: "hidden", width: "5%" }} step={"any"}  type={"number"} {...register("latitude", { required: true })} />
                <Input style={{ position: "absolute", visibility: "hidden", width: "5%" }} step={"any"}  type={"number"} {...register("longitude", { required: true })} />


                <Label> Voice</Label>
                <Select {...register("voice")}>
                    {VoiseList.map((voice)=><option key={voice.value} value={voice.value} >{voice.name}</option>)}
                </Select>


                {/* <Label> Voice</Label>
                <Input type={"text"} {...register("voice", { required: true, minLength: 2 })} />

                {errors.voice?.type === "required" && <ErrorMessage>Voice is required</ErrorMessage>}
                {errors.voice?.type === "minLength" && <ErrorMessage>min length is 2 symbol's</ErrorMessage>} */}


                <Label> Concert Name</Label>
                <Input type={"text"} {...register("concertName", { required: true, minLength: 2 })} />
                {errors.concertName?.type === "required" && <ErrorMessage>Concert Name is required</ErrorMessage>}
                {errors.concertName?.type === "minLength" && <ErrorMessage>min length is 2 symbol's</ErrorMessage>}

                <Label>Image </Label>
                <Input type={"file"} accept={"image/png, image/jpeg"} {...register("image", { required: true })} ></Input>
                {errors.image?.type === "required" && <ErrorMessage>Image is required</ErrorMessage>}  

                <SubmitButton type={"submit"} >Create</SubmitButton>  
            </Form>
            {isMapShow &&
                <AbsoluteContainer>
                    <MapHeader>Choose place on the map and click confirm button</MapHeader>
                    <YandMAP_CreateEvent setIsMapShow={setIsMapShow} setPlace={setPlace} setCoord={setCoord} />
                </AbsoluteContainer>}

        </Fragment>
    )
}
export default ClassicMusicCreateForm;