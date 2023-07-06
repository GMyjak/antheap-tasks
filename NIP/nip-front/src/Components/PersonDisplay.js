import React from "react";

function PersonDisplay({ person }) {
    return (
        <div className="person-display-container">
            <div className="display-element">
                <div className="vertical-container">
                    <div className="vertical-label">Nazwa firmy</div>
                    <div>{person.companyName}</div>
                </div>
            </div>
            <div className="display-element">
                <div className="vertical-container">
                    <div className="vertical-label">Imię</div>
                    <div>{person.firstName}</div>
                </div>
            </div>
            <div className="display-element">
                <div className="vertical-container">
                    <div className="vertical-label">Nazwisko</div>
                    <div>{person.lastName}</div>
                </div>
            </div>
            <div className="display-element">
                <div className="vertical-container">
                    <div className="vertical-label">Pesel</div>
                    <div>{person.pesel}</div>
                </div>
            </div>
            <div className="display-element">
                <div className="vertical-container">
                    <div className="vertical-label">NIP</div>
                    <div>{person.nip}</div>
                </div>

            </div>
        </div>
    );
}

export default PersonDisplay;
