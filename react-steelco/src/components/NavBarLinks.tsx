import React from "react";

const Link:React.FC<{testo: string, link: string, id:string}> = ({testo, link,id}) => {
    return <><li className="nav-item" id={id}><a className="nav-link active" href={link}>{testo}</a></li></>

}
export default Link;