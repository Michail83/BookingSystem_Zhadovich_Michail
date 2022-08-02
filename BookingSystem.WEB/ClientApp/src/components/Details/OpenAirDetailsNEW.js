import React from "react";
import ArtEventDetails from "./ArteEventDetails";

const OpenAirSpecific = (props) =>
   <p>{props.headLiner}</p>
   
function OpenAirDetails(props) {
    return (
        <ArtEventDetails {...props} ConcreteIventData={OpenAirSpecific}/>
    )
}
export default OpenAirDetails;