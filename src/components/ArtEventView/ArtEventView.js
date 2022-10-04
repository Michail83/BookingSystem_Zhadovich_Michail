import React from "react";
import styled from "styled-components";
import { NoImageavailable } from "../../CONST/NoImageAvailable";
import { StyledSpan } from "./StyledSpan";
import { AddititionalInfoRender } from "./AddititionalInfoRender";

const ButtonBlock = styled.div`
    display: flex;
    flex-flow: column nowrap;
    align-items: stretch;
    justify-content: center;
    width: 12%;
    min-width: 6rem;
    flex-grow: 5;
`;
const MainArtEventView = styled.div`
    border-bottom: 1px solid blue;
    padding: 3px 3px;
    display: flex;
    flex-wrap: wrap;
    flex-direction: row;
    flex: 0 1 100%;
    align-items: stretch;   
`;
const ArtEventViewImage = styled.div`
    width:320px;
    display:flex;
    align-items: center;
    justify-content: center;
    
`;
const AboutArtEvent = styled.div`
    padding: 3px 3px;
    min-width: 55%;
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
    margin-left: 1rem;
    &*{
        margin: 0.4rem
    }
`;
const IMAGE = styled.img` 
    object-fit: cover ;
`;


function ArtEventView(props) { 
    return(
        <MainArtEventView >
            <ArtEventViewImage>
                <IMAGE src={props.image? `data:image/jpeg;base64,${props.image}`:NoImageavailable} width={"320px"} alt={NoImageavailable} title="image"/>

            </ArtEventViewImage>
            <AboutArtEvent>
                <StyledSpan>{props.typeOfArtEvent}:  </StyledSpan><h3> {props.eventName}</h3>

                <AddititionalInfoRender {...props}/>

                <StyledSpan> Date:  </StyledSpan><p> {new Date(props.date).toLocaleString()}</p>
                <StyledSpan>Tickets left:  </StyledSpan><h5>{props.amountOfTickets}</h5>
                <StyledSpan>address:  </StyledSpan><p> {props.place}</p>

            </AboutArtEvent>
            <ButtonBlock >
                {<props.buttonBlock {...props}/>}

            </ButtonBlock>
        </MainArtEventView>              
    )    
}
export default ArtEventView;

