import "./homeCard.css";
import Carousel from 'react-bootstrap/Carousel';
import House2 from '../../images/house2.jpeg';
import House3 from '../../images/house3.jpeg';
import House4 from '../../images/house4.jpeg';
import House5 from '../../images/house5.jpeg';

function HomeCard(){
    return(
        <div className="carouselHome">
            <div className="background">
                <Carousel>
                    <Carousel.Item>
                       <p>Welcome to House Shop!</p>
                        <div className="photoContainer">
                            <img src={House5}/>
                            <img src={House2}/>
                        </div>
                    </Carousel.Item>
                    <Carousel.Item>
                        <p>Welcome to House Shop!</p>
                        <div className="photoContainer">
                                <img src={House3}/>
                                <img src={House4}/>
                        </div>
                    </Carousel.Item>
                </Carousel>
            </div>
        </div>
    );
}
export default HomeCard;