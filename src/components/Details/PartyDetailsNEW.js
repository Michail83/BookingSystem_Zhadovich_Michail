import React from "react";
import ArtEventDetails from "./ArteEventDetails";
import PartySpecific from "./ArtEventSpecificPart/PartySpecific";

function PartyDetails(props) {
    return (
        <ArtEventDetails {...props} ConcreteIventData={PartySpecific}/>
    )
}
export default PartyDetails;