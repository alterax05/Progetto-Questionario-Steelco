import React, {useState, FC} from "react";
import axios from "axios";

const DomandeAdminAdd: FC<{ url: string }> = ({url}) => {

    const [domanda, setDomanda] = useState<{
        testo_italiano: string,
        testo_inglese: string,
        corretta: boolean
    }>({testo_italiano: "", testo_inglese: "", corretta: true});
    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        if (domanda.testo_italiano === "") {
            alert("Domanda italiano vuota");
            return;
        }
        if (domanda.testo_inglese === "") {
            alert("Domanda inglese vuota");
            return;
        }

        const POST_headers = {headers: {'Content-Type': 'application/json'}};
        const response = await axios.post(url + "api/Domande/", POST_headers);
        console.log(response.data);
        if (response.status !== 200) {
            alert("Errore");
        }

        setDomanda({testo_italiano: "", testo_inglese: "", corretta: true});
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
                        onChange={event => () => {
                            let domanda_temp = domanda;
                            domanda_temp.testo_italiano = event.target.value;
                            setDomanda(domanda_temp);
                        }}
                    />
                    <input
                        className="form-control d-inline-flex" type="text"
                        required={true}
                        style={{marginBottom: "10px", marginRight: "0", marginLeft: "0"}}
                        placeholder="Testo Inglese"
                        onChange={event => () => {
                            let domanda_temp = domanda;
                            domanda_temp.testo_inglese = event.target.value;
                            setDomanda(domanda_temp);
                        }}
                    />
                    <div className="form-check text-center d-lg-flex justify-content-lg-center"
                         style={{marginBottom: "10px", marginRight: 0}}>
                        <input id="formCheck-1"
                               className="form-check-input"
                               type="checkbox"
                               required={true}
                               onChange={event => () => {
                                let domanda_temp = domanda;
                                domanda_temp.corretta = event.target.checked;
                                setDomanda(domanda_temp);
                        }}/>
                        <label
                            className="form-check-label" htmlFor="formCheck-1" style={{marginLeft: "10px"}}>Seleziona per
                            risposta vera</label>
                    </div>
                    <button className="btn btn-primary" type={"submit"}>Aggiungi</button>
                </form>
            </div>
        </>
    );
}

export default DomandeAdminAdd;