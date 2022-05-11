import React from "react"; 
import './CreateForm.css';
import urls from "../../API_URL";


class OpenAirCreateForm extends React.Component {
    constructor(props){
        super(props);        
        this.state ={            
            eventName: "",
            date: "",
            amountOfTickets: 0,
            place: "",
            // from props?
            typeOfArtEvent: "OpenAir",
            headLiner: "",
            longitude: "",
            latitude: ""
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
              
        const {eventName, date,amountOfTickets, place, headLiner, longitude,latitude } = this.state;     
        let url2 = urls.openairs();
        
        fetch(url2, {
            method: "post",
            body: JSON.stringify({eventName, date,amountOfTickets, place, headLiner, longitude, latitude }),
            headers: { 'Content-Type': 'application/json; charset=utf-8' }            
        })
            .then(res => res.json())
            .then(
                (result) => {  
                    console.log("Create Success"); 
                    console.log(result); 
                    this.setState({            
                        eventName: "",
                        date: "",
                        amountOfTickets: 0,
                        place: "",                        
                        typeOfArtEvent: "OpenAir",
                        headLiner: "",
                        longitude: "",
                        latitude: ""
                    })                     
                }, 
                (error) => {
                    console.log(error);     
                }
        )
    }

    render(){
        return(           
                <form className="maincreate"  onSubmit={this.handleSubmit} autoComplete="off">
                    <div > 
                        <label>Name
                            <input  
                            required 
                            // autoComplete="off"
                             value={this.state.eventName}         
                             name="eventName"        
                             type="text"     
                             onChange={this.handleChangeName}>                             

                             </input>
                        </label> 
                    </div>
                    <div>
                         <label>Date<input
                        //  autoComplete="off"   
                         required  
                         value={this.state.date}          
                         name="date"             
                         type="datetime-local"     
                         onChange={this.handleChangeName}></input></label> 
                    </div>
                    <div>
                        <label>amount Of Ticket<input 
                        // autoComplete="off" 
                        required  
                        value={this.state.amountOfTickets}  
                        name="amountOfTickets"  
                        type="number"   
                        onChange={this.handleChangeName}></input></label> 
                    </div>
                    <div> 
                        <label>Place
                        <input 
                          
                        required   
                        value={this.state.place}        
                        name="place"            
                        type="text"     
                        onChange={this.handleChangeName}
                        />
                        
                       
                        </label> 
                    </div>
                    <div>
                        <label>HeadLiner
                            <input
                            required   
                            value={this.state.headLiner}        
                            name="headLiner"        
                            type="text"     
                            onChange={this.handleChangeName}
                            />                            
                            </label> 
                    </div>

                    <div>
                        <label>Сoordinates
                            <input 
                            // autoComplete="off"  
                            required      
                            name="latitude"  
                            value={this.state.latitude}   
                            placeholder="latitude"      
                            type="text"     
                            onChange={this.handleChangeName}
                            />
                            
                            <input 
                            // autoComplete="off"  
                            required      
                            name="longitude"  
                            value={this.state.longitude} 
                            placeholder="longitude"      
                            type="text"     
                            onChange={this.handleChangeName}
                            />                            
                        </label> 
                    </div>

                <label><input             type="submit"  value="Create" ></input></label>
            </form>            
        )
    }       
}
export default OpenAirCreateForm;


//change to function 