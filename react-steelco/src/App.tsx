import React, {useState} from 'react';
import { BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import Video from './components/YoutubeVideoEncoder';
import NavBar from "./components/NavBar";
import Pass from "./components/Pass";
import Domande from "./components/Domande";
import LoginAdmin from "./components/LoginAdmin";
import UserAdmin from "./components/UserAdmin";
import DomandeAdminLista from "./components/DomandeAdminLista";
import DomandeAdminAdd from "./components/DomandeAdminAdd";
import LoginIniziale from "./pages/LoginIniziale";

function App() {
    const [isItalian, setIsItalian] = useState<boolean>(true);
    const [codiceFiscale, setCodiceFisclale] = useState<string>("");
    const url: string = "https://localhost:7018/";
    const nomi_italiano: string[] = ["Home", "Chi siamo", "Prodotti", "Servizi", "News", "Contatti"];
    const nomi_inglese: string[] = ["Home", "About us", "Products", "Services", "News", "Contacts"];
    const links: string[] = ["/", "/about-us", "/products", "/services", "/news", "/contacts"];

  return (
    <>
        {/*
        <NavBar nomi_italiano={nomi_italiano} nomi_inglese={nomi_inglese} links={links} isItalian={isItalian} links_bottoni={links} testo_bottoni={["Ciao", "Giggio"]} />
        <LoginAdmin url={"https://localhost:7018/"}/>
        <Video/>
        <Pass pass={true} isItalian={isItalian}/>
        <Domande url={url} isItalian={isItalian} codice_fiscale={codiceFiscale}/>
        <DomandeAdminAdd url={url}/>
        <DomandeAdminLista url={url}/>
        <UserAdmin url={url}/>
        */}
        {/*Aggiungere la roba del login per l'amministratore ._. e le max domande thx*/}
        <LoginIniziale setCodiceFiscale={setCodiceFisclale} codiceFiscale={codiceFiscale} url={url} isItalian={isItalian} setIsItalian={setIsItalian}/>
    </>
  );
}

export default App;
