import React, {useEffect, useState} from "react";
import RowInMainTable from '../RowInMainTable/RowInMainTable';
import './MainTableForArtEvents.css';
import urls from  '../../API_URL'
import axios from "axios";
import { connect } from "react-redux";
import actionCreator from "../../Store/ActionsCreators/actionCreator.js"



// for debug

// import works from "../../works";
// import { useEffect } from 'react';
// import API_URL from "../../API_URL";

const MainTableForArtEvents = ({artEventItems, setArtEventItems })=>{
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(undefined);

    const loadArtEvents = async ()=>{
        try {
            let result = await axios.get(urls.getArtEvents());
            setArtEventItems(result.data);
            setLoading(false);            
        } catch (err) {
            console.log("error in MainTableForArtEvents => loadArtEvents  " + err);
            setArtEventItems([]);
            setLoading(false);
            setError(err);        
        }
    }

    useEffect(()=>{
        loadArtEvents();

    },[]);
    

    const createComponent = ()=>{
        if (loading) {
            return <div>Loading...</div>            
        } else{
            if (error!=undefined) {
                return <div>ERROR =  {error} </div> 
            }
        }
        let itemsInTable = artEventItems.map((item) => (<RowInMainTable key={item.id} item={item} buttonType={"addbutton"}/> ));

        return (
            <div className="main-div">
                <table style={{border: "1px solid black", borderCollapse: "collapse", width:"100%"}} className="main-table" id="main-table">
                    <colgroup>
                        <col width="20%"></col>
                        <col width="10%"></col>
                        <col width="15%"></col>
                        <col width="17%"></col>
                        <col width="17%"></col>
                        <col width="21%"></col>                
                    </colgroup>            
                <tbody>                
                    {itemsInTable }
                </tbody>
                </table>        
            </div>
            )
        }



    return (        
        createComponent()
    )
}


// class MainTableForArtEvents111 extends React.Component {
//     constructor(props) {
//         super(props);
//         this.state = {
//             error: null,
//             isLoaded: false,
//             // false,           
//             items: null
//         };
//     }
//     componentDidMount() {
//         let url2 = urls.artEvents();
        
//         fetch(url2)
//             .then(res => res.json())
//             .then(
//                 (result) => {                    
//                     this.setState({
//                         isLoaded: true,
//                         items: result
//                     });
//                     console.log(result);
//                 }, 
//                 (error) => {
//                     this.setState({
//                         isLoaded: true,
//                         error
//                     });
//                 }
//         )        

//         // console.log(this.state.items);        
//     }
    
//     render() {
//         const { error, isLoaded, items } = this.state;        
//         if (error) {
//             return <div>Ошибка: {error.message}</div>;
//         } else if (!isLoaded) {
//             return <div>Загрузка...</div>;
//         } else {
//             // console.log("before return", items);
//             let itemsInTable = items.map((item) => (<RowInMainTable key={item.id} item={item} buttonType={"addbutton"}/>               
//                 ));
//             return (<div className="main-div">
//                 <table style={
//                     {border: "1px solid black", borderCollapse: "collapse", width:"100%"}} className="main-table" id="main-table">
//                     <colgroup>
//                         <col width="20%"></col>
//                         <col width="10%"></col>
//                         <col width="15%"></col>
//                         <col width="17%"></col>
//                         <col width="17%"></col>
//                         <col width="21%"></col>
//                     </colgroup>
//                     <tbody>
//                         {/* {console.log("inside tbody", items) } */}
//                         {itemsInTable }
//                     </tbody>
//                 </table>
//             </div>);
//         }
//     }
// }
// const testData= [
//     {
//         "id": 15,
//         "iventName": "OpenAir",
//         "amounOfTicket": 101,
//         "date": "2012-12-12T00:00:00",
//         "place": "unknown1",
//         "typeOfArtEvent": "OpenAir",
//         "additionalInfo": [
//             "bi-3"
//         ]
//     },
//     {
//         "id": 16,
//         "iventName": "VeryOpenAir",
//         "amounOfTicket": 20,
//         "date": "2022-12-12T00:00:00",
//         "place": "known2",
//         "typeOfArtEvent": "OpenAir",
//         "additionalInfo": [
//             "meettaall"
//         ]
//     },
//     {
//         "id": 17,
//         "iventName": "VeryAgeLimitation",
//         "amounOfTicket": 22,
//         "date": "2022-12-01T00:00:00",
//         "place": "known2222",
//         "typeOfArtEvent": "Party",
//         "additionalInfo": [
//             "15"
//         ]
//     },
//     {
//         "id": 18,
//         "iventName": "Veryssssssssss",
//         "amounOfTicket": 2200,
//         "date": "2023-12-01T00:00:00",
//         "place": "known11111111111111111111111111",
//         "typeOfArtEvent": "Party",
//         "additionalInfo": [
//             "0"
//         ]
//     },
//     {
//         "id": 19,
//         "iventName": "VeryclassicMusic",
//         "amounOfTicket": 500,
//         "date": "2022-11-12T00:00:00",
//         "place": "known2",
//         "typeOfArtEvent": "ClassicMusic",
//         "additionalInfo": [
//             "TheBest",
//             "best"
//         ]
//     }
// ]



const mapStateToProps = state => ({
    artEventItems: state.state.artEventItems,    
    // isActive: state.state.iSmodalLoginWindowActive
});

const mapDispatchToProps = dispatch => (
    {
        setArtEventItems:(artItems)=> dispatch(actionCreator.SetArtEventItems(artItems))        
    });

var MainTableForArtEvents_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(MainTableForArtEvents);

export default MainTableForArtEvents_ReduxWrapped;

