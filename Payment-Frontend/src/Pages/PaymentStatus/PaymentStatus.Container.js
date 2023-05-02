import React from "react";
import { useParams, useNavigate } from "react-router-dom";
import { Button, Result } from "antd";

const Index = () => {
  const History = useNavigate();
  const {
    Messenger,
    PayStatus,
    TransactionID,
    vnp_Amount,
    vnp_TransactionNo,
    vnp_TransactionStatus,
    vnp_TxnRef,
  } = useParams();
  return (
    <React.Fragment>
      <div
        style={{
          borderBottom: "1px solid #ccc",
          maxWidth: 800,
          margin: "auto",
          marginTop:111
        }}
      >
        <Result
          status={PayStatus == "False" ? "error" : "success"}
          title={Messenger.replaceAll("+", " ")}
          subTitle={`Giao dịch: ${vnp_TxnRef} - Kết quả thanh toán: ${
            PayStatus == "False" ? "Không thành công" : "Thành công"
          }.`}
          extra={[
            <Button
              type="primary"
              key="console"
              onClick={() => {
                History("/Payment");
              }}
            >
              Quay lại
            </Button>,
          ]}
        />
      </div>
    </React.Fragment>
  );
};
export default Index;
