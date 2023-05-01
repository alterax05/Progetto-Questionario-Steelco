import React, {useState, useEffect, FC} from "react";
import axios from "axios";

export interface Domanda{
    id_domanda: number;
    testo_italiano: string;
    testo_inglese: string;
}

interface Risposta {
    id_domanda: number;
    risposta: boolean;
}

interface Risposte {
    codice_fiscale: string;
    lista: Risposta[];
}

const Domande: FC<{ isItalian: boolean, url: string, codice_fiscale: string }> = ({isItalian, url, codice_fiscale}) => {
    const [risposte, setRisposte] = useState<Risposte>({codice_fiscale: codice_fiscale, lista: []});
    const [domande, setDomande] = useState<Domanda[]>([]);
    const [response, setResponse] = useState(null);

    //Controlla che tutti i campi siano stati riempiti
    const validateForm = () => {
        return risposte.lista.length === domande.length;
    }

    //Gestisce l'invio del form
    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        //Preveniamo il comportamento di default del form
        event.preventDefault();
        //Controlliamo che tutti i campi siano stati riempiti
        if (!validateForm())
        {
            alert("Rispondi a tutte le domande");
            return;
        }
        //Impostiamo gli headers
        const POST_headers = {headers: {'Content-Type': 'application/json'}};
        //Impostiamo il tipo di dato che vogliamo inviare

        console.log(risposte)
        try {
            const response = await axios.post(url + "api/Risposte", risposte, POST_headers)
            setResponse(response.data);
        }
        catch (error: any) {
            setResponse(error);
        }
        console.log(response)
    }

    //Gestisce il cambiamento di una risposta
    const handleChange = (scelta: boolean, id: string) => {
        let risposta: Risposta = {id_domanda: parseInt(id), risposta: scelta};
        let risposte_temp: Risposta[] = risposte.lista;
        let trovato: boolean = false;
        for (let i = 0; i < risposte_temp.length && !trovato; i++) {
            if (risposte_temp[i].id_domanda === parseInt(id)) { // se la domanda è già stata risposta
                risposte_temp[i] = risposta;
                trovato = true;
            }
        }
        if (!trovato) {
            risposte_temp.push(risposta);
        }
        setRisposte({codice_fiscale: codice_fiscale, lista: risposte_temp});
        console.log(risposte)
    }

    //Scarica le domande dal server
    useEffect(() => {
        fetch(url + "api/Domande")
            .then(response => response.json())
            .then(data => setDomande(data));
    });

    return (<>
            <form style={{margin: "30px"}} method="post" onSubmit={handleSubmit}>
                <div className="table-responsive">
                    <table className="table">
                        <thead>
                        <tr>
                            <th>Domanda</th>
                            <th>Vero</th>
                            <th>Falso</th>
                        </tr>
                        </thead>
                        <tbody>
                        {
                            domande.map((item) => (
                                <tr>
                                    <td>
                                        {isItalian ? item.testo_italiano : item.testo_inglese}
                                    </td>
                                    <td>
                                        <input type="radio" id={item.id_domanda.toString()} name={item.id_domanda.toString()} onChange={event => handleChange(event.target.checked, event.target.id)}/>
                                    </td>
                                    <td>
                                        <input type="radio" id={item.id_domanda.toString()} name={item.id_domanda.toString()} onChange={event => handleChange(!event.target.checked, event.target.id)}/>
                                    </td>
                                </tr>
                            ))
                        }
                        </tbody>
                    </table>
                </div>
                <div className={"d-flex justify-content-center"}>
                <button className="btn btn-primary d-block w-25" type="submit">Invia risposte</button>
                </div>
            </form>
        </>
    );
}

export default Domande;