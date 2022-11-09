import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import styled from "styled-components";
import { YandMap } from "../YandMAP/YandMAP";
import loadData from './Functions/LoadData';

import ArtEventDataBlock from "../ArtEventView/PartOfArtEventView/ArtEventDataBlock";
import ArtEventImageBlock from "../ArtEventView/PartOfArtEventView/ArtEventImageBlock";

const DetailsMain = styled.div`    
    display: flex;
    flex-wrap: wrap;
    box-sizing: border-box;
    padding: 0.5rem;
    border-bottom: 1px solid lightskyblue; 
`;

const MapBlock = styled.div`
    width: auto; 
    border-radius: 1px;  
`;

const ButtonBlock = styled.div`
    box-sizing: border-box;
    border: 1px solid whitesmoke;    
    width: 100%;
    padding:0;
    display:flex;
    flex-direction: row;
    justify-content: center;    
`;

const BaseArtEventDetails = ({ url, ConcreteIventData, buttons }) => {    
    const [artEvent, setArtEvent] = useState();

    useEffect(() => {
        loadData(url, setArtEvent);
    }, []);

    if (artEvent) {        
        return (
            <DetailsMain>
                <ArtEventImageBlock {...artEvent}/> 
                <ArtEventDataBlock {...artEvent} currentMinWidth={"450px"}/>                 

                <MapBlock>
                    <YandMap artEventItems={[artEvent]} />
                </MapBlock>                   
                
                <ButtonBlock>
                    {buttons.map((Button, index)=><Button key={index} {...artEvent} />)}                                     
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