import React from "react";
import Link from "./NavBarLinks";
interface NavBarProps {
    nomi_italiano: string[];
    nomi_inglese: string[];
    links: string[];
    isItalian: boolean;
    setIsItalian?: (isItalian: boolean) => void;
}

const NavBar: React.FC<NavBarProps> = ({
                                           nomi_italiano, nomi_inglese, links, isItalian, setIsItalian,
                                       }) => {
    //Navigazione in italiano o inglese
    const navigazione_inglese: string = "Toggle navigation"
    const navigazione_italiano: string = "Attiva/Disattiva navigazione"
    const nomi: string[] = isItalian ? nomi_italiano : nomi_inglese

    return (
        <>
            <nav className="navbar navbar-dark navbar-expand-md py-3 mb-3"
                 style={{backgroundColor: "#003a70"}}>
                <div className="container">
                    <a className="navbar-brand d-flex align-items-center" href="https://www.steelcogroup.com/it/">
                        <img
                            src={"https://www.steelcogroup.com/app/uploads/2022/03/Logo-Steelco-Pantone-654C-MIELE-Group-Member-WHITE.png"}
                            height={30} alt={"Steelco Logo"} style={{marginLeft: '10px'}}/>
                    </a>
                    <button className="navbar-toggler" data-bs-toggle="collapse" data-bs-target="#navcol-6">
                        <span className="visually-hidden">{isItalian?navigazione_italiano:navigazione_inglese}</span><span
                        className="navbar-toggler-icon"></span>
                    </button>
                    <div id="navcol-6" className="collapse navbar-collapse flex-grow-0 order-md-first">
                        <ul className="navbar-nav me-auto">
                            {nomi.map((item, index) => (
                                <Link testo={item} link={links[index]} id={index.toString()}/>
                            ))}
                        </ul>
                        {
                            setIsItalian !== undefined ?
                            <div className="d-md-none my-2">
                                <button className={isItalian ? "btn btn-primary me-2":"btn-light me-2"} type="button">Italiano</button>
                                <button className={!isItalian ? "btn btn-primary me-2":"btn-light me-2"} type="button">Inglese</button>
                            </div>:
                            <div className="d-md-none my-2">
                                <button className="btn btn-light me-2" type="button" style={{visibility: "hidden"}}>Italiano</button>
                                <button className="btn btn-primary" type="button"style={{visibility: "hidden"}}>Inglese</button>
                            </div>
                        }
                    </div>
                    {
                        setIsItalian !== undefined ?
                        <div className="d-none d-md-block">
                            <a className={isItalian ? "btn btn-primary me-2":"btn btn-light me-2"} role="button" onClick={()=>setIsItalian(true)}>Italiano</a>
                            <a className={!isItalian ? "btn btn-primary me-2":"btn btn-light me-2"} role="button" onClick={()=>setIsItalian(false)}>Inglese</a>
                        </div>:
                        <div className="d-none d-md-block">
                            <a className="btn btn-light me-2" role="button" href="#" style={{visibility: "hidden"}}>Italiano</a>
                            <a className="btn btn-light me-2" role="button" href="#" style={{visibility: "hidden"}}>Inglese</a>
                        </div>
                    }
                </div>
            </nav>
        </>
        );
};
export default NavBar;