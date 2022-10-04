import React from "react";
import ArtEventDetails from "./ArteEventDetails";
import OpenAirSpecific from "./ArtEventSpecificPart/OpenAirSpecific";
   
function OpenAirDetails(props) {
    return (
        <ArtEventDetails {...props} ConcreteIventData={OpenAirSpecific}/>
    )
}
export default OpenAirDetails;