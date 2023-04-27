import React, { useEffect, useState } from "react";
import { Button, Form, Input, InputNumber, Select } from "antd";
import { postPayment } from "../../Helpers/app-backend/payment_backend_helper";
const { Option } = Select;
const { TextArea } = Input;

const layout = {
  labelCol: {
    span: 8,
  },
  wrapperCol: {
    span: 16,
  },
};
const PaymentForm = () => {
  const formRef = React.useRef(null);
  const [modal, setModal] = useState(false);
  const [dataResponse, setDataResponse] = useState(null);
  const onFinish = async (values) => {
    values.ipAddress = "";
    await postPayment(values).then((res) => {
      console.log(res)
      setDataResponse(res);
      setModal(true);
    });
  };
  return (
    <React.Fragment>
      <div style={{ borderBottom: "1px solid #ccc" }}>
        <h2>Tạo mới đơn hàng</h2>
        <Form
          {...layout}
          ref={formRef}
          onFinish={onFinish}
          name="control-ref"
          style={{
            maxWidth: 800,
            margin: "auto",
          }}
        >
          <Form.Item
            name="orderType"
            label="Loại hàng hóa"
            labelCol={{ span: 24 }}
            wrapperCol={{ span: 24 }}
            rules={[
              {
                required: true,
              },
            ]}
          >
            <Select allowClear>
              <Option value="Nạp tiền điện thoại">Nạp tiền điện thoại</Option>
              <Option value="Thanh toán hóa đơn">Thanh toán hóa đơn</Option>
              <Option value="Thời trang">Thời trang</Option>
            </Select>
          </Form.Item>

          <Form.Item
            name="amount"
            label="Số tiền"
            labelCol={{ span: 24 }}
            wrapperCol={{ span: 24 }}
          >
            <InputNumber
              style={{ width: "100%" }}
              defaultValue={0}
              formatter={(value) =>
                `${value}`.replace(/\B(?=(\d{3})+(?!\d))/g, ",")
              }
              parser={(value) => value.replace(/\$\s?|(,*)/g, "")}
              onChange={(val) => {
                formRef.current?.setFieldsValue({
                  amount: val,
                });
              }}
            />{" "}
          </Form.Item>

          <Form.Item
            labelCol={{ span: 24 }}
            wrapperCol={{ span: 24 }}
            name="orderInfo"
            label="Nội dung thanh toán"
          >
            <TextArea
              onChange={(val) => {
                formRef.current?.setFieldsValue({
                  orderInfo: val.target.value,
                });
              }}
            />{" "}
          </Form.Item>

          <Form.Item
            name="Bank"
            label="Ngân hàng"
            labelCol={{ span: 24 }}
            wrapperCol={{ span: 24 }}
            rules={[
              {
                required: true,
              },
            ]}
          >
            <Select allowClear>
              <Option value="0">BIDV</Option>
              <Option value="1">VP Bank</Option>
              <Option value="2">MB Bank</Option>
            </Select>
          </Form.Item>

          <Form.Item
            name="Language"
            label="Ngôn ngữ"
            labelCol={{ span: 24 }}
            wrapperCol={{ span: 24 }}
            rules={[
              {
                required: true,
              },
            ]}
          >
            <Select allowClear>
              <Option value="0">Tiếng Việt</Option>
              <Option value="1">Tiếng Anh</Option>
            </Select>
          </Form.Item>
          <Form.Item labelCol={{ span: 24 }} wrapperCol={{ span: 24 }}>
            <Button type="primary" htmlType="submit">
              Thanh toán
            </Button>
          </Form.Item>
        </Form>
      </div>
    </React.Fragment>
  );
};

export default PaymentForm;
