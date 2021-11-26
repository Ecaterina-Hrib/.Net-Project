import "./brHouse.css";
import House from "../../images/house2.jpeg";
import House2 from "../../images/house3.jpeg";
import House3 from "../../images/house4.jpeg";
import HouseCard from "../../components/houseCard/houseCard"
function BrHouse(){
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
    return(
        <div className="brHouse">
            <div className="filters">
                <p>To be done!</p>
            </div>
            <div className="cards">
                {
                    houses.map((house)=>
                        {
                            return <HouseCard house={house}/>             
                        }
                    )
                }
            </div>
        </div>
    );
}
export default BrHouse;