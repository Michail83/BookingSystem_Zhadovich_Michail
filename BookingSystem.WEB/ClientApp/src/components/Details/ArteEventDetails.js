import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import styled from "styled-components";
import { YandMap } from "../YandMAP/YandMAP";
import loadData from './Functions/LoadData';

const DetailsMain = styled.div`
    margin-top: 13vh;
    display: flex;
    flex-wrap: wrap;
    box-sizing: border-box;
    padding: 1rem 1rem;
    & div{
        padding: 1px;
    }

`;
const ImageBlock = styled.div`
    width: 20%;
    aspect-ratio: 1/1;
    background-color: aqua;

`;

const MapBlock = styled.div`
    width: auto;    
    /* display: inline-block; */    
`;
const DataBlock = styled.div`
    min-width: 45%;
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
`;
const ButtonBlock = styled.div`
    width: 70vw;
`;

const ArtEventDetails = ({ url, ConcreteIventData, DeleteButton }) => {
    // console.log("ArtEventDetails =>DeleteButton =>  ", deleteButton)
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
                    <div>{artEvent.eventName} </div>
                    <div>{artEvent.amountOfTickets}</div>
                    <div>{artEvent.date}</div>
                    <div>{artEvent.place}</div>
                    <ConcreteIventData {...artEvent} />

                </DataBlock>

                <MapBlock>
                    <YandMap artEventItems={[artEvent]} />
                </MapBlock>
                <ButtonBlock>
                    {DeleteButton ? <DeleteButton id={artEvent.id} /> : ""}
                </ButtonBlock>

            </DetailsMain>
        )
    } else {
        return (
            <div>Loading...</div>
        )
    }
}
// export default ArtEventDetails;

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