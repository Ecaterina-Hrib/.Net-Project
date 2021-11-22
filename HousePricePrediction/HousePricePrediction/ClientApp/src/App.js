import "./App.css";
import Navbar from "./components/navbar/navbar";
import { BrowserRouter, Route, Routes } from "react-router-dom";
function App() {
  return (
    <>
      <BrowserRouter>
        <Navbar />
        <Routes>
          <Route path="/" />
          <Route path="/login" />
          <Route path="/signup" />
          <Route path="/displayHouses" />
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;
