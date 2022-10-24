import React, { Fragment, useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { Input, Form, Label, ErrorMessage, SubmitButton, MapHeader } from "../StyledComponentsForCreateEvents"
import { MapAbsoluteContainer } from "../../StyledComponent/Map/MapAbsoluteContainer";
import YandMAP_CreateEvent from "../../YandMAP/YandMAP_CreateEvent";

const PartyBaseForm = ({ options }) => {
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
            reset({ ...options.defaultValues });
        }
    }, [formState, reset]);
    
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
                <Input disabled={options.disabledValues.date} type={"datetime-local"} {...register("date", { required: true })} />
                {errors.date?.type === "required" && <ErrorMessage>Date is required</ErrorMessage>}

                <Label> Amount Of Tickets</Label>
                <Input disabled={options.disabledValues.amountOfTickets}  type={"number"} {...register("amountOfTickets", { required: true, min: 1 })} />
                {errors.amountOfTickets?.type === "required" && <ErrorMessage>quantity of tickets cannot be zero or lesser </ErrorMessage>}
                {errors.amountOfTickets?.type === "min" && <ErrorMessage>quantity of tickets cannot be zero or lesser</ErrorMessage>}

                <Label> Place</Label>
                <Input disabled={options.disabledValues.place} type={"text"} {...register("place", { required: true, minLength: 5 })} onClick={(event)=>{onClickOnPlace(event); errors.place=""; }} placeholder={"click and choose place on the map"} />
                {errors.place?.type === "required" && <ErrorMessage>Place is required</ErrorMessage>}

                <Label> Price</Label>
                <Input disabled={options.disabledValues.price} type={"number"} step={"any"}  defaultValue={""} {...register("price", { required: true , min:0})}   />
                {errors.price?.type === "required" && <ErrorMessage>Price is required</ErrorMessage>}
                {errors.price?.type === "min" && <ErrorMessage>Price cannot be a negative number </ErrorMessage>}
               
                <Input style={{ position: "absolute", visibility: "hidden", width: "5%" }} step={"any"}  type={"number"} {...register("latitude", { required: true })} />
                <Input style={{ position: "absolute", visibility: "hidden", width: "5%" }} step={"any"}  type={"number"} {...register("longitude", { required: true })} />

                <Label> ageLimitation</Label>
                <Input disabled={options.disabledValues.ageLimitation} type={"number"} step={1} {...register("ageLimitation", { required: true, min: 0, max: 99})} />
                {errors.ageLimitation?.type === "required" && <ErrorMessage>headliner is required</ErrorMessage>}
                
                {(errors.ageLimitation?.type === "min" || errors.ageLimitation?.type === "max") && <ErrorMessage>Enter number between 0 and 99</ErrorMessage>}

                <Label>Image </Label>
                <Input disabled={options.disabledValues.image} type={"file"} accept={"image/png, image/jpeg"} {...register("image", { required: options.image.isRequired })} ></Input>
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
export default PartyBaseForm;