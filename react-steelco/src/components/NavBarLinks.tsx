import React from "react";

const Link:React.FC<{testo: string, link: string}> = ({testo, link}) => {
    return <><li className="nav-item"><a className="nav-link active" href={link}>{testo}</a></li></>

}
export default Link;