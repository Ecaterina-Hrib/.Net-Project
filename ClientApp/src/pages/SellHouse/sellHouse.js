import "./sellHouse.css";
import React, { useState } from "react";

const initialState = {
  _description: "",
  _title: "",
  _city: "",
  _country: "",
  _address: "",
  _latitude: null,
  _longitude: null,
  _constructionYear: null,
  _noOfRooms: null,
  _floor: null,
  _surface: null,
  _landSurface: null,
  _noOfBathrooms: null,
  _view: null,
  _condition: null,
  _grade: null,
  _sqft_basement: null,
  _yr_renovated: null,
  _zipcode: null,
  _currentPrice: null,
};

function SellHouse() {
  const [info, setInfo] = useState(initialState);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setInfo({
      ...info,
      [name]: value,
    });
  };

  const showPreview = (e) => {
    if (e.target.files && e.target.files[0]) {
      let imageFile = e.target.files[0];
      const reader = new FileReader();
      reader.onload = (x) => {
        setInfo({
          ...info,
          imageFile: imageFile,
          imageSrc: x.target.result,
        });
      };
      reader.readAsDataURL(imageFile);
    } else {
      setInfo({
        ...info,
        imageSrc: "",
        imageFile: null,
      });
    }
  };

  let handleFormSubmit = () => {
    console.log(info);
    fetch(`http://localhost:5075/api/v1/houses/?username=${localStorage.getItem("username")}`, {
      method: "post",
      body: JSON.stringify(info),
      headers: new Headers({
        'Content-Type': 'application/json; charset=UTF-8'
      })
    })
      .then(response => response.json())
      .then((data) => {
        alert("You have added a house here!")
        alert(`We recommend you the price of ${data.rent_price} for rent and ${data.sell_price} for selling`)
        window.location.href = "http://localhost:3000/"
      }
      )
      .catch((err) => {
        alert(err);
      }
      )
}

    return (
      <div class="sellHouse">
        <div class="formContainer">
          <div class="imagePicker">
            {info.imageFile && (
              <div class="imageContainer">
                <img
                  name="imageURL"
                  class="imageSelected"
                  alt="Not found"
                  src={info.imageSrc}
                />
                <br />
                <button>
                  Remove
                </button>
              </div>
            )}
            <input
              type="file"
              onChange={(event) => {
                showPreview(event);
              }}
            />
          </div>
          <div class="infoFormWithSubmit">
            <div class="infoForm">
              <div class="infoColumn">
                <input
                  type="text"
                  placeholder="Residence name"
                  name="_title"
                  value={info._title}
                  onChange={handleInputChange}
                />
                <input
                  type="text"
                  placeholder="Description"
                  name="_description"
                  value={info._description}
                  onChange={handleInputChange}
                />
                <input
                  type="text"
                  placeholder="City"
                  name="_city"
                  value={info._city}
                  onChange={handleInputChange}
                />
                <input
                  type="text"
                  placeholder="Country"
                  name="_country"
                  value={info._country}
                  onChange={handleInputChange}
                />
                <input
                  type="text"
                  placeholder="Address"
                  name="_address"
                  value={info._address}
                  onChange={handleInputChange}
                />
                <input
                  type="text"
                  placeholder="Latitude"
                  name="_latitude"
                  value={info._latitude}
                  onChange={handleInputChange}
                />
                <input
                  type="text"
                  placeholder="Longitude"
                  name="_longitude"
                  value={info._longitude}
                  onChange={handleInputChange}
                />
                <input
                  type="text"
                  placeholder="Year built"
                  name="_constructionYear"
                  value={info._constructionYear}
                  onChange={handleInputChange}
                />
                <input
                  type="text"
                  placeholder="No. of rooms"
                  name="_noOfRooms"
                  value={info._noOfRooms}
                  onChange={handleInputChange}
                />
                <input
                  type="text"
                  placeholder="Floor"
                  name="_floor"
                  value={info._floor}
                  onChange={handleInputChange}
                />
              </div>
              <div class="infoColumn">
                <input
                  type="text"
                  placeholder="Surface"
                  name="_surface"
                  value={info._surface}
                  onChange={handleInputChange}
                />
                <input
                  type="text"
                  placeholder="Land surface"
                  name="_landSurface"
                  value={info._landSurface}
                  onChange={handleInputChange}
                />
                <input
                  type="text"
                  placeholder="No. of bathrooms"
                  name="_noOfBathrooms"
                  value={info._noOfBathrooms}
                  onChange={handleInputChange}
                />
                <input
                  type="text"
                  placeholder="View"
                  name="_view"
                  value={info._view}
                  onChange={handleInputChange}
                />
                <input
                  type="text"
                  placeholder="Condition"
                  name="_condition"
                  value={info._condition}
                  onChange={handleInputChange}
                />
                <input
                  type="text"
                  placeholder="Grade"
                  name="_grade"
                  value={info._grade}
                  onChange={handleInputChange}
                />
                <input
                  type="text"
                  placeholder="Basement surface"
                  name="_sqft_basement"
                  value={info._sqft_basement}
                  onChange={handleInputChange}
                />
                <input
                  type="text"
                  placeholder="Year renovated"
                  name="_yr_renovated"
                  value={info._yr_renovated}
                  onChange={handleInputChange}
                />
                <input
                  type="text"
                  placeholder="Zipcode"
                  name="_zipcode"
                  value={info._zipcode}
                  onChange={handleInputChange}
                />
                <input
                  type="text"
                  placeholder="Price (euro)"
                  name="_currentPrice"
                  value={info._currentPrice}
                  onChange={handleInputChange}
                />
              </div>
            </div>
            <div class="submitButton">
              <button type="submit" onClick={handleFormSubmit}>Submit</button>
            </div>
          </div>
        </div>
      </div>
    );
}
export default SellHouse;
