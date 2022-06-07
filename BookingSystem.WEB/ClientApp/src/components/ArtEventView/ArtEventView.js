import React from "react";
// import { Link, useNavigate } from "react-router-dom"
// import AddButton_ReduxWrapped from "../Cart/cartButton/AddButton"
import "./ArtEventView.css"
// import ChangeValueInCartButton_ReduxWrapped from "../Cart/cartButton/changeValueInCartButton";
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
                <h3>{props.item.iventName}</h3>
                <p>{props.item.typeOfArtEvent}</p>
                <div>{props.item.additionalInfo.map((info, index) => <p key={index} >{info }</p>)}</div>
                <p>{props.item.date}</p>
                <h5>{props.item.amounOfTicket}</h5>
                <p>{props.item.place}</p>

            </AboutArtEvent>
            <ButtonBlock >
                {<props.buttonBlock {...props}/>}

            </ButtonBlock>
        </MainArtEventView>              
    )    
}
export default ArtEventView;


{/* <td key={5}>{props.item.additionalInfo.map((info, index) => <p key={index} >{info }</p>)}</td> */}
