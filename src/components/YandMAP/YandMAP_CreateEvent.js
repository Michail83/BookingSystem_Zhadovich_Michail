import React, { useState, useEffect, Fragment } from "react";
import styled from "styled-components";
import "./YandMAP_CreateEvent.css";

const MapCotainer = styled.div`
    width:500px;
    height:500px;
    margin:3rem auto 0 auto;
    border: 1px solid rgba(47, 36, 216, 0.59);
    box-shadow:  0px 0px 11px 3px rgba(34, 60, 80, 0.25);

`;

const YandMAP_CreateEvent = ({ setPlace, setCoord, setIsMapShow }) => {


    const [coordState, setCoordState] = useState([]); /////
    useEffect(() => {
        // const head = document.querySelector("head");
        // const script = document.createElement('script');
        // script.src="https://api-maps.yandex.ru/2.1/?lang=ru_RU&apikey=913cb368-b557-4cb7-9840-91e7dfa600b2";
        // script.type="text/javascript";
        // script.async=true;
        // script.onload = ()=> ymaps.ready(init);
        // head.appendChild(script);
        
        // return () => {
        //     head.removeChild(script);
        //   }
        window.ymaps.ready(()=>init(window.ymaps));
    },
        []);


    function init(ymaps) {   
        let thisCoord;
        let thisPlace;
        var myPlacemark;
        var myMap = new ymaps.Map('map', {
            center: [53.893645, 27.56723],
            zoom: 11
        }, {
            searchControlProvider: 'yandex#map'
        })
        var searchControl = new ymaps.control.SearchControl({
            options: {
                provider: 'yandex#map',
                noPlacemark: true,
                noSuggestPanel: false,
            },
            state: { noSuggestPanel: false }
        });

        var ButtonLayout = ymaps.templateLayoutFactory.createClass([
            '<div title="{{ data.title }}" class="my-button ',
            '<span class="my-button__text" >{{ data.content }}</span>',
            '</div>'
        ].join(''));

        var getAndCloseButton = new ymaps.control.Button({
            data: {
                content: "Confirm",
                title: "Click on the map to get place"
            },
            options: {
                selectOnClick: false,
                layout: ButtonLayout
            },
        })
        getAndCloseButton.events.add('click', () => {
            if (thisCoord && thisPlace) {
                setPlace(thisPlace);
                setCoord(thisCoord);
                setIsMapShow(false);
            } else {
                alert("Select place on the map!!!")
            }
        });

        myMap.controls.add(getAndCloseButton);

        myMap.controls.remove("searchControl");
        myMap.controls.add(searchControl);

        myMap.events.add('click', function (e) {
            var coords = e.get('coords');            
            setCoordState(coords);       
            if (myPlacemark) {
                myPlacemark.geometry.setCoordinates(coords);
            }

            else {
                myPlacemark = createPlacemark(coords);
                myMap.geoObjects.add(myPlacemark);

                myPlacemark.events.add('dragend', function () {
                    getAddress(myPlacemark.geometry.getCoordinates());
                });
            }
            getAddress(coords);
        });

        function createPlacemark(coords) {
            return new ymaps.Placemark(coords, {
                iconCaption: 'поиск...'
            }, {
                preset: 'islands#violetDotIconWithCaption',
                draggable: true
            });
        }

        function getAddress(coords) {
            myPlacemark.properties.set('iconCaption', 'поиск...');
            ymaps.geocode(coords).then(function (res) {
                var firstGeoObject = res.geoObjects.get(0);
                myPlacemark.properties
                    .set({
                        iconCaption: [

                            firstGeoObject.getLocalities().length ? firstGeoObject.getLocalities() : firstGeoObject.getAdministrativeAreas(),

                            firstGeoObject.getThoroughfare() || firstGeoObject.getPremise()
                        ].filter(Boolean).join(', '),

                        balloonContent: firstGeoObject.getAddressLine()
                    });

                thisCoord = coords.map((item) => Number.parseFloat(item));
                thisPlace = firstGeoObject.getAddressLine();
            });
        }
    }

    return (

        <Fragment>
            <MapCotainer id="map" >
            </MapCotainer>
        </Fragment>
    )
}

export default YandMAP_CreateEvent;