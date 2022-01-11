import "./signup.css"
import {Link} from 'react-router-dom';
import {useState} from 'react';
export default function Signup() {

    const [user,setUser] = useState("")
    const [password,setPassword] = useState("")
    const [confPass,setConfPass] = useState("")
    const [email,setEmail] = useState("")
    const handleUser = (e) => {
        setUser(e.target.value);
    }

    const handlePass = (e) => {
        setPassword(e.target.value);
    }
    
    const handleConf= (e) => {
        setConfPass(e.target.value);
    }

    const handleEmail = (e) => {
        setEmail(e.target.value);
    }

    function validation(){
        
    }


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