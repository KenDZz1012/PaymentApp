import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Payment from "../Pages/Payment";

const UserRoutes = () => {
  return (
    <Router>
      <Routes>
        <Route exact={true} path="/Payment" element={<Payment />} />
      </Routes>
    </Router>
  );
};

export default UserRoutes;
