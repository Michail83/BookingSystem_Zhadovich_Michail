import React from "react";
import ArtEventDetails from "./ArteEventDetails";

const PartySpecific = (props) =>
    <div>
        <div>{props.ageLimitation}</div>        
    </div>

function PartyDetails(props) {
    return (
        <ArtEventDetails {...props} ConcreteIventData={PartySpecific}/>
    )
}
export default PartyDetails;