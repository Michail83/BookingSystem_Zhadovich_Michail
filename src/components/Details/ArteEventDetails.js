import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import styled from "styled-components";
import { YandMap } from "../YandMAP/YandMAP";
import loadData from './Functions/LoadData';
import AddOrChangeValueButton_ReduxWrapped from "../Cart/cartButton/AddOrChangeValueButton";

const DetailsMain = styled.div`
    margin-top: 14vh;
    display: flex;
    flex-wrap: wrap;
    box-sizing: border-box;
    padding: 1vh 1vw;
    border-bottom: 1px solid lightskyblue; 
`;
const ImageBlock = styled.div`
    width: 18%;
    aspect-ratio: 1/1;
    background-color: aqua;
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

const ArtEventDetails = ({ url, ConcreteIventData, DeleteButton }) => {    
    const [artEvent, setArtEvent] = useState();

    useEffect(() => {
        loadData(url, setArtEvent);
    }, []
    );
    if (artEvent) {
        return (

            <DetailsMain>
                <ImageBlock>Image will be here...

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
                    {DeleteButton ? <DeleteButton id={artEvent.id} /> : ""}
                    <AddOrChangeValueButton_ReduxWrapped id={artEvent.id} amountOfTickets={artEvent.amountOfTickets} />
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
    // isActive: state.state.iSmodalLoginWindowActive
});

const mapDispatchToProps = dispatch => (
    {
        // setArtEventItems:(artItems)=> dispatch(actionCreator.SetArtEventItems(artItems))        
    });

const ArtEventDetails_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(ArtEventDetails);

export default ArtEventDetails_ReduxWrapped;