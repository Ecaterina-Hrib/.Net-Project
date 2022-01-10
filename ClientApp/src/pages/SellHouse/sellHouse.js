import "./sellHouse.css";
import React, {useState} from "react";
import {setNestedObjectValues, useFormik} from 'formik';
function SellHouse(){
    const [selectedImage, setSelectedImage] = useState(null);

    const readLoad= x => {
        let object = {};
        const reader = new FileReader();
        reader.readAsDataURL(x);
        reader.onload = x => {
            object = {imageFile: x, imageSrc: reader.result}
        }
        return object;
    }

    const formik = useFormik({
        initialValues: {
            username: '',
            description: '',
            title: '',
            city: '',
            country: '',
            address: '',
            latitude: 0,
            longitude: 0,
            constructionYear: 0,
            noOfRooms: 0,
            floor: 0,
            surface: 0,
            landSurface: 0,
            noOfBathrooms: 0,
            view: 0,
            condition: 0,
            grade: 0,
            sqft_basement: 0,
            yr_renovated: 0,
            zipcode: 0,
            currentPrice: 0,
    },
        onSubmit: values =>{
            let x = {imageFile: selectedImage, ...values};
            console.log(JSON.stringify(x));
        }
    });

    return(
        <div class="sellHouse">
            <div class="imagePicker">
                {selectedImage && (
                    <div class="imageContainer">
                            <img name="imageURL" class="imageSelected" alt="Not found" src={URL.createObjectURL(selectedImage)} />
                        <br />
                        <button onClick={()=>setSelectedImage(null)}>Remove</button>
                    </div>
                )}
                <input type="file"
                       onChange={(event)=>{
                          setSelectedImage(event.target.files[0]);
                       }} />
            </div>
            <div class="infoFormWithSubmit">
                <div class="infoForm">
                    <div class="infoColumn">
                        <input type="text" placeholder="Numele resedintei" name="title" onChange={formik.handleChange}/>
                        <input type="text" placeholder="Descriere" name="description" onChange={formik.handleChange}/>
                        <input type="text" placeholder="Oras" name="city" onChange={formik.handleChange}/>
                        <input type="text" placeholder="Tara" name="country" onChange={formik.handleChange}/>
                        <input type="text" placeholder="Adresa" name="address" onChange={formik.handleChange}/>
                        <input type="text" placeholder="Latitudine" name="latitude" onChange={formik.handleChange}/>
                        <input type="text" placeholder="Longitudine" name="longitude" onChange={formik.handleChange}/>
                        <input type="text" placeholder="Anul constructiei" name="constructionYear" onChange={formik.handleChange}/>
                        <input type="text" placeholder="Numarul de camere" name="noOfRooms" onChange={formik.handleChange}/>
                        <input type="text" placeholder="Etaj" name="floor" onChange={formik.handleChange}/>
                    </div>
                    <div class="infoColumn">
                        <input type="text" placeholder="Suprafata" name="surface" onChange={formik.handleChange}/>
                        <input type="text" placeholder="Suprafata terenului" name="landSurface" onChange={formik.handleChange}/>
                        <input type="text" placeholder="Numarul de bai" name="noOfBathrooms" onChange={formik.handleChange}/>
                        <input type="text" placeholder="Nota privelistii" name="view" onChange={formik.handleChange}/>
                        <input type="text" placeholder="Conditie locuinta" name="condition" onChange={formik.handleChange}/>
                        <input type="text" placeholder="Nota per total" name="grade" onChange={formik.handleChange}/>
                        <input type="text" placeholder="Suprafata basementului" name="sqft_basement" onChange={formik.handleChange}/>
                        <input type="text" placeholder="Anul renovarii" name="yr_renovated" onChange={formik.handleChange}/>
                        <input type="text" placeholder="Cod postal" name="zipcode" onChange={formik.handleChange}/>
                        <input type="text" placeholder="Pretul casei (euro)" name="currentPrice" onChange={formik.handleChange}/>
                    </div>
                </div>
                <div class="submitButton">
                    <button onClick={formik.handleSubmit} type="submit">Submit</button>
                </div>
            </div>
        </div>
    )
}
export default SellHouse;