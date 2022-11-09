import React, { useState, useEffect } from "react"
import axios from "axios";
import urls from '../../API_URL'
import CreateLinkToExternalProvider from "./CreateLinkToExternalProvider";
import styled from "styled-components";

const DivWrap = styled.div`
    display:flex;
    flex-direction:column;
    width:100%;
    margin-bottom: 1rem;   
`;

function ExternalLoginList(prop) {

    const [externalProviderList, SetExternalProviderList] = useState(null);
    useEffect(() => {
        loadProvider();
    }, []
    );

    const loadProvider = async () => {
        try {
            let url = urls.getExternalProviderName()
            const result = await axios.get(url);
            SetExternalProviderList(result.data);

        } catch (error) {
            console.log(error);
        }
    }

    const showLoading = () => {
        let items;
        const returnUrl = prop.returnUrl ?? urls.basePath() + "/"
        if (externalProviderList) {
            items = externalProviderList.map((provider) => (<CreateLinkToExternalProvider key={provider} providerName={provider} returnUrl={returnUrl} />));
        } else {
            items = <div> Loading...</div>
        }
        return items;
    }
    return (
        <DivWrap>{showLoading()}</DivWrap>
    );
}
export default ExternalLoginList;