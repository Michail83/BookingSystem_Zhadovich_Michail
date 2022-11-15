import React from "react";
import { AddititionalInfoRender } from "../AddititionalInfoRender";
import { AboutArtEventDiv } from "../StyledTag/AboutArtEvent";
import { StyledSpan } from "../StyledTag/StyledSpan";

import { dateTimeStringToLocaleDateTime } from "../../../function/dateTimeStringToLocaleDateTime";


const ArtEventDataBlock = (props)=>{    

return (   
    <AboutArtEventDiv currentMinWidth={props.currentMinWidth} >
                <StyledSpan>{props.typeOfArtEvent}:  </StyledSpan><h3> {props.eventName}</h3>
                <AddititionalInfoRender {...props}/>
                <StyledSpan> Date:  </StyledSpan><p> {dateTimeStringToLocaleDateTime(props.date)}</p>
                <StyledSpan>Tickets left:  </StyledSpan><h5>{props.amountOfTickets}</h5>
                <StyledSpan>Price:  </StyledSpan><h5>{props.price}</h5>
                <StyledSpan>address:  </StyledSpan><p> {props.place}</p>
 </AboutArtEventDiv>   
)
}
export default ArtEventDataBlock;