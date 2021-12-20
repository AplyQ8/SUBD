import React from "react";
import {
    Nav,
    NavLogo,
    NavLink,
    Bars,
    NavMenu,
    NavBtn,
    NavBtnLink,
} from "./NavbarElements";

const Navbar = () => {
    return (
        <>
           <Nav>
            <NavLogo to="/">
                Logo
            </NavLogo>
            <Bars />

            <NavMenu>
                <NavLink to="/" activestyle>
                    Home
                </NavLink>
                <NavLink to="/PersonalList" activestyle>
                    List
                </NavLink>
                <NavLink to="/contact" activestyle>
                    Contact
                </NavLink>
            </NavMenu> 
           </Nav> 
        </>
    );
};
export default Navbar;