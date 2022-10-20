import React from "react";

import BaseArtEventDetails_ReduxWrapped from "./BaseArtEventDetails";
import AddOrChangeValueButton_ReduxWrapped from "../Cart/cartButton/AddOrChangeValueButton";







const ArtEventDetails = (props) => {  


    let newProps = {...props, buttons:[AddOrChangeValueButton_ReduxWrapped] } ;

    return (

        <BaseArtEventDetails_ReduxWrapped {...newProps }/>
        )
}




export default ArtEventDetails;