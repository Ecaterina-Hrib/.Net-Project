import "./App.css";
import Navbar from "./components/navbar/navbar";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Home from './pages/Home';
import 'bootstrap/dist/css/bootstrap.min.css';
import BrHouse from "./pages/BRHouse/brHouse";
function App() {
  return (
    <>
      <BrowserRouter>
        <Navbar />
        <Routes>
          <Route path="/" element={<Home/>}/>
          <Route path="/buy" element={<BrHouse/>}/>
          <Route path="/login" />
          <Route path="/signup" />
          <Route path="/displayHouses" />
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;
