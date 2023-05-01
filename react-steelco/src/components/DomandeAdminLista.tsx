import React, {useState, FC, useEffect} from "react";
import axios from "axios";
import {Domanda} from "./Domande";

const DomandeAdminLista: FC<{ url: string }> = ({url}) => {
    const [ids, setIds] = useState<number[]>([]);
    const [domande, setDomande] = useState<Domanda[]>([]);

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        if (ids.length === 0) {
            alert("Seleziona almeno una domanda");
            return;
        }

        const POST_headers = {headers: {'Content-Type': 'application/json'}};

        for (let id of ids) {
            const response = await axios.delete(url + "api/Domande/" + id, POST_headers);
            console.log(response.data);
            if (response.status !== 200) {
                alert("Errore");
            }
        }

        setIds([]);
    }

    //Scarica le domande dal server
    useEffect(() => {
        fetch(url + "api/Domande/")
            .then(response => response.json())
            .then(data => setDomande(data));
    });

    const handleSelect = (id: number, checked: boolean) => {
        let ids_temp: number[] = ids;
        let trovato: boolean = false;

        for (let i = 0; i < ids.length && !trovato; i++) {
            if (ids_temp[i] === id) { // Utente già selezionato
                if (!checked) { // Se l'utente è stato deselezionato
                    ids.splice(i, 1);
                }
                trovato = true;
            }
        }
        if (!trovato && checked) { // Utente selezionato ma non trovato
            ids.push(id);
        }
        setIds(ids_temp);
        console.log(ids)
    }

    return (
        <>
            <label className="form-label d-md-flex justify-content-md-center" style={{margin: "10px"}}>Visualizza
                domande</label>
            <form style={{margin: "30px"}} onSubmit={handleSubmit}>
                <div className="table-responsive">
                    <table className="table">
                        <thead>
                        <tr>
                            <th>Domanda italiano</th>
                            <th>Domanda inglese</th>
                            <th>Seleziona</th>
                        </tr>
                        </thead>
                        <tbody>
                        {
                            domande.map((item) => (
                                <tr>
                                    <td>{item.testo_italiano}</td>
                                    <td>{item.testo_inglese}</td>
                                    <td>
                                        <input type="checkbox" id={item.id_domanda.toString()}
                                               onChange={event => handleSelect(parseInt(event.target.id), event.target.checked)}/>
                                    </td>
                                </tr>
                            ))
                        }
                        </tbody>
                    </table>
                    <div className={"d-flex justify-content-center"}>
                        <button className="btn btn-primary d-block w-25" type="submit">Esegui</button>
                    </div>
                </div>
            </form>
        </>
    );
}

export default DomandeAdminLista;