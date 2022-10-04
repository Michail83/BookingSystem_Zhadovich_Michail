import React from "react";
import AdminArtEventDetails from "./AdminArtEventDetails";

import PartySpecific from "../ArtEventSpecificPart/PartySpecific";

function AdminPartyDetails(props) {
    return (
        <AdminArtEventDetails {...props} ConcreteIventData={PartySpecific}/>
    )
}
export default AdminPartyDetails;