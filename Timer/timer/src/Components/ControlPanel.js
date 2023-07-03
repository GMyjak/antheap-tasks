import React from 'react';

function ControlPanel() {
    return (
      <div>
        <h1>Start new task</h1>
        <div>
            <input className="input-field" text="Enter task name" maxLength={80}/>
            <button className="button button-blue">Start</button>
        </div>
        
      </div>
    );
  }
  
  export default ControlPanel;