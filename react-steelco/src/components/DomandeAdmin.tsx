import React, {useEffect} from 'react';
import {useState, FC} from 'react';
import axios from "axios";

interface User {
    nome: string;
    cognome: string;
    codice_fiscale: string;
}

const DomandeAdmin: FC<{ url: string }> = ({url}) => {
    const [ids, setIds] = useState<string[]>([]);
    const [user, setUser] = useState<User[]>([]);

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        if (ids.length === 0) {
            alert("Seleziona almeno un utente");
            return;
        }

        const POST_headers = {headers: {'Content-Type': 'application/json'}};
        for (let id of ids) {
            const response = await axios.delete(url + "api/Utenti/" + id, POST_headers);
            console.log(response.data);
            if (response.status !== 200) {
                alert("Errore");
            }
        }
    }

    //Scarica gli utenti dal server
    useEffect(() => {
        fetch(url + "api/Utenti")
            .then(response => response.json())
            .then(data => setUser(data));
    });

    const handleSelect = (id: string, checked: boolean) => {
        let ids_temp: string[] = ids;
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
            <form style={{margin: "30px"}} onSubmit={handleSubmit}>
                <div className="table-responsive">
                    <table className="table">
                        <thead>
                        <tr>
                            <th>Nome</th>
                            <th>Cognome</th>
                            <th>Codice Fiscale</th>
                            <th>Seleziona</th>
                        </tr>
                        </thead>
                        <tbody>
                        {
                            user.map((item) => (
                                <tr>
                                    <td>{item.nome}</td>
                                    <td>{item.cognome}</td>
                                    <td>{item.codice_fiscale}</td>
                                    <td><input type="checkbox" id={item.codice_fiscale}
                                               onChange={event => handleSelect(event.target.id, event.target.checked)}/>
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
export default DomandeAdmin;