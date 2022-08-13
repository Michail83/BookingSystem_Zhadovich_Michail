import React from "react";
import ArtEventDetails from "./ArteEventDetails";

const ClassicMusicSpecific = (props) =>
    <div>
        <div>{props.voice}</div>
        <div>{props.concertName}</div>
    </div>

function ClassicMusicDetails(props) {
    return (
        <ArtEventDetails {...props} ConcreteIventData={ClassicMusicSpecific}/>
    )
}
export default ClassicMusicDetails;