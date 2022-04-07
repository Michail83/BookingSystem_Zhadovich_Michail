import React from "react"
function CreateLinkToExternalProvider(props){
    if (!props.providerName) {
        return (
            <p>External provider not found</p>
        )        
    }
    const returnUrl = props.returnUrl ?"&returnUrl="+props.returnUrl:"";
    const path = "https://localhost:5001/account/externallogin?provider=" + props.providerName+ returnUrl;

return (
    <div className="btn"><a href={path}>{props.providerName}</a></div>
)
}
export default CreateLinkToExternalProvider;



//const returnUrl = "";
///*props.returnUrl ? "&returnUrl=" + props.returnUrl : "";*/
//const path = urls.basePath() + "/account/externallogin?provider=" + props.providerName + returnUrl;

//const modalLink = (event) => {
//    /*console.log(path);*/
//    event.preventDefault();
//    window.open(path, "provider", "width=400,height=400");
//    store.dispatch(actionsCreator.setModalWindowForLoginActive(false))
//}

//return (
//    <div className="btn">
//        <a href="" onClick={(event) => modalLink(event)}>{props.providerName}</a>
//    </div>