import { postJSON } from "./request";

export const signIn = (username, password) =>
  postJSON("Login/signin", { Username: username, Password: password });

export const signUp = () => {};
