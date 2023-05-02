import {FC} from 'react';
import DomandeAdminLista from "../components/DomandeAdminLista";
import NavBar from "../components/NavBar";
import DomandeAdminAdd from "../components/DomandeAdminAdd";

interface DomandeAdminProps {
    url: string;
}

const DomandeAdmin:FC<DomandeAdminProps> = ({url}) => {
    return(
        <>
            <NavBar nomi_italiano={["Domande","Utenti"]} nomi_inglese={["Questions","User"]} links={["/domande_admin","/utenti_admin"]} isItalian={true} setIsItalian={undefined}/>
            <DomandeAdminAdd url={url}/>
            <DomandeAdminLista url={url}/>
        </>
    )
}
export default DomandeAdmin;