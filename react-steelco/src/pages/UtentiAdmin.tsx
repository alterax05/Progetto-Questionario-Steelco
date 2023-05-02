import {FC} from 'react';
import NavBar from "../components/NavBar";
import UserAdmin from "../components/UserAdmin";

interface UtentiProps {
    url: string;
}

const UtentiAdmin:FC<UtentiProps> = ({url}) => {
    return(
        <>
            <NavBar nomi_italiano={["Domande","Utenti"]} nomi_inglese={["Questions","User"]} links={["/domande_admin","/utenti_admin"]} isItalian={true} setIsItalian={undefined}/>
            <UserAdmin url={url}/>
        </>
    )
}
export default UtentiAdmin;