import React from "react";

function ListItem(props) {
    return (
      <div className="list-item">
        <div className="list-item-element">
            <h4>{props.task.title}</h4>
        </div>
        <div className="list-item-element">
            <div>
                <h6>Start time</h6>
                <h4>2137</h4>
            </div>
        </div>
        <div className="list-item-element">
            <div>
                <h6>End time</h6>
                <h4>2137</h4>
            </div>
        </div>
        <div className="list-item-element">
            <div>
                <h6>Running</h6>
                <h4>2137</h4>
            </div>
        </div>
        <div className="list-item-element">
            {props.task.timeStop === undefined && 
                <button className="button button-red">Finish</button>
            }  
        </div>
      </div>
    );
}
  
export default ListItem;