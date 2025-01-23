import axios, { AxiosError } from "axios";
import { redirect } from "next/navigation";

export const axiosInstance = axios.create({
  baseURL: "http://localhost:5039/api/",
  headers: { "X-Custom-Header": "foobar" },
});

axiosInstance.interceptors.response.use(
  function (response) {
    return response;
  },
  function (error: AxiosError) {
    if (error.status === 401) {
      console.log("Unauthorized");
      redirect("/");
    }
    return Promise.reject(error);
  }
);
