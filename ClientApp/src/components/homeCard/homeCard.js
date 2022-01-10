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
                        <div className="photoContainer">
                            <div className="backgroundText">
                                <p>Welcome to the page!</p>
                            </div>
                            <img src={House2} alt="b"/>
                        </div>
                    </Carousel.Item>
                    <Carousel.Item>
                        <div className="photoContainer">
                            <div className="backgroundText">
                                <div>
                                    <p>Welcome to the page!</p>
                                </div>
                            </div>
                            <img src={House3} alt="a"/>
                        </div>
                    </Carousel.Item>
                    <Carousel.Item>
                        <div className="photoContainer">   
                            <div className="backgroundText">
                                <p>Welcome to the page!</p>
                            </div>
                            <img src={House4} alt="a"/>
                        </div>
                    </Carousel.Item>
                    <Carousel.Item>       
                        <div className="photoContainer">
                            <div className="backgroundText">
                                <p>Welcome to the page!</p>
                            </div>
                            <img src={House5} alt="a"/>
                        </div>
                    </Carousel.Item>
                </Carousel>
            </div>
        </div>
    );
}
export default HomeCard;