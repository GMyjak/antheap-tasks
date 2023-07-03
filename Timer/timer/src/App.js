import './App.css';
import ControlPanel from './Components/ControlPanel';
import TaskList from './Components/TaskList';

function App() {
  return (
    <div className="main">
      <div className="control-panel">
        <ControlPanel />
      </div>
      <div className="task-list">
        <TaskList />
      </div>
    </div>
  );
}

export default App;
