import logo from './logo.svg';
import './App.css';

import {Home} from './Home.js';
import {List} from './YourList.js';
import {Navigation} from './Navigation.js';

import {BrowserRouter, Route} from 'react-router-dom';
import { Router } from 'react-router-dom';
import {Routes} from 'react-router-dom';
 

function App() {
  return (
    <BrowserRouter>
    <div className="container">
      <h3 className="m-3 d-flex justify-content-center"> 
      Welcome to our website!
      </h3>

      <Navigation/>
      
      <Routes>
        <Route path='/Home' сomponent={Home} exact/>
        <Route path='/PersonalList' сomponent={List} exact/>
      </Routes>
      
    </div>
    </BrowserRouter>
  );
}

export default App;
