import "./App.css";
import Navbar from "./components/navbar/navbar";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Home from './pages/Home';
import 'bootstrap/dist/css/bootstrap.min.css';
import BrHouse from "./pages/BRHouse/brHouse";
import SellHouse from "./pages/SellHouse/sellHouse";
import Login from "./pages/login/login";
import Signup from "./pages/signup/signup";
import Top10 from "./pages/top10/top10";
import HouseTemplate from "./pages/houseTemplate/houseTemplate";
import MyProfile from "./pages/myProfile/myProfile";
import EditProfile from "./pages/editProfile/editProfile";

function App() {
  return (
    <>
      <BrowserRouter>
        <Navbar />
        <Routes>
          <Route path="/" element={<Home/>}/>
          <Route path="/buy" element={<BrHouse/>}/>
          <Route path="/sell" element={<SellHouse/>}/>
          <Route path="/login" element={<Login/>} />
          <Route path="/signup" element={<Signup/>}/>
          <Route path="/ourRecommandations" element={<Top10/>} />
          <Route path="/housetemplate/:id" element={<HouseTemplate/>} />
          <Route path="/profile" element={<MyProfile/>}/>
          <Route path="/profile/edit" element={<EditProfile/>}/>
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;
