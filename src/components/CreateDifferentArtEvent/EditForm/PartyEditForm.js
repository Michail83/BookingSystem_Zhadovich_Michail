import React, { useEffect, useState } from "react";
import api_url from "../../../API_URL";
import axios from "axios";
import onSubmitPartyEditFunction from "../OnSubmitFunction/onSubmitPartyEditFunction"
import PartyBaseForm from "../BaseForms/PartyBaseForm";

const PartyEditForm = ({ setStatusOfCreating, id }) => {
    const [values, setValues] = useState();
    useEffect(() => {
        loadParty();
    }, []);

    const loadParty = async () => {

        try {
            let result = await axios.get(api_url.parties(id))
            setValues(result.data);

        } catch (error) {

        }
    }
    const createElement = () => {
        if (values) {

            const options = {};
            options.defaultValues = { ...values };

            options.disabledValues = {
                eventName: true,
                date: true,
                amountOfTickets: false,
                place: true,
                price: false,
                ageLimitation: true,
                image: true
            };
            options.image = { isRequired: false };
            options.onSubmitFunction = onSubmitPartyEditFunction(setStatusOfCreating, values.id);
            options.submitName = "Update";

            return <PartyBaseForm options={options} />
        } else return <div>loading...</div>
    }

    return <>
        {createElement()}
    </>
}

export default PartyEditForm;