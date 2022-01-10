import "./brHouse.css";
import { useState } from 'react';
import House from "../../images/house2.jpeg";
import House2 from "../../images/house3.jpeg";
import House3 from "../../images/house4.jpeg";
import HouseCard from "../../components/houseCard/houseCard"
function BrHouse() {
    const houses = [
        {
            owner: "Mihai Lucifer",
            surface: "150m2",
            type: "Apartament",
            nrofrooms: "4",
            image: House
        },
        {
            owner: "Mihai Lucifer",
            surface: "175m2",
            type: "House",
            nrofrooms: "6",
            image: House2
        },
        {
            owner: "Mihai Lucifer",
            surface: "250m2",
            type: "Hotel",
            nrofrooms: "8",
            image: House3
        },
    ];

    const [noOfRooms, setNoOfRooms] = useState(7);
    const [noOfBaths, setNoOfBaths] = useState(2);
    const [price, setPrice] = useState(100);
    const [surface, setSurface] = useState(100);
    const [floors, setFloors] = useState(3);

    const handleChangeRooms = (e) => setNoOfRooms(e.target.value)
    const handleChangeBaths = (e) => setNoOfBaths(e.target.value)
    const handleChangePrice = (e) => setPrice(e.target.value)
    const handleChangeSurface = (e) => setSurface(e.target.value)
    const handleChangeFloors = (e) => setFloors(e.target.value)

    return (
        <div className="brHouse">
            <div className="filters">
                <div className="filterBox">
                    <div className="sliderContainer">
                        <label>
                            Numar de camere
                        </label>
                        <div className="cont">
                            <input type="range" min={0} max={15} value={noOfRooms} onChange={handleChangeRooms} className="slider" />
                            <div className="value">{noOfRooms}</div>
                        </div>
                    </div>
                    <div className="sliderContainer">
                        <label>
                            Numar de bai
                        </label>
                        <div className="cont">
                            <input type="range" min={0} max={4} value={noOfBaths} onChange={handleChangeBaths} className="slider" />
                            <div className="value">{noOfBaths}</div>
                        </div>
                    </div>
                    <div className="sliderContainer">
                        <label>
                            Pret
                        </label>
                        <div className="cont">
                            <input type="range" min={0} max={500000} value={price} onChange={handleChangePrice} className="slider" />
                            <div className="value">{price}</div>
                        </div>
                    </div>
                    <div className="sliderContainer">
                        <label>
                            Suprafata
                        </label>
                        <div className="cont">
                            <input type="range" min={0} max={2000} value={surface} onChange={handleChangeSurface} className="slider" />
                            <div className="value">{surface}</div>
                        </div>
                    </div>
                    <div className="sliderContainer">
                        <label>
                            Etaje
                        </label>
                        <div className="cont">
                            <input type="range" min={0} max={5} value={floors} onChange={handleChangeFloors} className="slider" />
                            <div className="value">{floors}</div>
                        </div>
                    </div>
                    <div className="sliderContainer">
                            <button>Submit</button>
                    </div>
                </div>
            </div>
            <div className="cards">
                {
                    houses.map((house) => {
                        return (<HouseCard house={house} />)
                    }
                    )
                }
            </div>
        </div>
    );
}
export default BrHouse;