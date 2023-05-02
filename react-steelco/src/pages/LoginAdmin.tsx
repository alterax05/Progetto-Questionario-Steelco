import {FC} from 'react';
import Login from "../components/LoginAdmin";
import NavBar from "../components/NavBar";

interface LoginAdminProps {
    url: string;
}

const LoginIniziale:FC<LoginAdminProps> = ({url}) => {
    return(
        <>
            <NavBar nomi_italiano={["Login","Admin"]} nomi_inglese={["Login","Admin"]} links={["/", "/login_admin"]} isItalian={true} setIsItalian={undefined}/>
            <Login url={url}/>
        </>
    )
}
export default LoginIniziale;