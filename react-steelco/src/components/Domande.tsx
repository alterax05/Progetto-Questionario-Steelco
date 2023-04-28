import React from 'react';

const Domande: React.FC<{ domande: string[], risposte: string[] }> = ({domande, risposte}) => {
    return (<>
        <form>
            <ul className="list-group py-3">
                <li className="list-group-item">
                    <div className="text-center d-flex justify-content-around align-items-center"><span>List Group Item 1</span>
                        <div className="form-check">
                            <input className="form-check-input" type="radio" id="formCheck-1"/>
                            <label className="form-check-label" htmlFor="formCheck-1">Label</label>
                        </div>
                        <div className="form-check">
                            <input className="form-check-input" type="radio" id="formCheck-2"/>
                            <label className="form-check-label" htmlFor="formCheck-2">Label</label>
                        </div>
                    </div>
                </li>
                <li className="list-group-item">
                    <div className="text-center d-flex justify-content-around align-items-center"><span>List Group Item 1</span>
                        <div className="form-check">
                            <input className="form-check-input" type="radio" id="formCheck-7"/>
                            <label className="form-check-label" htmlFor="formCheck-7">Label</label>
                        </div>
                        <div className="form-check"><input className="form-check-input" type="radio" id="formCheck-8"/>
                            <label className="form-check-label" htmlFor="formCheck-8">Label</label></div>
                    </div>
                </li>
                <li className="list-group-item">
                    <div className="text-center d-flex justify-content-around align-items-center"><span>List Group Item 1</span>
                        <div className="form-check"><input className="form-check-input" type="radio"
                                                           id="formCheck-5"/><label
                            className="form-check-label" htmlFor="formCheck-5">Label</label></div>
                        <div className="form-check"><input className="form-check-input" type="radio"
                                                           id="formCheck-6"/><label
                            className="form-check-label" htmlFor="formCheck-6">Label</label></div>
                    </div>
                </li>
                <li className="list-group-item">
                    <div className="text-center d-flex justify-content-around align-items-center"><span>List Group Item 1</span>
                        <div className="form-check"><input className="form-check-input" type="radio"
                                                           id="formCheck-3"/><label
                            className="form-check-label" htmlFor="formCheck-3">Label</label></div>
                        <div className="form-check"><input className="form-check-input" type="radio"
                                                           id="formCheck-4"/><label
                            className="form-check-label" htmlFor="formCheck-4">Label</label></div>
                    </div>
                </li>
            </ul>
        </form>
    </>
);}

export default Domande;