import "./login.css"
import {useState} from 'react';
import {Link} from 'react-router-dom';
export default function Login() {

    const [email,setEmail] = useState("")
    const [password,setPassword] = useState("")

    const handleUser = (e) => {
        setEmail(e.target.value);
    }

    const handlePass = (e) => {
        setPassword(e.target.value);
    }

    function validation() {
        if (password === "")
            return "Password is required!"
        if (email === "")
            return "Email is required!"
        if (!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i.test(email))
            return "Please enter a valid email!";
        return undefined;
    }

    let onSubmit = () => {
        let message = validation();
        let loggedIn = localStorage.getItem("loggedIn");
        if(message===undefined&&loggedIn===undefined)
        {
            let data = {
                _email: email,
                _password: password
            }
            console.log(data);
            fetch("http://localhost:5075/login",{
                method: "post",
                body: JSON.stringify(data),
                headers: new Headers({
                    'Content-Type': 'application/json; charset=UTF-8'
                })
            })
            .then(response => response.text())
            .then((data) => {
                data=data.substring(1,data.length-1);
                localStorage.setItem("userID",data);
                localStorage.setItem("loggedIn",true);
                window.location.href="http://localhost:3000/"
            } 
            )
            .catch((err)=>{
                alert(err);
            }
            )
        }
        else
            alert(message);
    }

    return (
        <div class="login">
            <div class="loginbox">
                <label>Email</label>
                <input type="text" value={email} onChange={handleUser}/>
                <label>Password</label>
                <input type="password" value={password} onChange={handlePass}/>
                <button type="submit" onClick={onSubmit}>Log In</button>
                <p>You don't have an account? <Link to="/signup">Sign up here!</Link></p>
            </div>
        </div>
    )
}