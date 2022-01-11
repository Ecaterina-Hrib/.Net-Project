import "./top10.css";
import { Link } from "react-router-dom";
import Carousel from 'react-bootstrap/Carousel';
export default function Top10() {
    return (
        <div class="top10">

            <div class="carouselContainer">
                <Carousel variant="dark">
                    <Carousel.Item>
                        <div class="box">
                        <div class="row">
                                <div class="houseinfo columns">
                                    <p>HouseTitle</p>
                                    <p>Price</p>
                                    <p>Recommended Price <br/> for Rent</p>
                                    <p>Recommended Price <br/> for Buy</p>
                                    <Link to="./housetemplate/123"><button>View More</button></Link>
                                </div>
                            </div>
                            <div class="row">
                                <div class="houseinfo">
                                    <p>A</p>
                                    <p>B</p>
                                    <p>C</p>
                                    <p>D</p>
                                    <Link to="./housetemplate/123"><button>View More</button></Link>
                                </div>
                            </div>
                            <div class="row">
                                <div class="houseinfo">
                                    <p>A</p>
                                    <p>B</p>
                                    <p>C</p>
                                    <p>D</p>
                                    <Link to="./housetemplate/123"><button>View More</button></Link>
                                </div>
                            </div>
                            <div class="row">
                                <div class="houseinfo">
                                    <p>A</p>
                                    <p>B</p>
                                    <p>C</p>
                                    <p>D</p>
                                    <Link to="./housetemplate/123"><button>View More</button></Link>
                                </div>
                            </div>
                            <div class="row">
                                <div class="houseinfo">
                                    <p>A</p>
                                    <p>B</p>
                                    <p>C</p>
                                    <p>D</p>
                                    <Link to="./housetemplate/123"><button>View More</button></Link>
                                </div>
                            </div>
                            <div class="row">
                                <div class="houseinfo">
                                    <p>A</p>
                                    <p>B</p>
                                    <p>C</p>
                                    <p>D</p>
                                    <Link to="./housetemplate/123"><button>View More</button></Link>
                                </div>
                            </div>
                        </div>
                    </Carousel.Item>
                    <Carousel.Item>
                        <div class="box">
                        <div class="row">
                                <div class="houseinfo columns">
                                    <p>HouseTitle</p>
                                    <p>Price</p>
                                    <p>Recommended Price <br/> for Rent</p>
                                    <p>Recommended Price <br/> for Buy</p>
                                    <Link to="./housetemplate/123"><button>View More</button></Link>
                                </div>
                            </div>
                        <div class="row">
                                <div class="houseinfo">
                                    <p>A</p>
                                    <p>B</p>
                                    <p>C</p>
                                    <p>D</p>
                                    <Link to="./housetemplate/123"><button>View More</button></Link>
                                </div>
                            </div><div class="row">
                                <div class="houseinfo">
                                    <p>A</p>
                                    <p>B</p>
                                    <p>C</p>
                                    <p>D</p>
                                    <Link to="./housetemplate/123"><button>View More</button></Link>
                                </div>
                            </div><div class="row">
                                <div class="houseinfo">
                                    <p>A</p>
                                    <p>B</p>
                                    <p>C</p>
                                    <p>D</p>
                                    <Link to="./housetemplate/123"><button>View More</button></Link>
                                </div>
                            </div><div class="row">
                                <div class="houseinfo">
                                    <p>A</p>
                                    <p>B</p>
                                    <p>C</p>
                                    <p>D</p>
                                    <Link to="./housetemplate/123"><button>View More</button></Link>
                                </div>
                            </div><div class="row">
                                <div class="houseinfo">
                                    <p>A</p>
                                    <p>B</p>
                                    <p>C</p>
                                    <p>D</p>
                                    <Link to="./housetemplate/123"><button>View More</button></Link>
                                </div>
                            </div>
                        </div>
                    </Carousel.Item>
                </Carousel>
            </div>
        </div>
    )
}