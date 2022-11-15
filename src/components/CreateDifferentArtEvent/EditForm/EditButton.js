import React from "react";
import { BlueButton } from "../../StyledComponent/Button/BlueButton";
import { useNavigate} from "react-router-dom";

const  EditButton = ({id})=>{
    const navigate= useNavigate();
    return <BlueButton onClick={()=>navigate(`/edit/${id}`)}>Edit</BlueButton>
}
export default EditButton;