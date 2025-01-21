import axios from "axios";

export const axiosInstance = axios.create({
  baseURL: "http://localhost:5039/api/",
  headers: { "X-Custom-Header": "foobar" },
});
