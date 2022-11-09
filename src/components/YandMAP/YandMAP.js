import React from "react";
import { YMaps, Map, Placemark } from "react-yandex-maps";

export const YandMap = ({ artEventItems }) => {

    const state = {
        center: [53.89364559280405, 27.567232262565565],
        zoom: 10,
        controls: ['zoomControl', 'fullscreenControl'],
    }
    const modules = ['control.ZoomControl', 'control.FullscreenControl', 'geoObject.addon.balloon', 'geoObject.addon.hint']

    const createPlacemark = (artEvents) => {
        return artEvents.map((artEvent) => {

            return <Placemark key={artEvent.id}
                defaultGeometry={[artEvent.latitude, artEvent.longitude]}
                properties={{
                    balloonContentHeader: artEvent.typeOfArtEvent,
                    balloonContentBody: artEvent.eventName,
                    balloonContentFooter: artEvent.date,
                    hintContent: artEvent.eventName,
                }}
                options={{
                    preset: 'islands#redIcon',
                }}
            />
        }
        )
    }

    return (
        <div style={{ width: "320px", height: "320px" }}>
            <YMaps>
                <Map defaultState={state} modules={modules} width={"100%"} height={"100%"}>
                    {createPlacemark(artEventItems)}
                </Map>
            </YMaps>
        </div>
    )
}