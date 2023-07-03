import '../App.css';
import React from 'react';
import ListItem from './ListItem';

const list = [
    { title: "Task 1 adfgsasdgasdgasdgasdasdfasdasd", id: 1, timeStart: 2137, timeStop: 2230 },
    { title: "Task 2", id: 2, timeStart: 2412, timeStop: undefined },
    { title: "Task 3", id: 3, timeStart: 5102, timeStop: undefined },
];

const listItems = list.map(task => 
    <ListItem task={task}/>
);

function TaskList() {
    return (
      <div>
        <h1>Task list</h1>
        <div>
            {listItems}
        </div>
      </div>
    );
}
  
export default TaskList;