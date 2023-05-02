import React from 'react';
import pass_image from '../assets/result-pass-icon.svg';
import fail_image from '../assets/result-fail-icon.svg';
import {Link} from "react-router-dom";

interface ResultProps {
    pass: boolean;
    isItalian: boolean;
}

const Result:React.FC<ResultProps> = ({pass,isItalian}) => {

    var titolo: string;
    var testo: string;
    var bottone: string = "Riprova"
    if (pass)
    {
        if (isItalian)
        {
            titolo = "Congratulazioni";
            testo= "Hai Passato il Test";
        }
        else
        {
            titolo = "Congratulations";
            testo= "You Passed the Test";
        }
    }
    else
    {
        if (isItalian)
        {
            titolo = "Mi Dispiace";
            testo= "Non Hai Passato il Test";
            bottone = "Riprova";
        }
        else
        {
            titolo = "I'm Sorry";
            testo= "You Didn't Pass the Test";
            bottone = "Retry";
        }
    }

    return (
        <>
            <section className="py-4 py-xl-5">
                <div className="container">
                    <div className="text-center p-4 p-lg-5">
                        <p className="fw-bold text-primary mb-2">
                            {titolo}
                        </p>
                        <img src={pass ? pass_image : fail_image} width={"76px"} alt={testo}/><img/>
                        <h1 className="fw-bold mb-4">{testo}</h1>
                        {pass ? <></>:<Link to={"/domande"}><button className="btn btn-primary fs-5 me-2 py-2 px-4" type="button">{bottone}</button></Link>}
                    </div>
                </div>
            </section>
        </>
    );
};

export default Result;