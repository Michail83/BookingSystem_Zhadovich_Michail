import { Link, useNavigate } from "react-router-dom"
import AddButton_ReduxWrapped from "../Cart/cartButton/AddButton"
import "./RowInMainTable.css"
import ChangeValueInCartButton_ReduxWrapped from "../Cart/cartButton/changeValueInCartButton";


function RowInMainTable(props) {  
    let navigate = useNavigate();
    
    const redirect = e => {
        e.preventDefault() 
        if (!e.target.closest('FORM') ) {
            // console.log(e.target.tagName)
            navigate(`/details/${props.item.id}`)  
        }
      }

    function setButton(){
        // let button;
        switch (props.buttonType) {

            case "addbutton":                
                return <AddButton_ReduxWrapped id={props.item.id}/>

            case "changebutton":                
                return <ChangeValueInCartButton_ReduxWrapped id={props.item.id} maxValue={props.item.amounOfTicket}/>
            case "noButton" :
                return <p></p>
        
            default:
                return "error setButton RowInMainTable";
        }

        // if (!(props.additionalButton==undefined)) {
        //     return <td key={7}><ChangeValueInCartButton_ReduxWrapped id={props.item.id}/> </td>;
        // }
        // return <td > here will be nothing</td>;       
    }
    let button =  setButton();    
    return(        
        <tr onDoubleClick={redirect}>               
                <td key={0}>{props.item.iventName}</td>
                <td key={1}>{props.item.amounOfTicket}</td>
                <td key={2}>{props.item.date}</td>
                <td key={3}>{props.item.place}</td>
                <td key={4}>{props.item.typeOfArtEvent}</td>
                <td key={5}>{props.item.additionalInfo.map((info, index) => <p key={index} >{info }</p>)}</td>
                <td key={6}>{button}</td>
        </tr>        
    )    
}
export default RowInMainTable;