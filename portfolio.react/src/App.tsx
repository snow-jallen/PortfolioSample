import React from 'react';
import logo from './logo.svg';
import './App.css';
import Adder from './components/Adder/Adder';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
      <Adder num1={5} num2={2} />
    </div>
  );
}

export default App;
