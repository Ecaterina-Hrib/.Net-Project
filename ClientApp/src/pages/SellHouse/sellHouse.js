import "./sellHouse.css";
import React, { useState } from "react";

const initialState = {
  username: "",
  description: "",
  title: "",
  city: "",
  country: "",
  address: "",
  latitude: null,
  longitude: null,
  constructionYear: null,
  noOfRooms: null,
  floor: null,
  surface: null,
  landSurface: null,
  noOfBathrooms: null,
  view: null,
  condition: null,
  grade: null,
  sqft_basement: null,
  yr_renovated: null,
  zipcode: null,
  currentPrice: null,
  imageSrc: "",
  imageFile: null,
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

  const handleFormSubmit = (e) => {
    e.preventDefault();
    const formData = new FormData();
    formData.append("username", info.username);
    formData.append("description", info.description);
    formData.append("title", info.title);
    formData.append("city", info.city);
    formData.append("country", info.country);
    formData.append("address", info.address);
    formData.append("latitude", info.latitude);
    formData.append("longitude", info.longitude);
    formData.append("constructionYear", info.constructionYear);
    formData.append("noOfRooms", info.noOfRooms);
    formData.append("floor", info.floor);
    formData.append("surface", info.surface);
    formData.append("landSurface", info.landSurface);
    formData.append("noOfBathrooms", info.noOfBathrooms);
    formData.append("view", info.view);
    formData.append("condition", info.condition);
    formData.append("grade", info.grade);
    formData.append("sqft_basement", info.sqft_basement);
    formData.append("yr_renovated", info.yr_renovated);
    formData.append("zipcode", info.zipcode);
    formData.append("currentPrice", info.currentPrice);
    formData.append("imageSrc", info.imageSrc);
    formData.append("imageFile", info.imageFile);
  };

  return (
    <div class="sellHouse">
      <form onSubmit={(e) => handleFormSubmit}>
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
              <button
                onClick={() => setInfo({ imageSrc: "", imageFile: null })}
              >
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
                name="title"
                value={info.title}
                onChange={handleInputChange}
              />
              <input
                type="text"
                placeholder="Description"
                name="description"
                value={info.description}
                onChange={handleInputChange}
              />
              <input
                type="text"
                placeholder="City"
                name="city"
                value={info.city}
                onChange={handleInputChange}
              />
              <input
                type="text"
                placeholder="Country"
                name="country"
                value={info.country}
                onChange={handleInputChange}
              />
              <input
                type="text"
                placeholder="Address"
                name="address"
                value={info.address}
                onChange={handleInputChange}
              />
              <input
                type="text"
                placeholder="Latitude"
                name="latitude"
                value={info.latitude}
                onChange={handleInputChange}
              />
              <input
                type="text"
                placeholder="Longitude"
                name="longitude"
                value={info.longitude}
                onChange={handleInputChange}
              />
              <input
                type="text"
                placeholder="Year built"
                name="constructionYear"
                value={info.constructionYear}
                onChange={handleInputChange}
              />
              <input
                type="text"
                placeholder="No. of rooms"
                name="noOfRooms"
                value={info.noOfRooms}
                onChange={handleInputChange}
              />
              <input
                type="text"
                placeholder="Floor"
                name="floor"
                value={info.floor}
                onChange={handleInputChange}
              />
            </div>
            <div class="infoColumn">
              <input
                type="text"
                placeholder="Surface"
                name="surface"
                value={info.surface}
                onChange={handleInputChange}
              />
              <input
                type="text"
                placeholder="Land surface"
                name="landSurface"
                value={info.landSurface}
                onChange={handleInputChange}
              />
              <input
                type="text"
                placeholder="No. of bathrooms"
                name="noOfBathrooms"
                value={info.noOfBathrooms}
                onChange={handleInputChange}
              />
              <input
                type="text"
                placeholder="View"
                name="view"
                value={info.view}
                onChange={handleInputChange}
              />
              <input
                type="text"
                placeholder="Condition"
                name="condition"
                value={info.condition}
                onChange={handleInputChange}
              />
              <input
                type="text"
                placeholder="Grade"
                name="grade"
                value={info.grade}
                onChange={handleInputChange}
              />
              <input
                type="text"
                placeholder="Basement surface"
                name="sqft_basement"
                value={info.sqft_basement}
                onChange={handleInputChange}
              />
              <input
                type="text"
                placeholder="Year renovated"
                name="yr_renovated"
                value={info.yr_renovated}
                onChange={handleInputChange}
              />
              <input
                type="text"
                placeholder="Zipcode"
                name="zipcode"
                value={info.zipcode}
                onChange={handleInputChange}
              />
              <input
                type="text"
                placeholder="Price (euro)"
                name="currentPrice"
                value={info.currentPrice}
                onChange={handleInputChange}
              />
            </div>
          </div>
          <div class="submitButton">
            <button type="submit">Submit</button>
          </div>
        </div>
      </form>
    </div>
  );
}
export default SellHouse;
