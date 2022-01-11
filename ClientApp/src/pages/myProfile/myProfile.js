import "./myProfile.css"
import {ReactComponent as Edit} from "../../images/edit.svg"
import {Link} from "react-router-dom";
import { useEffect, useState } from "react";
export default function MyProfile(){
    let userId = localStorage.getItem("userID");
    const [user, setUser] = useState("")
    const [name, setName] = useState("")
    const [email, setEmail] = useState("")
    const [phone, setPhone] = useState(0)
    const [total, setTotal] = useState(0)
    useEffect(()=>{
                fetch(`http://localhost:5075/api/v1/users/${userId}`)
                .then((response) => response.json())
                .then((data) => {
                    setUser(data._username)
                    setName(data._name)
                    setEmail(data._email)
                    setPhone(data._phoneNumber)
                    setTotal(data._totalViews)
            })
    },[])

    return(
        <div className="myProfile">
            <div>
                <div className="line">
                    <h1>{user}</h1>
                    <Link to="/profile/edit">
                        <div className="svgButton"><Edit/></div>
                    </Link>
                </div>
                <hr/>
            </div>
            <div className="userDetails">
                <p>Name:{name}</p>
                <p>E-mail:{email} </p>
                <p>Phone Number:{phone} </p>
                <p>Total number of views of the houses:{total}</p>
            </div>
        </div>
    )
}