import React from 'react';
import { BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import Video from './components/YoutubeVideoEncoder';
import NavBar from "./components/NavBar";
import Pass from "./components/Pass";
import Domande from "./components/Domande";
import Login from "./components/Login";
import LoginAdmin from "./components/LoginAdmin";
import UserAdmin from "./components/UserAdmin";
import DomandeAdminLista from "./components/DomandeAdminLista";
import DomandeAdminAdd from "./components/DomandeAdminAdd";

function App() {
  const nomi_italiano: string[] = ["Home", "Chi siamo", "Prodotti", "Servizi", "News", "Contatti"];
  const nomi_inglese: string[] = ["Home", "About us", "Products", "Services", "News", "Contacts"];
  const links: string[] = ["/", "/about-us", "/products", "/services", "/news", "/contacts"];
  const isItalian: boolean = true;

  return (
    <>
        <NavBar nomi_italiano={nomi_italiano} nomi_inglese={nomi_inglese} links={links} isItalian={isItalian} links_bottoni={links} testo_bottoni={["Ciao", "Giggio"]} />
        <Login url={"https://localhost:7018/api/Utenti"}/>
        <LoginAdmin url={"https://localhost:7018/api/Utenti/PostAdmin"}/>
        <Video/>
        <Pass pass={true} isItalian={isItalian}/>
        <Domande url={"https://localhost:7018/"} isItalian={isItalian} codice_fiscale={"1234567890123456"}/>
        <DomandeAdminAdd url={"https://localhost:7018/"}/>
        <DomandeAdminLista url={"https://localhost:7018/"}/>
        <UserAdmin url={"https://localhost:7018/"}/>
    </>
  );
}

export default App;
