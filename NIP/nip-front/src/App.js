import { useState } from 'react';
import './App.css';
import NipBrowser from './Components/NipBrowser';
import NipInfoDisplay from './Components/NipInfoDisplay';

function App() {
  const [displayData, setDisplayData] = useState(undefined);

  return (
    <div className="main">
      <NipBrowser setDisplayData={setDisplayData}/>
      {displayData !== undefined && <NipInfoDisplay displayData={displayData}/>}
    </div>
  );
}

export default App;
