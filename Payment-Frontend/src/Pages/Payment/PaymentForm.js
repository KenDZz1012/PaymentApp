import React, { useEffect, useState } from "react";
import { Button, Form, Input, InputNumber, Select } from "antd";
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

  const onTypePaymentChange = (value) => {
    formRef.current?.setFieldsValue({
      type: value,
    });
  };
  return (
    <React.Fragment>
      <div style={{ borderBottom: "1px solid #ccc" }}>
        <h2>Tạo mới đơn hàng</h2>
        <Form
          {...layout}
          ref={formRef}
          name="control-ref"
          style={{
            maxWidth: 800,
            margin: "auto",
          }}
        >
          <Form.Item
            name="TypePayment"
            label="Loại hàng hóa"
            labelCol={{ span: 24 }}
            wrapperCol={{ span: 24 }}
            rules={[
              {
                required: true,
              },
            ]}
          >
            <Select onChange={onTypePaymentChange} allowClear>
              <Option value="0">Nạp tiền điện thoại</Option>
              <Option value="1">Thanh toán hóa đơn</Option>
              <Option value="2">Thời trang</Option>
            </Select>
          </Form.Item>

          <Form.Item
            name="money"
            label="Số tiền"
            labelCol={{ span: 24 }}
            wrapperCol={{ span: 24 }}
            rules={[
              {
                required: true,
              },
            ]}
          >
            <InputNumber
              style={{ width: "100%" }}
              defaultValue={1000}
              formatter={(value) =>
                `${value}`.replace(/\B(?=(\d{3})+(?!\d))/g, ",")
              }
              parser={(value) => value.replace(/\$\s?|(,*)/g, "")}
            />{" "}
          </Form.Item>

          <Form.Item
            labelCol={{ span: 24 }}
            wrapperCol={{ span: 24 }}
            name="description"
            label="Nội dung thanh toán"
          >
            <TextArea />{" "}
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
