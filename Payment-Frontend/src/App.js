import logo from "./logo.svg";
import "./App.css";
import UserRoutes from "./Routes";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import PaymentForm from "./Pages/Payment/PaymentForm";

function App() {
  return (
    <div className="App">
      <UserRoutes/>
    </div>
  );
}

export default App;
