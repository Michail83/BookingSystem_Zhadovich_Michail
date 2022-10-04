import React from "react";
import ArtEventDetails from "./ArteEventDetails";
import ClassicMusicSpecific from "./ArtEventSpecificPart/ClassicMusicSpecific";

function ClassicMusicDetails(props) {
    return (
        <ArtEventDetails {...props} ConcreteIventData={ClassicMusicSpecific}/>
    )
}
export default ClassicMusicDetails;