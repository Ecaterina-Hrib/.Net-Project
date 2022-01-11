import "./houseTemplate.css";
import House from "../../images/house2.jpeg";
import { useState, useEffect } from "react";

export default function HouseTemplate(props) {
  const [house, setHouse] = useState(null);
  const [user, setUser] = useState(null);

  useEffect(() => {
    if (props.houseID) {
      fetch(`http://localhost:5075/api/v1/houses/${props.houseID}`).then(
        (response) => setHouse(response)
      );
    }
  }, [props.houseID, setHouse]);

  useEffect(() => {
    if (house.username) {
      fetch(`http://localhost:5075/api/v1/users/${house.username}`).then(
        (response) => setUser(response)
      );
    }
  }, [house]);

  return (
    <div className="houseTemplate">
      <div className="topPage">
        <img src={House} alt="houseImage" />
        <div className="rightSide">
          <h3>75.000 euro</h3>
          <button>Buy House</button>
        </div>
      </div>
      <div className="information">
        <div className="characteristics">
          <h2>Characteristics</h2>
          <hr />
          <div className="characteristic">
            <p>House surface</p>
            <p>{house.surface}</p>
          </div>
          <hr />
          <div className="characteristic">
            <p>Land surface</p>
            <p>{house.landSurface}</p>
          </div>
          <hr />
          <div className="characteristic">
            <p>Basement surface</p>
            <p>{house.sqft_basement}</p>
          </div>
          <hr />
          <div className="characteristic">
            <p>No. of rooms</p>
            <p>{house.noOfRooms}</p>
          </div>
          <hr />
          <div className="characteristic">
            <p>No. of bathrooms</p>
            <p>{house.noOfBathrooms}</p>
          </div>
          <hr />
          <div className="characteristic">
            <p>Floor</p>
            <p>{house.floor}</p>
          </div>
          <hr />
          <div className="characteristic">
            <p>Year built</p>
            <p>{house.constructionYear}</p>
          </div>
          <hr />
          <div className="characteristic">
            <p>Year renovated</p>
            <p>{house.yr_renovated}</p>
          </div>
          <hr />
        </div>
        <div className="sellerInformation">
          <h2>Seller Information</h2>
          <hr />
          <div className="info">
            <p>Username</p>
            <p>{user.username}</p>
          </div>
          <hr />
          <div className="info">
            <p>Email address</p>
            <p>{user.email}</p>
          </div>
          <hr />
        </div>
      </div>
    </div>
  );
}
