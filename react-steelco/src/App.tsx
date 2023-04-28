import React from 'react';
import logo from './logo.svg';
import { BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import './App.css';
import './exported-pages/assets/bootstrap/css/bootstrap.min.css';
import './exported-pages/assets/css/styles.min.css';
import Video from './components/YoutubeVideoEncoder';
import NavBar from "./components/NavBar";

function App() {
  const nomi_italiano: string[] = ["Home", "Chi siamo", "Prodotti", "Servizi", "News", "Contatti"];
  const nomi_inglese: string[] = ["Home", "About us", "Products", "Services", "News", "Contacts"];
  const links: string[] = ["/", "/about-us", "/products", "/services", "/news", "/contacts"];
  const isItalian: boolean = true;
  return (
    <>
      <NavBar nomi_italiano={nomi_italiano} nomi_inglese={nomi_inglese} links={links} isItalian={true} links_bottoni={links} testo_bottoni={["Ciao", "Giggio"]} />
      <Video/>
    </>
  );
}

export default App;
