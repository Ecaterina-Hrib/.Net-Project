import './houseCard.css';
import {Link} from "react-router-dom";
import House from "../../images/house4.jpeg";
function HouseCard(props){
    return(
        <div className="cardStyle">
            <img src={House} alt="House"/>
            <p>Title: {props._title} </p>
            <p>Surface: {props._surface}</p>
            <p>Number of rooms: {props._nrofrooms}</p>
            <p>Description: {props._description}</p>
            <div className="buttons">
                <Link to={"/housetemplate/"+ props._id}>
                    <button className="buyButton">View More</button>
                </Link>
            </div>
        </div>
           );
}
export default HouseCard;