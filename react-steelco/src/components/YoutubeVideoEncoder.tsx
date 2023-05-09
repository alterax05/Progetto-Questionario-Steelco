import React from 'react';
import {useNavigate} from "react-router-dom";

const YoutubeVideoEncoder: React.FC<{id?: string}> = ({id = "-1wcilQ58hI"}) => {
    const navigate = useNavigate();
    if (localStorage.getItem("codice_fiscale") === null) {
        alert("Devi prima effettuare il login")
        window.location.href = "/";
        return <></>;
    }
    return (
        <>
            <div
                className="d-flex justify-content-center align-items-center align-content-center align-self-baseline justify-content-sm-center">
                <iframe className="d-sm-flex justify-content-sm-center align-items-sm-center"
                        allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share;autoplay"
                        title="Test sicurezza"
                        src={`https://www.youtube.com/embed/${id}?autoplay=1`}
                        allowFullScreen
                        frameBorder="0"
                        width="560"
                        height="315"
                >
                </iframe>
            </div>
        </>
    );
};

export default YoutubeVideoEncoder;
