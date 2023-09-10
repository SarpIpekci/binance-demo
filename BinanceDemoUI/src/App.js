import BinanceNavBar from "../src/components/Navbar/BinanceNavBar";
import BarChartComponent from "./components/Charts/BarChartComponent";
import SignIn from "./components/Login/SignIn/SignInComponent";
import { NavLink, Route, Routes } from "react-router-dom";

function App() {
  return (
    <>
      <BinanceNavBar />
      <div className="container-sm">
        <Routes>
          <Route path="/" element={<BarChartComponent />} />
          <Route path="/SignIn" element={<SignIn />} />
        </Routes>
      </div>
    </>
  );
}

export default App;
