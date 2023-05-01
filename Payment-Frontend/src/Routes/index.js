
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Payment from "../Pages/Payment";
import PaymentStatus from '../Pages/PaymentStatus'

const UserRoutes = () => {
  return (
    <Router>
      <Routes>
        <Route exact={true} path="/Payment" element={<Payment />} />
        <Route  path="/PaymentStatus/:PayStatus/:Messenger/:vnp_TransactionStatus/:vnp_TransactionNo/:TransactionID/:vnp_TxnRef/:vnp_Amount" element={<PaymentStatus />} />
      </Routes>
    </Router>
  );
};

export default UserRoutes;
