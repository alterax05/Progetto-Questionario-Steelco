import {FC} from 'react';
import Login from "../components/Login";
import NavBar from "../components/NavBar";

interface LoginInizialeProps {
    url: string;
    isItalian: boolean;
    setIsItalian: (isItalian: boolean) => void;
}

const LoginAdmin:FC<LoginInizialeProps> = ({url, isItalian,setIsItalian}) => {
    return(
        <>
            <NavBar nomi_italiano={["Login","Admin"]} nomi_inglese={["Login","Admin"]} links={["/", "/login_admin"]} isItalian={isItalian} setIsItalian={setIsItalian}/>
            <Login url={url} isItalian={isItalian} />
        </>
    )
}
export default LoginAdmin;