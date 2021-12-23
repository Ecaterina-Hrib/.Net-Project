import './houseCard.css';
function HouseCard(props){
    return(
        <div className="cardStyle">
            <img src={props.house.image} alt="House"/>
            <p>Owned by: {props.house.owner} </p>
            <p>Surface: {props.house.surface}</p>
            <p>Type: {props.house.apartament} </p>
            <p>Number of rooms: {props.house.nrofrooms}</p>
            <div className="buttons">
                <button className="buyButton">Buy</button>
                <button className="rentButton">Rent</button>
            </div>
        </div>
           );
}
export default HouseCard;