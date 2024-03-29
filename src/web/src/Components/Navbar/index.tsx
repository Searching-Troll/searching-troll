import { NavLink } from "react-router-dom";
const Navbar = () => {
    const activeSytle = "underline text-gray-500 underline-offset-4";
    return (
        <nav className="flex justify-between items-center fixed z-10 w-full py-5 px-8 text-md font-light top-0">
            <ul className="flex item-center gap-3">
                <li className="font-semibold text-lg">
                    <NavLink to="/">searching-troll</NavLink>

                </li>
                <li>
                    <NavLink to="/MyAccount" activeClassName={activeSytle}> My Account
                     </NavLink>
                </li>
                <li>
                    <NavLink to="/MyOrders" activeClassName={activeSytle}> My Orders
                     </NavLink>
                </li>
                <li>
                    <NavLink to="/SignIn" activeClassName={activeSytle}> Sign In
                     </NavLink>
                </li>
                <li>
                    <NavLink to="/NotFound" activeClassName={activeSytle}> Not Found
                     </NavLink>
                </li>
            </ul>
        </nav>
    )   
}
export default Navbar
