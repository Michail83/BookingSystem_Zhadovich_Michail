import React, { Fragment, useEffect, useState } from "react";
import { useForm } from "react-hook-form";
// import API_URL from "../../API_URL";
// import axios from "axios";
import { Input, Form, Label, ErrorMessage, SubmitButton } from "../StyledComponentsForCreateEvents"
import { MapAbsoluteContainer } from "../../StyledComponent/Map/MapAbsoluteContainer";
// import { defaultValuesCreateArtEvent } from "../../../CONST/DefaultValuesCreateArtEvent";
import YandMAP_CreateEvent from "../../YandMAP/YandMAP_CreateEvent";
import styled from "styled-components";
// import { unAuthorizedHandler } from "../../function/unAuthorizedHandler";





const MapHeader = styled.h3`
    text-align: center;
`;
// const defaultValues = { ...defaultValuesCreateArtEvent, headliner: "" };
//////////////////////////////
const OpenAirBaseForm = ({ options }) => {
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
            defaultValues: options.defaultValues
        });

    useEffect(() => {
        if (formState.isSubmitSuccessful) {
            reset({ ...defaultValues });
        }
    }, [formState, reset]);

    // const onSubmit = async (data, event) => {
    //     event.preventDefault();
    //     const config = {
    //         headers: {
    //           'content-type': 'multipart/form-data',
    //         },
    //       };
    //       const formData = new FormData();    

    //       formData.append('EventName', data.eventName);
    //       formData.append('Date', data.date);
    //       formData.append('AmountOfTickets', data.amountOfTickets);
    //       formData.append('Place', data.place);
    //       formData.append('Price', data.price);          
    //       formData.append('Latitude', data.latitude);
    //       formData.append('Longitude', data.longitude);
    //       formData.append('HeadLiner', data.headliner);
    //       formData.append('Image', data.image[0])        

    //     try {
    //         let result = await axios.post(API_URL.openairs(), formData, config );
    //         if (result.status == 200) {
    //             setStatusOfCreating(true);
                
    //         }
    //     } catch (error) {
    //         setStatusOfCreating(false);
    //         unAuthorizedHandler(error.response.status);
            
    //     }
    // }
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
            <Form onSubmit={handleSubmit(options.onSubmitFunction)}>
                <Label> ArtEvent name</Label>
                <Input disabled={options.disabledValues.eventName} type={"text"} {...register("eventName", { required: true, minLength: 2 })} />
                {errors.eventName?.type === "required" && <ErrorMessage>ArtEvent name is required</ErrorMessage>}
                {errors.eventName?.type === "minLength" && <ErrorMessage>min length is 2</ErrorMessage>}

                <Label> Date and Time</Label>
                <Input disabled={options.disabledValues.date}  type={"datetime-local"} {...register("date", { required: true })} />
                {errors.date?.type === "required" && <ErrorMessage>Date is required</ErrorMessage>}

                <Label> Amount Of Tickets</Label>
                <Input disabled={options.disabledValues.amountOfTickets}  type={"number"} {...register("amountOfTickets", { required: true, min: 1 })} />
                {errors.amountOfTickets?.type === "required" && <ErrorMessage>quantity of tickets cannot be zero or lesser </ErrorMessage>}
                {errors.amountOfTickets?.type === "min" && <ErrorMessage>quantity of tickets cannot be zero or lesser</ErrorMessage>}

                <Label> Place</Label>
                <Input disabled={options.disabledValues.place}  type={"text"}  {...register("place", { required: true })} onClick={(event)=>{onClickOnPlace(event); errors.place=""; }} placeholder={"click and choose place on the map"} />
                {errors.place?.type === "required" && <ErrorMessage>Place is required</ErrorMessage>}

                <Label> Price</Label>
                <Input disabled={options.disabledValues.price}  type={"number"} step={"any"}  defaultValue={undefined} {...register("price", { required: true , min:0})}   />
                {errors.price?.type === "required" && <ErrorMessage>Price is required</ErrorMessage>}
                {errors.price?.type === "min" && <ErrorMessage>Price cannot be a negative number </ErrorMessage>}

                <Input style={{position:"absolute", visibility:"hidden", width:"5%"}}  type={"number"} step={"any"} {...register("latitude", { required: true })} />
                <Input style={{position:"absolute", visibility:"hidden", width:"5%"}}   type={"number"} step={"any"} {...register("longitude", { required: true })} />

                <Label> headliner</Label>
                <Input disabled={options.disabledValues.headliner}  type={"text"} {...register("headLiner", { required: true, minLength: 2 })} />
                {errors.headLiner?.type === "required" && <ErrorMessage>headliner is required</ErrorMessage>}
                {errors.headLiner?.type === "minLength" && <ErrorMessage>min length is 2 symbol's</ErrorMessage>}                

                <Label>Image </Label>   
                <Input disabled={options.disabledValues.image}  type={"file"} accept={"image/png, image/jpeg"} {...register("image")} ></Input> 
                {errors.image?.type === "required" && <ErrorMessage>Image is required</ErrorMessage>}     

                <SubmitButton type={"submit"} >{options.submitName}</SubmitButton>       

            </Form>            
            {isMapShow &&
                <MapAbsoluteContainer>
                    <MapHeader>Choose place on the map and click confirm button</MapHeader>
                    <YandMAP_CreateEvent setIsMapShow={setIsMapShow} setPlace={setPlace} setCoord={setCoord} />
                </MapAbsoluteContainer>}

        </Fragment>
    )
}
export default OpenAirBaseForm;