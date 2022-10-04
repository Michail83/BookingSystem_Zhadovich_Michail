import React from "react";
import BaseMainTable_ReduxWrapped from "./BaseMainTable";
import HomeArtEventView from '../HomeArtEventView/HomeArtEventView';


const MainTableForArtEvents = () => {
    
    return (
        <BaseMainTable_ReduxWrapped ArtEventType={HomeArtEventView}  />        
    )
}

export default MainTableForArtEvents;
