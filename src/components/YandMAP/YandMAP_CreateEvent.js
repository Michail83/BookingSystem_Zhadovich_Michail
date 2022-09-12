import React, { useState, useEffect } from "react";
import styled from "styled-components";
import "./YandMAP_CreateEvent.css";

const MapCotainer = styled.div`
    width:500px;
    height:500px;
    margin:3rem auto 0 auto;
    border: 1px solid rgba(47, 36, 216, 0.59);
    box-shadow: 0px 0px 75px 50px rgba(47, 36, 216, 0.59);

`;

const YandMAP_CreateEvent = ({ setPlace, setCoord, setIsMapShow }) => {


    useEffect(() => {
        init();
    },
        []);

    const setCreateFormValue = (coord, place) => {
        setPlace(place);
        setCoord(coord);
    }

    function init() {
        let thisCoord;
        let thisPlace;
        var myPlacemark;
        var myMap = new ymaps.Map('map', {
            center: [53.893645, 27.56723],
            zoom: 11
        }, {
            searchControlProvider: 'yandex#map'
        }),
        ButtonLayout = ymaps.templateLayoutFactory.createClass([
            '<div title="{{ data.title }}" class="my-button ',            
            '<span class="my-button__text" >{{ data.content }}</span>',
            '</div>'
        ].join(''));


        var getAndCloseButton = new ymaps.control.Button({
            data: { content: "Confirm", 
                    title:"Click on the map to get place" },
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
            } else{
                alert("Select place on the map!!!")
            }
        });
        myMap.controls.add(getAndCloseButton);
      
        myMap.events.add('click', function (e) {
            var coords = e.get('coords');
            
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
                    console.log("setThisCoord&setThisPlace");
                    console.log(coords);
                    console.log(firstGeoObject.getAddressLine());


                    thisCoord = coords;
                    thisPlace = firstGeoObject.getAddressLine();
            });
        }
    }



    return (

       
            <MapCotainer id="map" >

            </MapCotainer>
       
    )
}

export default YandMAP_CreateEvent;