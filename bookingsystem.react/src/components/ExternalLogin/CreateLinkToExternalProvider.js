import React from "react"
function CreateLinkToExternalProvider(props){
    if (!props.providerName) {
        return (
            <p>External provider not found</p>
        )        
    }
    const returnUrl = props.returnUrl ?"&returnUrl="+props.returnUrl:"";
    const path = "https://localhost:44324/account/externallogin?provider=" + props.providerName+ returnUrl;

    return (
        <div className="btn" ><a href={path} className="external" >{props.providerName}</a></div>
)
}
export default CreateLinkToExternalProvider;            