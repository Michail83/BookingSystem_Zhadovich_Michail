import React from "react";
import AdminArtEventDetails from "./AdminArtEventDetails";
import ClassicMusicSpecific from "../ArtEventSpecificPart/ClassicMusicSpecific";

function AdminClassicMusicDetails(props) {
    return (
        <AdminArtEventDetails {...props} ConcreteIventData={ClassicMusicSpecific}/>
    )
}
export default AdminClassicMusicDetails;