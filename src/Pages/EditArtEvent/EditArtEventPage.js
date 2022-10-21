import React, { useState, useEffect } from 'react';
import { useParams } from "react-router-dom";
import urls from '../../API_URL';
import axios from "axios";

import OpenAirEditForm from "../../components/CreateDifferentArtEvent/EditForm/OpenAirEditForm";
import ClassicMusicEditForm from '../../components/CreateDifferentArtEvent/EditForm/ClassicMusicEditForm';
import PartyEditForm from '../../components/CreateDifferentArtEvent/EditForm/PartyEditForm';

import WrapWithSuccessHandlerForEdit from '../../components/CreateDifferentArtEvent/EditForm/WrapWithSuccessHandlerForEdit';
import { MainBlock } from '../StyledComponent/MainBlock';

const EditArtEventPage = () => {

    const [artEvent, setArtEvent] = useState();
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState();


    let params = useParams();
    let id = parseInt(params.eventid);
    let url = new URL(urls.getArtEvents(id));

    useEffect(() => {
        setElement(url);

    }, []);
    const setForm = (artEvent) => {

        switch (artEvent.typeOfArtEvent) {
            case "ClassicMusic":
                setArtEvent(<WrapWithSuccessHandlerForEdit Form={ClassicMusicEditForm} id={artEvent.id} />)
                setLoading(false);
                break
            case "Party":
                setArtEvent(<WrapWithSuccessHandlerForEdit Form={PartyEditForm} id={artEvent.id} />)
                setLoading(false);
                break
            case "OpenAir":
                setArtEvent(<WrapWithSuccessHandlerForEdit Form={OpenAirEditForm} id={artEvent.id} />)
                setLoading(false);
                break
            default:
                setLoading(false);
                setError(true);
        }
    }

    const setElement = async (url) => {
        try {
            let result = await axios.get(url);
            setForm(result.data);

        } catch (error) {
            setError(true)
        }
    }

    const createElement = () => {
        if (loading) {
            return <div>Loading...</div>
        } else if (error) {
            return <div>Error</div>
        }
        return <MainBlock>
            {artEvent}
        </MainBlock>
    }

    return (
        <>
            {createElement()}
        </>
    )
}
export default EditArtEventPage;