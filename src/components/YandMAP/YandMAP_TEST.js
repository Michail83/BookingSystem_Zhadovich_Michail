import React, { useState, useEffect } from "react";
import { YMaps, Map, Placemark, SearchControl, GeoObject } from "react-yandex-maps";
import { connect } from "react-redux";


export const YandMAP_TEST = ({ artEventItems }) => {

    const [coord, SetCoord] = useState("");
    const [placeMark, setPlaceMark] = useState("");
    const [ymapsMY, setYmapsMY] = useState();



    // useEffect(() => {
    //     if (coord) {
    //         console.log("Change???");
    //         setPlaceMark("");
    //         setPlaceMark(<Placemark defaultGeometry={coord} />)
    //     }
    // }, [coord]);



    const OnMapClick = (e) => {
        const coordinates = e.get("coords");
        console.log(ymapsMY);

        let placemark = new ymapsMY.Placemark(coord, {}, {
            preset: 'islands#violetDotIconWithCaption',
            draggable: true
        })
        console.log(placemark); 
        console.log(ymapsMY.geoObject); 

        ymapsMY.geoObject.add(placemark);
        
        SetCoord(coordinates);

       
    }

    const state = {
        center: [53.89364559280405, 27.567232262565565],
        zoom: 9,
        controls: ['zoomControl', 'fullscreenControl'],

    }
    const modules = ['control.ZoomControl', 'control.FullscreenControl', 'geoObject.addon.balloon', 'geoObject.addon.hint', 'geocode', 'Placemark', 'GeoObject']

    // const createPlacemark = (artEvents) => {
    //     return artEvents.map((artEvent) => {

    //         return <Placemark key={artEvent.id}
    //             defaultGeometry={[artEvent.latitude, artEvent.longitude]}
    //             properties={{
    //                 balloonContentHeader: artEvent.typeOfArtEvent,
    //                 balloonContentBody: artEvent.eventName,
    //                 balloonContentFooter: artEvent.date,
    //                 hintContent: artEvent.eventName,
    //             }}
    //             options={{
    //                 preset: 'islands#redIcon',
    //             }}
    //         />
    //     }
    //     )
    // }

    return (
        <div >
            <YMaps
                query={{
                    ns: "MyYandexMap",
                    apikey: "913cb368-b557-4cb7-9840-91e7dfa600b2",
                    lang: "en_RU"
                }}
            >
                <Map
                    defaultState={state}
                    modules={modules}
                    onClick={OnMapClick}
                    onLoad={(ymaps) => { setYmapsMY(ymaps); }}
                >
                    {/* {createPlacemark(artEventItems)} */}
                    {/* {placeMark} */}
                    <SearchControl options={{
                        noPlacemark: true,
                        placeholderContent: "Test PlaceHolder",
                        size: "large",
                        provider: 'yandex#map',
                        noSuggestPanel: false,
                    }} />
                </Map>
            </YMaps>
            {coord && <span>{coord}</span>}
            <div>{ymapsMY?"Loaded": "Loading..........."} </div>
            <button onClick={() => setPlaceMark("")} >reset PlaceMark</button>
        </div>
    )
}

// const mapStateToProps = state => ({
//     artEventItems: state.state.artEventItems,
//     // isActive: state.state.iSmodalLoginWindowActive
// });

// const mapDispatchToProps = dispatch => (
//     {
//         // setArtEventItems:(artItems)=> dispatch(actionCreator.SetArtEventItems(artItems))
//     });

// var YandMap_ReduxWrapped = connect(mapStateToProps, mapDispatchToProps)(YandMap);

// export default YandMap_ReduxWrapped;