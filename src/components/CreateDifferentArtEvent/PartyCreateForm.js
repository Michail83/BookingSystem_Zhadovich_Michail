import React, { Fragment, useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import API_URL from "../../API_URL";
import axios from "axios";
import { Input, Form, Label, ErrorMessage, SubmitButton } from "./StyledComponentsForCreateEvents"
import { MapAbsoluteContainer } from "../StyledComponent/Map/MapAbsoluteContainer";
import { defaultValuesCreateArtEvent } from "../../CONST/DefaultValuesCreateArtEvent";
import YandMAP_CreateEvent from "../YandMAP/YandMAP_CreateEvent";
import styled from "styled-components";
import { unAuthorizedHandler } from "../../function/unAuthorizedHandler";



const MapHeader = styled.h3`
    text-align: center;
`;
const defaultValues = { ...defaultValuesCreateArtEvent, ageLimitation: "" };

const PartyCreateForm = ({ setStatusOfCreating }) => {
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
        event.preventDefault();
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
        formData.append('ageLimitation', data.ageLimitation);
        formData.append('Image', data.image[0])

        try {
            let result = await axios.post(API_URL.parties(), formData, config);
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

                <Label> ageLimitation</Label>
                <Input type={"number"} step={1} {...register("ageLimitation", { required: true, min: 0, max: 99})} />
                {errors.ageLimitation?.type === "required" && <ErrorMessage>headliner is required</ErrorMessage>}
                {errors.ageLimitation?.type === "min" || errors.ageLimitation?.type === "max" && <ErrorMessage>Enter number between 0 and 99</ErrorMessage>}

                <Label>Image </Label>
                <Input type={"file"} accept={"image/png, image/jpeg"} {...register("image", { required: true })} ></Input>
                {errors.image?.type === "required" && <ErrorMessage>Image is required</ErrorMessage>}  

                <SubmitButton type={"submit"} >Create</SubmitButton>  

            </Form>
            {isMapShow &&
                <MapAbsoluteContainer>
                    <MapHeader>Choose place on the map and click confirm button</MapHeader>
                    <YandMAP_CreateEvent setIsMapShow={setIsMapShow} setPlace={setPlace} setCoord={setCoord} />
                </MapAbsoluteContainer>}

        </Fragment>
    )
}
export default PartyCreateForm;