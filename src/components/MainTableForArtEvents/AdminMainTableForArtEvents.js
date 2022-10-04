import React from "react";
import BaseMainTable_ReduxWrapped from "./BaseMainTable";
import AdminArtEventView from '../AdminArtEvent/AdminArtEventView';


const AdminMainTableForArtEvents = () => {
    
    return (
        <BaseMainTable_ReduxWrapped ArtEventType={AdminArtEventView}  />        
    )
}

export default AdminMainTableForArtEvents;
