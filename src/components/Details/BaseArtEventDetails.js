import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import styled from "styled-components";
import { YandMap } from "../YandMAP/YandMAP";
import loadData from './Functions/LoadData';
import { NoImageavailable } from "../../CONST/NoImageAvailable";


const DetailsMain = styled.div`
    /* margin-top: 9.5rem; */
    display: flex;
    flex-wrap: wrap;
    box-sizing: border-box;
    padding: 0.5rem;
    border-bottom: 1px solid lightskyblue; 
`;
const ImageBlock = styled.div`
    display:inline-block; 
    border: 1px solid whitesmoke;
    border-radius: 1px;
`;

const MapBlock = styled.div`
    width: auto;    
    border: 1px solid whitesmoke;
    border-radius: 1px;  
`;
const DataBlock = styled.div`
    padding: 0.5rem;
    width:auto;
    min-width:450px;
    border: 1px solid whitesmoke;
    border-radius: 1px;
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
    &p{
        margin: 0.5rem
    }
`;

const ButtonBlock = styled.div`
    box-sizing: border-box;
    border: 0;    
    width: 100%;
    padding:0;
    display:flex;
    flex-direction: row;
    justify-content: center;    
`;
const IMAGE = styled.img`
    object-fit: cover;

`;

const BaseArtEventDetails = ({ url, ConcreteIventData, Buttons }) => {    
    const [artEvent, setArtEvent] = useState();

    useEffect(() => {
        loadData(url, setArtEvent);
    }, []
    );
    if (artEvent) {
        return (

            <DetailsMain>
                <ImageBlock>
                <IMAGE src={artEvent.image? `data:image/jpeg;base64,${artEvent.image}`:NoImageavailable} width={"320px"} alt={NoImageavailable} title="image"/>
                </ImageBlock>               

                <DataBlock>
                    <h3>{artEvent.eventName} </h3>
                    <h5>{artEvent.amountOfTickets}</h5>
                    <p>{new Date(artEvent.date).toLocaleString()}</p>
                    <p>{artEvent.place}</p>
                    <ConcreteIventData {...artEvent} />

                </DataBlock>   

                <MapBlock>
                    <YandMap artEventItems={[artEvent]} />
                </MapBlock>                   
                
                <ButtonBlock>

                    <Buttons {...artEvent}/>
                    
                </ButtonBlock>
                

            </DetailsMain>
        )
    } else {
        return (
            <div>Loading...</div>
        )
    }
}


const mapStateToProps = state => ({
    DeleteButton: state.admins.DeleteArtEventButton,    
});


const BaseArtEventDetails_ReduxWrapped = connect(mapStateToProps, null)(BaseArtEventDetails);

export default BaseArtEventDetails_ReduxWrapped;