import React, {useState} from 'react';
import { BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import LoginIniziale from "./pages/LoginIniziale";
import LoginAdmin from "./pages/LoginAdmin";
import Video from "./pages/Video";
import Domande from "./pages/Domande";
import Pass from "./components/Pass";
import DomandeAdmin from "./pages/DomandeAdmin";
import UtentiAdmin from "./pages/UtentiAdmin";

function App() {
    const [isItalian, setIsItalian] = useState<boolean>(true);
    const [codiceFiscale, setCodiceFisclale] = useState<string>("");
    const [passato, setPassato] = useState<boolean>(false);
    const url_api: string = "https://localhost:7018/";

  return (
    <>
        <Router>
            <Routes>
                <Route path="/" element={<LoginIniziale setCodiceFiscale={setCodiceFisclale} codiceFiscale={codiceFiscale} url={url_api} isItalian={isItalian} setIsItalian={setIsItalian}/>}/>
                <Route path="/domande" element={<Domande isItalian={isItalian} url_api={url_api} codiceFiscale={codiceFiscale} passato={passato} setPassato={setPassato}/>}/>
                <Route path="/login_admin" element={<LoginAdmin url={url_api}/>}/>
                <Route path="/video" element={<Video isItalian={isItalian}/>}/>
                <Route path="/result" element={<Pass pass={passato} isItalian={isItalian}/>}/>
                <Route path={"/domande_admin"} element={<DomandeAdmin url={url_api}/>}/>
                <Route path={"/utenti_admin"} element={<UtentiAdmin url={url_api}/>}/>
            </Routes>
        </Router>
    </>
  );
}

export default App;
