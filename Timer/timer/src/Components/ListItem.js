import React from "react";

function ListItem({task, finishTask}) {
    const TimeParsed = (date) => {
        if (date === undefined)
            return '---';
        else {
            const year = date.getFullYear();
            const month = AppendZeros(date.getMonth());
            const day = AppendZeros(date.getDate());
            const hour = AppendZeros(date.getHours());
            const minute = AppendZeros(date.getMinutes());
            const second = AppendZeros(date.getSeconds());
            
            return day + '-' + month + '-' + year + ' ' + hour + ':' + minute + ':' + second;
        }
    }

    const ElapsedParsed = (elapsed) => {
        const milis = elapsed % 1000;
        const seconds = Math.floor(elapsed / 1000) % 60;
        const minutes = Math.floor(elapsed / 1000 / 60) % 60;
        const hours = Math.floor(elapsed / 1000 / 60/ 60) % 24;
        const days = Math.floor(elapsed / 1000 / 60/ 60 / 24);

        let formatted = AppendZeros(hours) + ":" + AppendZeros(minutes) + ":" + AppendZeros(seconds) + ":" + AppendZerosToMilis(milis);

        if (days > 0) {
            formatted = days + "d " + formatted;
        }

        return formatted;
    }

    const AppendZeros = (num) => num < 10 ? "0" + num : num;
    const AppendZerosToMilis = (num) => {
        switch (num)
        {
            case num < 10:
                return "00" + num;
            case num < 100:
                return "0" + num;
            default:
                return num;
        }
            
    }
    
    return (
      <div className="list-item">
        <div className="list-item-element">
            <h4>{task.name}</h4>
        </div>
        <div className="list-item-element">
            <div>
                <h6>Start time</h6>
                <h4>{TimeParsed(task.startTime)}</h4>
            </div>
        </div>
        <div className="list-item-element">
            <div>
                <h6>End time</h6>
                <h4>{TimeParsed(task.endTime)}</h4>
            </div>
        </div>
        <div className="list-item-element">
            <div>
                <h6>Running</h6>
                <h4>{ElapsedParsed(task.runningTime)}</h4>
            </div>
        </div>
        <div className="list-item-element">
            {task.endTime === undefined && 
                <button className="button button-red" onClick={() => finishTask(task)}>Finish</button>
            }  
        </div>
      </div>
    );
}
  
export default ListItem;