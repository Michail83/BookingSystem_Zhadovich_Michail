import React from "react";

import ArtEventView from "../ArtEventView/ArtEventView";
import HomeArtEventButtonBlock from "./HomeArtEventButtonBlock"; 


function HomeArtEventView(props) { 
    
    let newProps ={...props,buttonBlock: HomeArtEventButtonBlock } 

    return (
        <ArtEventView {...newProps}/>
    )
}
export default HomeArtEventView;