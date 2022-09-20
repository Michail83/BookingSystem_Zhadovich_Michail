import React from "react";
import styled from "styled-components";
import { NoImageavailable } from "../../CONST/NoImageAvailable";

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
    padding: 1vh 1vw;
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
    padding: 1vh 1vw;
    min-width: 55%;
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
    & *{
        margin: 0.5rem
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
                <h3>{props.eventName}</h3>
                <p>{props.typeOfArtEvent}</p>
                <div>{props.additionalInfo.map((info, index) => <p key={index} >{info }</p>)}</div>
                <p>{new Date(props.date).toLocaleString()}</p>                
                <h5>{props.amountOfTickets}</h5>
                <p>{props.place}</p>

            </AboutArtEvent>
            <ButtonBlock >
                {<props.buttonBlock {...props}/>}

            </ButtonBlock>
        </MainArtEventView>              
    )    
}
export default ArtEventView;

