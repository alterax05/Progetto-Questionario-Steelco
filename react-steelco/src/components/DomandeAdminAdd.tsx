import React, {useState, FC} from "react";
import axios from "axios";

const DomandeAdminAdd: FC<{ url: string }> = ({url}) => {

    const [testo_italiano, setTesto_italiano] = useState<string>("");
    const [testo_inglese, setTesto_inglese] = useState<string>("");
    const [corretta, setCorretta] = useState<boolean>(true);
    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        let domanda = {testo_italiano: testo_italiano, testo_inglese: testo_inglese, corretta: corretta};
        if (domanda.testo_italiano === "") {
            alert("Domanda italiano vuota");
            return;
        }
        if (domanda.testo_inglese === "") {
            alert("Domanda inglese vuota");
            return;
        }

        const POST_headers = {headers: {'Content-Type': 'application/json'}};
        const response = await axios.post(url + "api/Domande/",domanda,POST_headers);
        console.log(response.data);
        if (response.status !== 200) {
            alert("Errore");
        }
        else {
            alert("Domanda aggiunta");
            setTesto_italiano("");
            setTesto_inglese("");
            setCorretta(false);
        }

    }

    return (
        <>
            <div className="text-center d-flex justify-content-md-center">
                <form style={{margin: "30px"}} onSubmit={handleSubmit}>
                    <label className="form-label" style={{marginBottom: "10px"}}>Aggiungi Domanda</label>
                    <input
                        required={true}
                        className="form-control d-inline-flex" type="text"
                        style={{marginBottom: "10px", marginRight: "0", marginLeft: "0"}} placeholder="Testo Italiano"
                        onChange={event => setTesto_italiano(event.target.value)}
                        value={testo_italiano}
                    />

                    <input
                        className="form-control d-inline-flex" type="text"
                        required={true}
                        style={{marginBottom: "10px", marginRight: "0", marginLeft: "0"}}
                        placeholder="Testo Inglese"
                        onChange={event => setTesto_inglese(event.target.value)}
                        value={testo_inglese}
                    />

                    <div className="form-check text-center d-lg-flex justify-content-lg-center"
                         style={{marginBottom: "10px", marginRight: 0}}>
                        <input id="formCheck-1"
                               className="form-check-input"
                               type="checkbox"
                               required={true}
                               onChange={event => setCorretta(event.target.checked)}
                               checked={corretta}
                        />

                        <label
                            className="form-check-label" htmlFor="formCheck-1" style={{marginLeft: "10px"}}>Seleziona
                            per
                            risposta vera</label>
                    </div>
                    <button className="btn btn-primary" type={"submit"}>Aggiungi</button>
                </form>
            </div>
        </>
    );
}

export default DomandeAdminAdd;