import "./brHouse.css";
import { useEffect, useState } from 'react';
import HouseCard from "../../components/houseCard/houseCard"
function BrHouse() {
    const [houses, setHouses] = useState([])

    useEffect(() => {
            fetch("http://localhost:5075/api/v1/houses/all")
            .then((response)=>response.json())
            .then((data)=>{
                data.map((house)=> setHouses(houses=>[...houses,house]));
            })
    },[])



    const [noOfRooms, setNoOfRooms] = useState(8);
    const [noOfBaths, setNoOfBaths] = useState(2);
    const [price, setPrice] = useState(250000);
    const [surface, setSurface] = useState(1000);
    const [floors, setFloors] = useState(3);

    const handleChangeRooms = (e) => setNoOfRooms(e.target.value)
    const handleChangeBaths = (e) => setNoOfBaths(e.target.value)
    const handleChangePrice = (e) => setPrice(e.target.value)
    const handleChangeSurface = (e) => setSurface(e.target.value)
    const handleChangeFloors = (e) => setFloors(e.target.value)

    const handleSubmit = () => {
        
    }

    return (
        <div className="brHouse">
            <div className="filters">
                <div className="filterBox">
                    <div className="sliderContainer">
                        <label>
                            Numar de camere
                        </label>
                        <div className="cont">
                            <input type="range" min={0} max={16} value={noOfRooms} onChange={handleChangeRooms} className="slider" />
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
                            <input type="range" min={0} max={6} value={floors} onChange={handleChangeFloors} className="slider" />
                            <div className="value">{floors}</div>
                        </div>
                    </div>
                    <div className="sliderContainer">
                            <button type="submit" onClick={handleSubmit}>Submit</button>
                    </div>
                </div>
            </div>
            <div className="cards">
                {
                    
                        houses.map((house,index) => {
                        if(index%3===0)
                        return (<><HouseCard house={house} /> <br/></>)
                        else
                            return (<HouseCard house={house} />)
                    })
                }
            </div>
        </div>
    );
}
export default BrHouse;