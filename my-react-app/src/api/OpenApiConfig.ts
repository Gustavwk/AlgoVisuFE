import { OpenAPI } from "./core/OpenAPI";

OpenAPI.BASE = process.env.REACT_APP_API_BASE_URL || 'http://localhost:5000';

export default OpenAPI;
