import React from "react"; 
import './CreateForm.css'
import urls from "../../API_URL"

class ClassicMusicCreateForm extends React.Component {
    constructor(props){
        super(props);        
        this.state ={            
            eventName: "",
            date:"",
            amountOfTickets: 0,
            place: "",            
            typeOfArtEvent: "ClassicMusic",
            voice: "",
            concertName:"",
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
              
        const {eventName, date,amountOfTickets, place, voice,concertName, longitude,latitude} = this.state;     
        let url2 =  urls.classicmusics();
        
        // console.log(JSON.stringify({eventName, date,amountOfTickets, place, headLiner}));
        
        fetch(url2, {
            method: "post",
            body: JSON.stringify({eventName, date,amountOfTickets, place, voice,concertName, longitude, latitude }),
            headers: { 'Content-Type': 'application/json; charset=utf-8' }            
        })
            .then(res => res.json())
            .then(
                (result) => {  
                    console.log(result);
                    this.setState({            
                        eventName: "",
                        date:"",
                        amountOfTickets: 0,
                        place: "",            
                        typeOfArtEvent: "ClassicMusic",
                        voice: "",
                        concertName:"",
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
                    <div>
                        <label>Name
                             <input 
                             value={this.state.eventName}             
                             name="eventName" 
                             required        
                             type="text"     
                             onChange={this.handleChangeName}>                                 
                             </input>
                        </label> 
                    </div>
                    <div>
                        <label>Date
                            <input 
                            value={this.state.date}              
                            name="date" 
                            required             
                            type="datetime-local"
                            onChange={this.handleChangeName}
                            />                            
                            </label> 
                        </div>
                    <div><label>amount Of Ticket<input value={this.state.amountOfTickets}   name="amountOfTickets" required  type="number"   onChange={this.handleChangeName}></input></label> </div>
                    <div> <label>Place<input value={this.state.place}             name="place" required           type="text"     onChange={this.handleChangeName}></input></label> </div>
                    <div><label>Voice<input value={this.state.voice}              name="voice" required            type="text"     onChange={this.handleChangeName}></input></label> </div>
                    <div><label>Concert Name<input value={this.state.concertName}       name="concertName" required      type="text"     onChange={this.handleChangeName}></input></label> </div>
                    <div>
                        <label>Сoordinates
                        <input 
                            // autoComplete="off"  
                            required      
                            name="latitude"  
                            value={this.state.latitude}   
                            placeholder="latitude"      
                            type="text"     
                            onChange={this.handleChangeName}>
                            </input>
                            <input 
                            // autoComplete="off"  
                            required      
                            name="longitude"  
                            value={this.state.longitude} 
                            placeholder="longitude"      
                            type="text"     
                            onChange={this.handleChangeName}>                                
                            </input>
                            
                        </label> 
                    </div>

                <label><input             type="submit"  value="Create" ></input></label>
            </form>            
        )
    }       
}
export default ClassicMusicCreateForm;