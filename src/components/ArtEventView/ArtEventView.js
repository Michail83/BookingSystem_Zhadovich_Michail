import React from "react";
import styled from "styled-components";
import ArtEventDataBlock from "./PartOfArtEventView/ArtEventDataBlock";
import ArtEventImageBlock from "./PartOfArtEventView/ArtEventImageBlock";


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
    background-color:white; 
`;

function ArtEventView(props) { 
    return(
        <MainArtEventView >
            <ArtEventImageBlock {...props}/>
            <ArtEventDataBlock {...props}/>            
            <ButtonBlock>
                {<props.buttonBlock {...props}/>}
            </ButtonBlock>

        </MainArtEventView>              
    )    
}
export default ArtEventView;