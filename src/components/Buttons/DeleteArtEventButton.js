import React from "react";
import {deleteArtEventAsync} from "../Details/Functions/deleteArtEvent.js";
import { useNavigate } from "react-router-dom";
import { RedButton } from "../StyledComponent/Button/RedButton.js";

export const DeleteArtEventButton = ({id})=>{

    const navigate = useNavigate();
    const deleteAndNavigate= async (id)=>{        
        
        if (await deleteArtEventAsync(id)) {            
            navigate('/')
        }
    }
    return  <RedButton onClick={()=>deleteAndNavigate(id)}>DELETE EVENT</RedButton>
}