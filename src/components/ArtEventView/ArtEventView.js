import React from "react";
import styled from "styled-components";

const ButtonBlock = styled.div`
    display: flex;
    flex-flow: column nowrap;
    align-items: stretch;
    justify-content: center;
    width: 12%;
    flex-grow: 5;
`;
const MainArtEventView = styled.div`
    border-bottom: 1px solid blue;
    padding: 1vh 1vw;
    display: flex;
    flex-direction: row;
    flex: 0 1 100%;
    align-items: stretch;
    background-color:azure  ;
`;
const ArtEventViewImage = styled.div`
    width: 18%;
    flex-grow: 8;
    background-color: bisque;
`;
const AboutArtEvent = styled.div`
    padding: 1vh 1vw;
    width: 30%;
    flex-grow: 40;
`;


function ArtEventView(props) {    
    return(
        <MainArtEventView >
            <ArtEventViewImage>

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

