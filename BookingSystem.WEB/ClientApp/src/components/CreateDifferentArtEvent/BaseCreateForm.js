import React, { useState } from "react";
import { connect } from "react-redux";
import actionCreator from "../../Store/ActionsCreators/actionCreator";
import { FieldsNameForCreateArtEvent } from "../../CONST/FieldsNameForBaseCreateForm";

const BaseCreateForm = ({
    Different,
    sendFunction,
    tempEventName,
    tempDateTime,
    tempAmountOfTickets,
    tempPlace, tempLatitude,
    tempLongitude,
    setTempValue,
    clearAllTempData
     }) => {

        console.log("check");

        function handleSubmit(e) {
            e.preventDefault();
            if (sendFunction()!=undefined) {
                clearAllTempData();
            }
        } 


    return (
        <form className="maincreate"  autoComplete="off" onSubmit={(event)=>handleSubmit(event)}>
            <div>
                <label>Name
                    <input
                        value={tempEventName}
                        name={FieldsNameForCreateArtEvent.ARTEVENTNAME}
                        required
                        type="text"
                        onChange={(event) => setTempValue(event)}>
                    </input>
                </label>
            </div>
            <div>
                <label>Date
                    <input
                        value={tempDateTime}
                        required type="datetime-local"
                        name={FieldsNameForCreateArtEvent.DATETIME}
                        onChange={(event) => setTempValue(event)}>
                    </input>
                </label>
            </div>
            <div>
                <label>amount Of Ticket
                    <input
                        value={tempAmountOfTickets}
                        name={FieldsNameForCreateArtEvent.AMOUNTOFTICKET}
                        required
                        type="number"
                        onChange={(event) => setTempValue(event)}>
                    </input>
                </label>
            </div>
            <div>
                <label>Place
                    <input
                        value={tempPlace}
                        name = {FieldsNameForCreateArtEvent.PLACE}
                        required
                        type="text"
                        onChange={(event) => setTempValue(event)}>
                    </input>
                </label>
            </div>

            <div>
                <label>Сoordinates
                    <input
                        required
                        name={FieldsNameForCreateArtEvent.LATITUDE}
                        value={tempLatitude}
                        placeholder="latitude"
                        type="text"
                        onChange={(event) => setTempValue(event)}>
                    </input>
                    <input
                        required
                        name={FieldsNameForCreateArtEvent.LONGITUDE}
                        value={tempLongitude}
                        placeholder="longitude"
                        type="text"
                        onChange={(event) => setTempValue(event)}>
                    </input>
                </label>
            </div>
            <Different/>

            <label><input type="submit" value="Create" ></input></label>
            {/* <button onClick={clearAllTempData}>Clear</button> */}
        </form>
    )
}
const mapStateToProps = state => ({
    tempEventName: state.creatingBaseData[FieldsNameForCreateArtEvent.ARTEVENTNAME],
    tempDateTime: state.creatingBaseData[FieldsNameForCreateArtEvent.DATETIME],
    tempAmountOfTickets: state.creatingBaseData[FieldsNameForCreateArtEvent.AMOUNTOFTICKET],
    tempPlace: state.creatingBaseData[FieldsNameForCreateArtEvent.PLACE],
    tempLatitude: state.creatingBaseData[FieldsNameForCreateArtEvent.LATITUDE],
    tempLongitude: state.creatingBaseData[FieldsNameForCreateArtEvent.LONGITUDE],    
 
});

const mapDispatchToProps = dispatch => (
    {
        setTempValue: (event) => dispatch(actionCreator.setBaseCreatingData({ [event.target.name]: event.target.value })),
        clearAllTempData: () => dispatch(actionCreator.ClearALLTempCreatingData())
    });

const BaseCreateForm_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(BaseCreateForm);

export default BaseCreateForm_ReduxWrapped;