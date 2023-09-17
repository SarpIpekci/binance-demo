import BinanceNavBar from "../src/components/Navbar/BinanceNavBar";
import BarChartComponent from "./components/Charts/BarChartComponent";
import SignIn from "./components/Login/SignIn/SignInComponent";
import SignUp from "./components/Login/SignUp/SignUpComponent";
import { Route, Routes } from "react-router-dom";

function App() {
  return (
    <>
      <BinanceNavBar />
      <div className="container-sm">
        <Routes>
          <Route path="/" element={<BarChartComponent />} />
          <Route path="/SignIn" element={<SignIn />} />
          <Route path="/SignUp" element={<SignUp />} />
        </Routes>
      </div>
    </>
  );
}

export default App;
