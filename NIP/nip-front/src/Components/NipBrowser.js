import React from "react";
import { useRef, useState } from "react";

function NipBrowser({setDisplayData}) {
    const [errorMessage, setErrorMessage] = useState(undefined);
    const inputRef = useRef(null);

    const GetData = (nip) => {
        const regex = "^\\d{10}$";
        const match = nip.match(regex);

        if (match === null) {
            setErrorMessage("Niepoprawny numer NIP");
            return;
        }

        const uri = 'https://localhost:7002/TaxApi/Nip/' + nip;

        fetch(uri)
            .then(async response => {

                console.log(response);

                const data = await response.json();

                if (response.status === 400) {
                    setErrorMessage("Niepoprawny numer NIP");
                    return Promise.reject();
                }

                if (response.status === 404) {
                    if (data.code === "WL-115") {
                        setErrorMessage("Nie można znaleźć tego numeru");
                    } else {
                        setErrorMessage("Błąd API");
                    }
                    return Promise.reject();
                }

                if (!response.ok) {
                    setErrorMessage("Nieznany błąd");
                    return Promise.reject();
                }
                
                setErrorMessage(undefined);
                console.log(data);
                setDisplayData(data);
            })
            .catch(err => {
                console.error(err);
            });
    }
    
    return (
        <div className="nip-browser">
            <h2>Wpisz numer NIP</h2>
            <input className="input-field" maxLength={10} ref={inputRef}></input>
            <button className="button search-button" onClick={() => {
                GetData(inputRef.current.value);
            }}>Szukaj</button>
            <h3 className="error-message">{errorMessage}</h3>
        </div>
    );
}

export default NipBrowser;
