import "./navbar.css";
import { Link } from "react-router-dom";
import { slide as Menu } from "react-burger-menu";
function Navbar() {
  return (
    <div className="navMenu">
      <Menu right>
        <Link to="/">Home</Link>
        <Link to="/">Buy/Rent House</Link>
        <Link to="/">Sell House</Link>
        <Link to="/">Our recommandations</Link>
        <Link to="/">My Profile</Link>
      </Menu>
    </div>
  );
}
export default Navbar;
