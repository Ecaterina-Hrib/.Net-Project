import './navbar.css'
import {Link} from 'react-router-dom'
import {slide as Menu} from 'react-burger-menu'
function Navbar(){
    return(
        <div className="navMenu">
            <Menu right>
                <div className="circle">
                    <div id="roundPicture"></div>
                </div>
                <Link to="/">Home</Link>
                <Link to="/buy">Buy/Rent House</Link>
                <Link to="/">Sell House</Link>
                <Link to="/">Our recommandations</Link>
                <Link to="/">My Profile</Link>

                <div className="registerButtons">
                    <button>Sign up</button>
                    <button>Log in</button>
                </div>
            </Menu>
        </div>
    );
}
export default Navbar;