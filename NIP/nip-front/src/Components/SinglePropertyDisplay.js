import React from "react";

function SinglePropertyDisplay({label, value}) {
    return (
        value !== null &&
        <div className="display-container">
            <div className="display-element">
                {label}
            </div>
            <div className="display-element">
                {value}
            </div>
        </div>
    );
}

export default SinglePropertyDisplay;
