import React from "react";
import {deleteArtEvent} from "./Functions/deleteArtEvent";

export const DeleteArtEventButton =({id})=>{

    return  <button onClick={()=>deleteArtEvent(id)} value={"DELETE"}>del</button>
}