import React from "react";
import AdminArtEventDetails from "./AdminArtEventDetails";

import OpenAirSpecific from "../ArtEventSpecificPart/OpenAirSpecific";
   
function AdminOpenAirDetails(props) {
    return (
        <AdminArtEventDetails {...props} ConcreteIventData={OpenAirSpecific}/>
    )
}
export default AdminOpenAirDetails;