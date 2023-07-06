import React from "react";
import SinglePropertyDisplay from "./SinglePropertyDisplay";
import PersonDisplay from "./PersonDisplay";

function NipInfoDisplay({displayData}) {
    const mapPersonList = (list) => list.map(person => <PersonDisplay person={person} />);
    const mapAccountList = (list) => list.map(num => <div className="display-element">{num}</div>);
    const formatDate = (str) => { 
        const date = new Date(str);
        const month = date.getMonth() + 1;

        return date.getDate() + '-' + month + '-' + date.getFullYear();
    };
    
    return (
        <div className="nip-display">
            <h3 className="header-align-left">Podstawowe dane</h3>
            <SinglePropertyDisplay label={"Nazwa"} value={displayData.name}/>
            <SinglePropertyDisplay label={"NIP"} value={displayData.nip}/>
            <SinglePropertyDisplay label={"Status VAT"} value={displayData.statusVat}/>
            <SinglePropertyDisplay label={"REGON"} value={displayData.regon}/>
            <SinglePropertyDisplay label={"PESEL"} value={displayData.pesel}/>
            <SinglePropertyDisplay label={"KRS"} value={displayData.krs}/>
            <SinglePropertyDisplay label={"Adres zamieszkania"} value={displayData.residenceAddress}/>
            <SinglePropertyDisplay label={"Adres roboczy"} value={displayData.workingAddress}/>
            <SinglePropertyDisplay label={"Wirtualne konta?"} value={displayData.hasVirtualAccounts ? "TAK" : "NIE"}/>

            <h3 className="header-align-left">Zdarzenia</h3>
            <SinglePropertyDisplay label={"Data rejestracji"} value={ formatDate(displayData.registrationLegalDate) }/>

            {displayData?.registrationDenialDate !== null && 
            <div>
                <SinglePropertyDisplay label={"Data odmowy rejestracji"} value={ formatDate(displayData.registrationDenialDate) }/>
                <SinglePropertyDisplay label={"Powód odmowy rejestracji"} value={ displayData.registrationDenialBasis }/>
            </div>}

            {displayData?.restorationDate  !== null && 
            <div>
                <SinglePropertyDisplay label={"Data przywrócenia"} value={ formatDate(displayData.restorationDate) }/>
                <SinglePropertyDisplay label={"Powód przywrócenia"} value={ displayData.restorationBasis }/>
            </div>}

            {displayData?.removalDate  !== null && 
            <div>
                <SinglePropertyDisplay label={"Data skasowania"} value={ formatDate(displayData.removalDate) }/>
                <SinglePropertyDisplay label={"Powód skasowania"} value={ displayData.removalBasis }/>
            </div>}


            {displayData?.accountNumbers.length > 0 && 
            <div>
                <h3 className="header-align-left">Numery kont</h3>
                {mapAccountList(displayData.accountNumbers)}    
            </div>}

            {displayData?.representatives.length > 0 && 
            <div>
                <h3 className="header-align-left">Reprezentanci firmy</h3>
                {mapPersonList(displayData.representatives)}    
            </div>}
            
            {displayData?.authorizedClerks.length > 0 && 
            <div>
                <h3 className="header-align-left">Upoważnieni pracownicy</h3>
                {mapPersonList(displayData.authorizedClerks)}
            </div>}
            
            {displayData?.partners.length > 0 && 
            <div>
                <h3 className="header-align-left">Partnerzy</h3>
                {mapPersonList(displayData.partners)}
            </div>}
        </div>
    );
}

export default NipInfoDisplay;
