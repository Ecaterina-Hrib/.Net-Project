import './navbar.css'
import {Link} from 'react-router-dom'
import {slide as Menu} from 'react-burger-menu'
function Navbar(){
    let loggedIn=localStorage.getItem("loggedIn");
    const logOut = () => {
        localStorage.clear();
        loggedIn=false;
        window.location.href="http://localhost:3000/"
        window.location.reload();
    }
    return(
        <div className="navMenu">
            <Menu right>
                <div className="circle">
                    <div id="roundPicture"></div>
                </div>
                <Link to="/">Home</Link>
                <Link to="/buy">Buy/Rent House</Link>
                <Link to="/sell">Sell House</Link>
                <Link to="/ourRecommandations">Our recommandations</Link>
                <Link to="/profile">My Profile</Link>

                    {!loggedIn ?
                    (
                <div className="registerButtons">
                        <Link to="/signup"><button>Sign up</button></Link>
                    <Link to="/login"><button>Log in</button></Link>
                </div>
                    ) : (<div className="registerButtons">
                        <button onClick={logOut}>Log Out</button>
                        </div>)
                    }
            </Menu>
        </div>
    );
}
export default Navbar;