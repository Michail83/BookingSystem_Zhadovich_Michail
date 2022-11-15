import React from "react";
import BaseArtEventDetails_ReduxWrapped from "../BaseArtEventDetails";
import { DeleteArtEventButton } from "../../Buttons/DeleteArtEventButton";
import EditButton from "../../CreateDifferentArtEvent/EditForm/EditButton";

const AdminArtEventDetails = (props) => { 
    let newProps = {...props, buttons: [DeleteArtEventButton, EditButton]};

    return (
        <BaseArtEventDetails_ReduxWrapped {...newProps }     />
        )
}
export default AdminArtEventDetails;