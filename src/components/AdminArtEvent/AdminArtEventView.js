import React from "react";

import ArtEventView from "../ArtEventView/ArtEventView";
import AdminArtEventButtonBlock from "./AdminArtEventButtonBlock"; 


function AdminArtEventView(props) { 
    
    let newProps ={...props,buttonBlock: AdminArtEventButtonBlock } 

    return (
        <ArtEventView {...newProps}/>
    )
}
export default AdminArtEventView;