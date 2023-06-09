import React from 'react';
import {useState} from 'react';
import axios from "axios";
import {useNavigate} from "react-router-dom";

const LoginAdmin: React.FC<{url: string}> = ({url}) => {
    const [password, setPassword] = useState('');
    const [userName, setUserName] = useState('');
    const [response, setResponse] = useState(null);

    const navigate = useNavigate();
    const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        //Impostiamo gli headers
        const POST_headers = {headers: {'Content-Type': 'application/json'}};
        //Impostiamo il tipo di dato che vogliamo inviare
        const dati = {
            userName: userName,
            password: password
        };
        axios.post(url + "api/Utenti/PostAdmin", dati, POST_headers)
            .then(r => {
                setResponse(r.data);
            })
            .catch(e => {
                setResponse(e);
            });
        console.log(response);
    }
        return (
            <>
                <section className="py-4 py-xl-5">
                    <div className="container">
                        <div className="row mb-5">
                            <div className="col-md-8 col-xl-6 text-center mx-auto"><h2>Sign in</h2>
                                <p>Inserire nome e cognome</p>
                            </div>
                        </div>
                        <div className="row d-flex justify-content-center">
                            <div className="col-md-6 col-xl-4">
                                <div className="card mb-5">
                                    <div className="card-body d-flex flex-column align-items-center">
                                        <div className="bs-icon-xl bs-icon-circle bs-icon-primary bs-icon my-4">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="5em" height="5em" viewBox="0 0 16 16" className="bi bi-person">
                                                <path
                                                    d="M8 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6zm2-3a2 2 0 1 1-4 0 2 2 0 0 1 4 0zm4 8c0 1-1 1-1 1H3s-1 0-1-1 1-4 6-4 6 3 6 4zm-1-.004c-.001-.246-.154-.986-.832-1.664C11.516 10.68 10.289 10 8 10c-2.29 0-3.516.68-4.168 1.332-.678.678-.83 1.418-.832 1.664h10z">
                                                </path>
                                            </svg>
                                        </div>
                                        <form className="text-center" method="post" onSubmit={handleSubmit}>
                                            <div className="mb-3">
                                                <div className="mb-3">
                                                    <input className="form-control" type="text" name="nome" placeholder="Nome" value={userName} onChange={event=>setUserName(event.target.value)} required={true}/>
                                                </div>
                                            </div>
                                            <input className="form-control" type="password" name="password" placeholder="Password" value={password} onChange={(event) => setPassword(event.target.value)} required={true}/>
                                            <div className="mb-3"></div>
                                            <button className="btn btn-primary d-block w-100" type="submit" onClick={()=>{navigate("/domande_admin")}}>Login</button>
                                        </form>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </>
        );
    }

export default LoginAdmin;