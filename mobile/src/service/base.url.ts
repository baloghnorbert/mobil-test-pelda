// locale
const localhost = "http://localhost:5000";

// production
const production = "http://10.0.2.2:5000";

// production or stage
export const baseURL: string = process.env.NODE_ENV === "production" ?  production : localhost;