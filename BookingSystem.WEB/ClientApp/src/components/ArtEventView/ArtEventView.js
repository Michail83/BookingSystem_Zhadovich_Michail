import React from "react";
// import { Link, useNavigate } from "react-router-dom"
// import AddButton_ReduxWrapped from "../Cart/cartButton/AddButton"
import "./ArtEventView.css"
// import ChangeValueInCartButton_ReduxWrapped from "../Cart/cartButton/changeValueInCartButton";



function ArtEventView(props) {  
    // let navigate = useNavigate();
    
    // const redirect = e => {
    //     e.preventDefault() 
    //     if (!e.target.closest('FORM') ) {
    //         // console.log(e.target.tagName)
    //         navigate(`/details/${props.item.id}`)  
    //     }
    //   }
   
      
    return(
        <div className="MainArtEventView" >
            <div className="ArtEventViewImage">

            </div>
            <div className="AboutArtEvent">
                <h3>{props.item.iventName}</h3>
                <p>{props.item.typeOfArtEvent}</p>
                <p>{props.item.additionalInfo.map((info, index) => <p key={index} >{info }</p>)}</p>
                <p>{props.item.date}</p>
                <h6>{props.item.amounOfTicket}</h6>
                <p>{props.item.place}</p>

            </div>
            <div className="ButtonBlock">
                {<props.buttonBlock {...props}/>}

            </div>
        </div>              
    )    
}
export default ArtEventView;


{/* <td key={5}>{props.item.additionalInfo.map((info, index) => <p key={index} >{info }</p>)}</td> */}
