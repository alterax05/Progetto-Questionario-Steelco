import React from "react";
import {useNavigate} from "react-router-dom";
const Link:React.FC<{testo: string, link: string, id:string}> = ({testo, link,id}) => {
    const navigate = useNavigate();
    return <><li className="nav-item" id={id}><a className="nav-link active" onClick={()=>{navigate(link)}}>{testo}</a></li></>

}
export default Link;