import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import styled from "styled-components";
import { YandMap } from "../YandMAP/YandMAP";
import loadData from './Functions/LoadData';
// import AddOrChangeValueButton_ReduxWrapped from "../Cart/cartButton/AddOrChangeValueButton";
import { NoImageavailable } from "../../CONST/NoImageAvailable";


const DetailsMain = styled.div`
    margin-top: 7.5rem;
    display: flex;
    flex-wrap: wrap;
    box-sizing: border-box;
    padding: 1vh 1vw;
    border-bottom: 1px solid lightskyblue; 
`;
const ImageBlock = styled.div`
    display:inline-block; 
`;

const MapBlock = styled.div`
    width: auto;    
    /* display: inline-block; */    
`;
const DataBlock = styled.div`
    padding: 1vh 1vw;
    min-width: 45%;
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
    /* margin: 0 auto; */
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



{/* <AddOrChangeValueButton_ReduxWrapped id={artEvent.id} amountOfTickets={artEvent.amountOfTickets} /> */}