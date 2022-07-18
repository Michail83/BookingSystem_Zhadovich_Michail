import React from "react";
import {deleteArtEvent} from "./Functions/deleteArtEvent.js";
import { useNavigate } from "react-router-dom";

export const DeleteArtEventButton =({id})=>{

    const navigate = useNavigate();
    const deleteAndNavigate=(id)=>{
        if (deleteArtEvent(id)) {
            navigate('/')
        }
    }
    return  <button onClick={()=>deleteAndNavigate(id)} value={"DELETE"}>del</button>
}