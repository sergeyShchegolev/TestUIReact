import axios from "axios";
import { variables } from './Variables';

export default axios.create({
  baseURL: variables.API_URL,
  headers: {
    "Content-type": "application/json"
  }
});