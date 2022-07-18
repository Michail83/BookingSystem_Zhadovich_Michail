import React, { useState } from "react";
import { connect } from "react-redux";
import actionCreator from "../../Store/ActionsCreators/actionCreator";
import { FieldsNameForCreateArtEvent } from "../../CONST/FieldsNameForBaseCreateForm";
import BaseCreateForm_ReduxWrapped from "./BaseCreateForm";
import API_URL from "../../API_URL";
import { HEADLINER } from "../../CONST/FieldsNameForOPENAIRCreateForm";

const OpenAirCreateFormDifferentPart = ({tempEventHeadliner,setCreatingHeadliner}) => {
//    console.log("check")
    return (
        <div>
            <label>Headliner
                <input
                    value={tempEventHeadliner}
                    name={HEADLINER}
                    required
                    type="text"
                    onChange={(event) => setCreatingHeadliner(event)}>
                </input>
            </label>
        </div>
    )
}
const mapStateToProps = state => ({
    tempEventHeadliner: state.creatingOpenAir[HEADLINER] 
});

const mapDispatchToProps = dispatch => (
    {
        setCreatingHeadliner: (event) => dispatch(actionCreator.setAdditionalOpenAirCreatingData({ [event.target.name]: event.target.value })),        
    });

const OpenAirCreateFormDifferentPart_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(OpenAirCreateFormDifferentPart);

export default OpenAirCreateFormDifferentPart_ReduxWrapped;
