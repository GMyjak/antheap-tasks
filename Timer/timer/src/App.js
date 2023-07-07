import { useState } from 'react';
import './App.css';
import ControlPanel from './Components/ControlPanel';
import TaskList from './Components/TaskList';

function App() {
  const [tasks, setTasks] = useState([]);
  const [taskCounter, setTaskCounter] = useState(0);
  const [interval, setNewInterval] = useState(null);

  function Refresh() {
    const now = new Date();
    const newTasks = tasks.map((t) => {
      if (t.endTime === undefined) {
        t.runningTime = now - t.startTime;
      }
      return t;
    });

    setTasks(newTasks);
  }

  const FinishTask = (task) => {
    const index = tasks.indexOf(task);
    const endTime = new Date();

    const newTasks = tasks.map((t) => {
      if (t.id === index) {
        t.endTime = endTime;
        t.runningTime = endTime - t.startTime;
        return t;
      }
      else {
        return t;
      }
    });

    setTasks(newTasks);
  }
  
  const AddTask = (name) => {
    if (tasks.find(t => t.name === name))
    {
      console.error("Task already created");
      return;
    }

    if (name.lenght < 3)
    {
      console.error("Task name is too short");
      return;
    }

    const newTask = { id: taskCounter, name: name, startTime: new Date(), endTime: undefined, runningTime: 0 };
    tasks.push(newTask);

    setTaskCounter(taskCounter + 1);
    setTasks(tasks);

    if (interval !== null) {
      clearInterval(interval);
    }

    setNewInterval(setInterval(Refresh, 10));
  }

  return (
    <div className="main">
      <div className="control-panel">
        <ControlPanel addTask={AddTask}/>
      </div>
      <div className="task-list">
        <TaskList tasks={tasks} finishTask={FinishTask} />
      </div>
    </div>
  );
}

export default App;
