import React, {useState, FC} from 'react';
import Login from "../components/Login";
import NavBar from "../components/NavBar";

interface LoginInizialeProps {
    setCodiceFiscale: (codice_fiscale: string) => void;
    codiceFiscale: string;
    url: string;
    isItalian: boolean;
    setIsItalian: (isItalian: boolean) => void;
}

const LoginIniziale:FC<LoginInizialeProps> = ({setCodiceFiscale, url, codiceFiscale,isItalian,setIsItalian}) => {

    return(
        <>
            <NavBar nomi_italiano={[]} nomi_inglese={[]} links={[]} isItalian={isItalian} setIsItalian={setIsItalian}/>
            <Login url={url} setCodiceFiscale={setCodiceFiscale} codiceFiscale={codiceFiscale} isItalian={isItalian} />
        </>
    )
}
export default LoginIniziale;