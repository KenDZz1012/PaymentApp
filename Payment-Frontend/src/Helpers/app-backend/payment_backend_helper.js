import { get, post, put, del } from "../api_helper";

const BASE_API_URL = `${process.env.REACT_APP_ENDPOINT}/Payments`;

const postPayment = (payload) => {
  return post(`${BASE_API_URL}/Payment`, payload);
};

export { postPayment };
