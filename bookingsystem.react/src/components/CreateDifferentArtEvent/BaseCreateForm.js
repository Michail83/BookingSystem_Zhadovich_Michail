import React from "react"; 

class BaseCreateForm extends React.Component (props) {
    constructor(props){
        super(props);
        this.handleChangeName = this.handleChangeName.bind(this)
        this.state ={
            eventName="",
            date = Date.now(),
            amountOfTickets=0,
            place="",
            // from props?
            typeOfArtEvent="OpenAir"
        };    
    }

    handleChangeName(event){
        const name = event.target.name;
        const eventValue = event.target.value;
        this.setState({[name]: value});
    }
    render(){
        return(
            <form>
                <label>Name<input               name="eventName"        type="text"     onChange={handleChangeName}></input></label>
                <label>Date<input               name="date"             type="date"     onChange={handleChangeName}></input></label>
                <label>amount Of Ticket<input   name="amountOfTickets"  type="number"   onChange={handleChangeName}></input></label>
                <label>Place<input              name="place"            type="text"     onChange={handleChangeName}></input></label>
                
                
                {/* place to add headliner */}

            </form>
        )
    }
    
        
       
}
export default BaseCreateForm;