import React from "react";
import { useParams, useNavigate } from "react-router-dom";
import { Button, Result } from 'antd';

const Index = () => {
    const History = useNavigate();
    const {Messenger,PayStatus,TransactionID,vnp_Amount,vnp_TransactionNo,vnp_TransactionStatus,vnp_TxnRef} = useParams();
    return (
        <Result
        title={Messenger}
        subTitle={`Giao dịch: ${vnp_TxnRef} kết quả thanh toán: ${PayStatus}.`}
        extra={[
          <Button type="primary" key="console" onClick={() => {History('/Payment')}}>
            Trang giao dịch
          </Button>, 
        ]}
      />
    )
}
export default Index;