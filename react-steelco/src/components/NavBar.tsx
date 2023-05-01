import React from "react";
import Link from "./NavBarLinks";
import image from "../assets/steelco-logo.jpg";

interface NavBarProps {
    nomi_italiano: string[];
    nomi_inglese: string[];
    links: string[];
    isItalian: boolean;
    testo_bottoni: string[];
    links_bottoni: Function[] | string[];
}

const NavBar: React.FC<NavBarProps> = ({nomi_italiano, nomi_inglese, links, isItalian, testo_bottoni, links_bottoni}) => {
    //Navigazione in italiano o inglese
    const navigazione_inglese: string = "Toggle navigation"
    const navigazione_italiano: string = "Attiva/Disattiva navigazione"
    const nomi: string[] = isItalian ? nomi_italiano : nomi_inglese

    return (
        <>
            <nav className="navbar navbar-light navbar-expand-md py-3">
                <div className="container">
                    <a className="navbar-brand d-flex align-items-center" href="https://www.steelcogroup.com/it/">
                        <img src={image} height={52} alt={"Steelco Logo"} style={{marginLeft: '10px'}}/>
                    </a>
                    <button data-bs-toggle="collapse" className="navbar-toggler" data-bs-target="#navcol-3">
                        <span
                            className="visually-hidden">{isItalian ? navigazione_italiano : navigazione_inglese}</span>
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="navcol-3">
                        <ul className="navbar-nav mx-auto">
                            {nomi.map((item, index) => (
                                <Link testo={item} link={links[index]} id={index.toString()}/>
                            ))}
                        </ul>
                        {
                            testo_bottoni.map((item, index) => (
                                <button className="btn btn-primary" type="button" style={{marginRight: '10px'}}>{item}</button>
                            ))
                        }
                    </div>
                </div>
            </nav>
        </>
    );
};
export default NavBar;