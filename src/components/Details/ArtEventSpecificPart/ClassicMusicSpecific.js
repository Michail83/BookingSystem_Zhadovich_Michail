import React from "react";

const ClassicMusicSpecific = (props) => {
    return (
        <>
            <div>{props.voice}</div>
            <div>{props.concertName}</div>
        </>
    )
}

export default ClassicMusicSpecific;