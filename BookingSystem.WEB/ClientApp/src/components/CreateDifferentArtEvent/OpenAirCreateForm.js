import React from "react"; 
import './OpenAirCreateForm.css'


class OpenAirCreateForm extends React.Component {
    constructor(props){
        super(props);        
        this.state ={            
            eventName: "",
            date: Date.now(),
            amountOfTickets: 0,
            place: "",
            // from props?
            typeOfArtEvent: "OpenAir",
            headLiner: ""
        };
        this.handleChangeName = this.handleChangeName.bind(this);
        this.handleSubmit =          this.handleSubmit.bind(this);
    
    }

    handleChangeName(event){
        const name = event.target.name;
        const eventValue = event.target.value;
        this.setState({[name]: eventValue});
        
    }

    handleSubmit(event){        
        event.preventDefault();
              
        const {eventName, date,amountOfTickets, place, headLiner} = this.state;     
        let url2 = 'https://localhost:44324/openair';
        
        // console.log(JSON.stringify({eventName, date,amountOfTickets, place, headLiner}));
        
        fetch(url2, {
            method: "post",
            body: JSON.stringify({eventName, date,amountOfTickets, place, headLiner}),
            headers: { 'Content-Type': 'application/json; charset=utf-8' }            
        })
            .then(res => res.json())
            .then(
                (result) => {  
                    console.log(result);                      
                }, 
                (error) => {
                    console.log(error);     
                }
        )
    }

    render(){
        return(           
                <form  onSubmit={this.handleSubmit}>
                    <div > <label>Name<input             name="eventName"        type="text"     onChange={this.handleChangeName}></input></label> </div>
                    <div> <label>Date<input              name="date"             type="date"     onChange={this.handleChangeName}></input></label> </div>
                    <div><label>amount Of Ticket<input   name="amountOfTickets"  type="number"   onChange={this.handleChangeName}></input></label> </div>
                    <div> <label>Place<input             name="place"            type="text"     onChange={this.handleChangeName}></input></label> </div>
                    <div><label>HeadLiner<input          name="headLiner"        type="text"     onChange={this.handleChangeName}></input></label> </div>

                <label><input             type="submit"  value="Create" ></input></label>
            </form>            
        )
    }       
}
export default OpenAirCreateForm;


//change to function 