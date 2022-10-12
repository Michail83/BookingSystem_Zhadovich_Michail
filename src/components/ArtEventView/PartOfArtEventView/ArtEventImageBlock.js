import React from "react";
import { ArtEventImage } from "../StyledTag/ArtEventImage";
import { NoImageavailable } from "../../../CONST/NoImageAvailable";
import { IMAGE } from "../StyledTag/IMAGE";

const ArtEventImageBlock=(props)=>{

    return (
            <ArtEventImage>
                <IMAGE src={props.image? `data:image/jpeg;base64,${props.image}`:NoImageavailable} width={"320px"} alt={NoImageavailable} title="image"/>
            </ArtEventImage>
    )
}
export default ArtEventImageBlock;