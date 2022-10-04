import React from "react";

import BaseArtEventDetails_ReduxWrapped from "../BaseArtEventDetails";

import { DeleteArtEventButton } from "../../Buttons/DeleteArtEventButton";




const AdminArtEventDetails = (props) => {    

    let newProps = {...props, Buttons: DeleteArtEventButton};

    return (

        <BaseArtEventDetails_ReduxWrapped {...newProps }     />
        )
}




export default AdminArtEventDetails;