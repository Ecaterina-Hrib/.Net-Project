import "./signup.css"
import {Link} from 'react-router-dom';
export default function Signup() {
    return (
        <div class="signup">
            <div class="signupbox">
                <label>Name</label>
                <input type="text" value=""/>
                <label>E-mail</label>
                <input type="text" value=""/>
                <label>Username</label>
                <input type="text" value=""/>
                <label>Password</label>
                <input type="text" value=""/>
                <label>Confirm Password</label>
                <input type="text" value=""/>
                <button type="submit">Sign Up</button>
                <p>Do you have an account already? <Link to="/login">Log in here!</Link></p>
            </div>
        </div>
    )
}