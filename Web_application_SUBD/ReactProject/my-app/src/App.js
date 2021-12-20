
import React from "react";
import './App.css';
import Navbar from "./Components/NavBar/NavBar";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Home from './Pages/Home';
import Contact from './Pages/Contact';
import List from './Pages/List.JS';

function App() {
  return (
    <Router>
      <Navbar />
      <Routes>
        <Route path="/" exact component={Home} />
        <Route path="/PersonalList" components={List} />
        <Route path="/contact" component={Contact} />
        
      </Routes>
    </Router>
  );
}

export default App;
