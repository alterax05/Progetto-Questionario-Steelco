import React from 'react';

interface id_video {
    id?: string;
}

const YoutubeVideoEncoder: React.FC<any> = ({id = '-1wcilQ58hI'}) => {
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
