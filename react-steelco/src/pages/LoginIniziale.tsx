import {FC} from 'react';
import Login from "../components/Login";
import NavBar from "../components/NavBar";

interface LoginInizialeProps {
    setCodiceFiscale: (codice_fiscale: string) => void;
    codiceFiscale: string;
    url: string;
    isItalian: boolean;
    setIsItalian: (isItalian: boolean) => void;
}

const LoginAdmin:FC<LoginInizialeProps> = ({setCodiceFiscale, url, codiceFiscale,isItalian,setIsItalian}) => {
    return(
        <>
            <NavBar nomi_italiano={["Login","Admin"]} nomi_inglese={["Login","Admin"]} links={["/", "/login_admin"]} isItalian={isItalian} setIsItalian={setIsItalian}/>
            <Login url={url} setCodiceFiscale={setCodiceFiscale} codiceFiscale={codiceFiscale} isItalian={isItalian} />
        </>
    )
}
export default LoginAdmin;