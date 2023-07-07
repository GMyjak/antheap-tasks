import React from 'react';
import { useRef } from 'react';

function ControlPanel(props) {
    const inputRef = useRef(null);

    return (
        <div>
            <h1>Start new task</h1>
            <div>
                <input className="input-field" maxLength={80} ref={inputRef} />
                <button className="button button-blue" onClick={() => {
                    props.addTask(inputRef.current.value);
                }
                }>Start</button>
            </div>

        </div>
    );
}

export default ControlPanel;