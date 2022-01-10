import "./houseTemplate.css";
import House from "../../images/house2.jpeg";
export default function HouseTemplate({ props }){

    return(
        <div className='houseTemplate'>
            <div className='topPage'>
                <img src={House} alt='houseImage' />
                <div className='rightSide'>
                    <h3>75.000 euro</h3>
                    <button>Buy House</button>
                </div>
            </div>
            <div className='information'>
                <div className='characteristics'>
                    <h2>Characteristics</h2>
                    <hr />
                    <div className='characteristic'>
                        <p>House surface</p>
                    </div>
                    <hr />
                    <div className='characteristic'>
                        <p>Land surface</p>
                    </div>
                    <hr />
                    <div className='characteristic'>
                        <p>Basement surface</p>
                    </div>
                    <hr />
                    <div className='characteristic'>
                        <p>No. of bedrooms</p>
                    </div>
                    <hr />
                    <div className='characteristic'>
                        <p>No. of bathrooms</p>
                    </div>
                    <hr />
                    <div className='characteristic'>
                        <p>No. of floors</p>
                    </div>
                    <hr />
                    <div className='characteristic'>
                        <p>Year built</p>
                    </div>
                    <hr />
                    <div className='characteristic'>
                        <p>Year renovated</p>
                    </div>
                    <hr />
                </div>
                <div className='sellerInformation'>
                    <h2>Seller Information</h2>
                    <hr />
                    <div className='info'>
                        <p>Name</p>
                    </div>
                    <hr />
                    <div className='info'>
                        <p>Phone number</p>
                    </div>
                    <hr />
                    <div className='info'>
                        <p>Email address</p>
                    </div>
                    <hr />
                </div>
            </div>
        </div>
    )
};