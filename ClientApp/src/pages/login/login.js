import "./login.css"
import {useState} from 'react';
import {Link} from 'react-router-dom';
export default function Login() {

    const [user,setUser] = useState("")
    const [password,setPassword] = useState("")

    const handleUser = (e) => {
        setUser(e.target.value);
    }

    const handlePass = (e) => {
        setPassword(e.target.value);
    }

    const onSubmit = () => {
        
    }

    return (
        <div class="login">
            <div class="loginbox">
                <label>Username</label>
                <input type="text" value="" onChange={handleUser}/>
                <label>Password</label>
                <input type="text" value="" onChange={handlePass}/>
                <button type="submit" onClick={onSubmit}>Log In</button>
                <p>You don't have an account? <Link to="/signup">Sign up here!</Link></p>
            </div>
        </div>
    )
}