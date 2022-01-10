import "./login.css"
import {Link} from 'react-router-dom';
export default function Login() {
    return (
        <div class="login">
            <div class="loginbox">
                <label>Username</label>
                <input type="text" />
                <label>Password</label>
                <input type="text" />
                <button type="submit">Log In</button>
                <p>You don't have an account? <Link to="/signup">Sign up here!</Link></p>
            </div>
        </div>
    )
}