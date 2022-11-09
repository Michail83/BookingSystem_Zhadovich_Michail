import React from 'react';
import { useParams } from "react-router-dom";
import urls from '../../API_URL';

import ArtEventDetails from '../../components/Details/ArteEventDetails';

 function DetailsPage() {
    let params = useParams();    
    let id = parseInt(params.eventid); 
    let url = new URL(urls.getArtEvents(id));
    return (
        <ArtEventDetails url={url}/>
    )    
}
export default DetailsPage;