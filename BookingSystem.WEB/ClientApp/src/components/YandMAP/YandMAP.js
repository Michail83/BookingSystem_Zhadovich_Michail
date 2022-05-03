import React, { useState, useEffect } from "react";
import { YMaps, Map, Placemark } from "react-yandex-maps";
import { connect } from "react-redux";


const YandMap = ({artEventItems})=>{

    const state = { 
        center: [53.89364559280405,27.567232262565565], 
        zoom: 9,
        controls: ['zoomControl', 'fullscreenControl'],
        }
    const modules = ['control.ZoomControl', 'control.FullscreenControl', 'geoObject.addon.balloon', 'geoObject.addon.hint']
    
    const createPlacemark = (artEvents)=> {

        
      return  artEvents.map((artEvent)=>{
        return <Placemark key={artEvent.id}
        defaultGeometry={[artEvent.latitude,artEvent.longitude]}
        properties= {{
            balloonContentHeader: artEvent.typeOfArtEvent,
            balloonContentBody: artEvent.iventName,
            balloonContentFooter:   artEvent.date,
            hintContent:  artEvent.iventName,
        }}
        options ={{
            preset : 'islands#redIcon',            
        }} />

    }
    );

    // return (
    //     <Placemark key={artEventItems[0].id}
    //     defaultGeometry={[53.89364559280405,27.567232262565565]}
    //     properties= {{
    //         balloonContentHeader: artEventItems[0].typeOfArtEvent,
    //         balloonContentBody: artEventItems[0].iventName,
    //         balloonContentFooter: artEventItems[0].place ,
    //         hintContent:  artEventItems[0].iventName,
    //     }}
    //     options ={{
    //         preset : 'islands#redIcon',            
    //     }} />
    // )
}
    
    return(
        <div>
             <YMaps>                                   
                    <Map defaultState={state} modules={modules}>
                    {createPlacemark(artEventItems)}
                    </Map>                
            </YMaps>
        </div>
    )
}

const mapStateToProps = state => ({
    artEventItems: state.state.artEventItems,    
    // isActive: state.state.iSmodalLoginWindowActive
});

const mapDispatchToProps = dispatch => (
    {
        // setArtEventItems:(artItems)=> dispatch(actionCreator.SetArtEventItems(artItems))        
    });

var YandMap_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(YandMap);

export default YandMap_ReduxWrapped;