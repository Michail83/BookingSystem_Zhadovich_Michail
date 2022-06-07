import React, { useState, useEffect } from "react";
import styled from "styled-components";
import { YandMap } from "../YandMAP/YandMAP";
import loadData from './Functions/LoadData';

const DetailsMain = styled.div`
    margin-top: 13vh;
    display: flex;
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




const ArtEventDetails =({url, ConcreteIventData, DeleteButton})=>{
    const [artEvent, setArtEvent] =  useState();
    
    useEffect(()=>{
        loadData(url,setArtEvent);
        }, []
    );
    if (artEvent) {
        return(
        
            <DetailsMain>
                <ImageBlock>Image will be here...
    
                </ImageBlock>
                
                <DataBlock>
                    <div>{artEvent.eventName} </div>
                    <div>{artEvent.amountOfTickets}</div>
                    <div>{artEvent.date}</div>
                    <div>{artEvent.place}</div>
                    <ConcreteIventData {...artEvent}/>    
                    
                </DataBlock>
                
                <MapBlock>
                    <YandMap artEventItems={[artEvent]}/>    
                </MapBlock>
                {DeleteButton ? <DeleteButton id={artEvent.id}  /> : ""}
            </DetailsMain>
        )            
    } else {
        return(
            <div>Loading...</div>
        )
        
    }
    
}
export default ArtEventDetails;