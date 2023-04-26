import React from "react";
import { Radio, Space, Tabs } from "antd";
import PaymentForm from "./PaymentForm";
import PaymentList from "./PaymentList";
const PaymentContainer = () => {
  const tabList = [
    {
      key: "tab1",
      label: "Tạo mới hóa đơn",
      children: <PaymentForm />,
    },
    {
      key: "tab2",
      label: "Danh sách hóa đơn",
      children: <PaymentList />,
    },
  ];
  return (
    <React.Fragment>
      <div style={{ maxWidth: 800, margin: "auto" }}>
        <Tabs defaultActiveKey="1" items={tabList} />{" "}
      </div>
    </React.Fragment>
  );
};

export default PaymentContainer;
