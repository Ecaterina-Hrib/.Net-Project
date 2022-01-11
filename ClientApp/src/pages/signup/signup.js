import "./signup.css"
import { Link } from 'react-router-dom';
import { useState } from 'react';
export default function Signup() {

    const [name, setName] = useState("")
    const [user, setUser] = useState("")
    const [password, setPassword] = useState("")
    const [confPass, setConfPass] = useState("")
    const [email, setEmail] = useState("")

    const handleName = (e) => {
        setName(e.target.value);
    }
    const handleUser = (e) => {
        setUser(e.target.value);
    }

    const handlePass = (e) => {
        setPassword(e.target.value);
    }

    const handleConf = (e) => {
        setConfPass(e.target.value);
    }

    const handleEmail = (e) => {
        setEmail(e.target.value);
    }

    function validation() {
        if (name === "")
            return "Name is required!"
        if (password === "")
            return "Password is required!"
        if (confPass === "")
            return "Please confirm the password properly!"
        if (user === "")
            return "Username is required!"
        if (email === "")
            return "Email is required!"
        if (password !== confPass)
            return "The passwords don't match!";
        if (!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i.test(email))
            return "Please enter a valid email!";
        return undefined;
    }

    let handleSubmit = () => {
        let message = validation();
        let loggedIn = localStorage.getItem("loggedIn")
        if(message===undefined&&loggedIn===undefined)
        {
            let data = {
                _name: name,
                _username: user,
                _email: email,
                _password: password
            }
            console.log(data);
            fetch("http://localhost:5075/signup",{
                method: "post",
                body: JSON.stringify(data),
                headers: new Headers({
                    'Content-Type': 'application/json; charset=UTF-8'
                })
            })
            .then(response => console.log(response.text()))
            .then(() => {
                alert("You have successfully created an account here!")    
                window.location.href= "http://localhost:3000/login"
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
        <div className="signup">
            <div className="signupbox">
                <label>Name</label>
                <input type="text" value={name} onChange={handleName}/>
                <label>E-mail</label>
                <input type="text" value={email} onChange={handleEmail} />
                <label>Username</label>
                <input type="text" value={user} onChange={handleUser} />
                <label>Password</label>
                <input type="password" value={password} onChange={handlePass} />
                <label>Confirm Password</label>
                <input type="password" value={confPass} onChange={handleConf} />
                <button type="submit" onClick={handleSubmit}>Sign Up</button>
                <p>Do you have an account already? <Link to="/login">Log in here!</Link></p>
            </div>
        </div>
    )
}