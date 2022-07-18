import React from "react";
import ArtEventDetails from "./ArteEventDetails";

const OpenAirSpecific = (props) =>
    <div>
        <div>{props.headLiner}</div>        
    </div>

function OpenAirDetails(props) {
    return (
        <ArtEventDetails {...props} ConcreteIventData={OpenAirSpecific}/>
    )
}
export default OpenAirDetails;