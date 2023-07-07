import '../App.css';
import React from 'react';
import ListItem from './ListItem';

function TaskList({tasks, finishTask}) {

    const listItems = tasks.map(task => 
        <ListItem task={task} finishTask={finishTask}/>
    );

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