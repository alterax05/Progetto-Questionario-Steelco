import {FC} from 'react';
import NavBar from "../components/NavBar";
import Domande from "../components/Domande";
import {useNavigate} from "react-router-dom";

interface DomandeProps {
    isItalian: boolean;
    url_api: string;
}

const DomandePage:FC<DomandeProps> = ({isItalian, url_api}) => {
    const navigate = useNavigate();

    let codiceFiscale:string;

    if (localStorage.getItem("codice_fiscale") === null) {
        alert("Devi prima effettuare il login")
        navigate("/")
        return <></>;
    }
    else
    {
        codiceFiscale = localStorage.getItem("codice_fiscale")!;
    }

    return(
        <>
            <NavBar nomi_italiano={[]} nomi_inglese={[]} links={[]} isItalian={isItalian} setIsItalian={undefined}/>
            <Domande isItalian={isItalian} url={url_api} codiceFiscale={codiceFiscale}/>
        </>
    )
}
export default DomandePage;