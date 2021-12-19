import React,{Component} from 'react';
import { Navbar,Nav } from 'react-bootstrap';
import { NavLink } from 'react-router-dom';

export class Navigation extends Component{

    render(){
        return(
            <Navbar bg="dark" expand="lg">
                <Navbar.Toggle aria-controls="basis-navbar-nav"/>
                <Navbar.Collapse id="basis-navbar-nav">
                    <Nav>
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/Home">
                            Home
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/PersonalList">
                            List
                        </NavLink>
                    </Nav>
                </Navbar.Collapse>
            </Navbar>
        )
    }
}