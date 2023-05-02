import {FC} from 'react';
import NavBar from "../components/NavBar";
import Domande from "../components/Domande";

interface DomandeProps {
    isItalian: boolean;
    url_api: string;
    codiceFiscale: string;
    passato: boolean;
    setPassato: (passato:boolean)=>void;
}

const DomandePage:FC<DomandeProps> = ({isItalian, url_api, codiceFiscale, passato, setPassato}) => {
    return(
        <>
            <NavBar nomi_italiano={[]} nomi_inglese={[]} links={[]} isItalian={isItalian} setIsItalian={undefined}/>
            <Domande isItalian={isItalian} url={url_api} codiceFiscale={codiceFiscale} passato={passato} setPassato={setPassato}/>
        </>
    )
}
export default DomandePage;