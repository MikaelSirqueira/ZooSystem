import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:7003/",
});

export default api;
