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

    let url_api: string;
    if (process.env.NODE_ENV === 'development')
    {
        url_api = "https://4cimicheleporcellato.barsanti.edu.it/";
    }
    else
    {
        url_api = process.env.PUBLIC_URL + "/";
    }

  return (
    <>
        <Router>
            <Routes>
                <Route path="/" element={<LoginIniziale url={url_api} isItalian={isItalian} setIsItalian={setIsItalian}/>}/>
                <Route path="/domande" element={<Domande isItalian={isItalian} url_api={url_api}/>}/>
                <Route path="/login_admin" element={<LoginAdmin url={url_api}/>}/>
                <Route path="/video" element={<Video isItalian={isItalian}/>}/>
                <Route path="/result" element={<Pass isItalian={isItalian}/>}/>
                <Route path={"/domande_admin"} element={<DomandeAdmin url={url_api}/>}/>
                <Route path={"/utenti_admin"} element={<UtentiAdmin url={url_api}/>}/>
            </Routes>
        </Router>
    </>
  );
}

export default App;
