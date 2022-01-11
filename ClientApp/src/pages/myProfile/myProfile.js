import "./myProfile.css"
import {ReactComponent as Edit} from "../../images/edit.svg"
import {Link} from "react-router-dom";
export default function MyProfile(){
    return(
        <div className="myProfile">
            <div>
                <div className="line">
                    <h1>Username</h1>
                    <Link to="/profile/edit">
                        <div className="svgButton"><Edit/></div>
                    </Link>
                </div>
                <hr/>
            </div>
            <div className="userDetails">
                <p>Name:</p>
                <p>E-mail: </p>
                <p>Phone Number: </p>
                <p>Total number of views of the houses:</p>
            </div>
        </div>
    )
}