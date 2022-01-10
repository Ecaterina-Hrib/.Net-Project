import './houseCard.css';
import {Link} from "react-router-dom";
function HouseCard(props){
    return(
        <div className="cardStyle">
            <img src={props.house.image} alt="House"/>
            <p>Owned by: {props.house.owner} </p>
            <p>Surface: {props.house.surface}</p>
            <p>Type: {props.house.apartament} </p>
            <p>Number of rooms: {props.house.nrofrooms}</p>
            <div className="buttons">
                <Link to="/housetemplate/123">
                    <button className="buyButton">View More</button>
                </Link>
            </div>
        </div>
           );
}
export default HouseCard;