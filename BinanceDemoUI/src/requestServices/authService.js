import { postJSON } from "./request";

export const signIn = (username, password) =>
  postJSON("Login/signIn", { Username: username, Password: password });

export const signUp = (
  customerName,
  customerEmail,
  username,
  password,
  passwordRepeat
) =>
  postJSON("Login/signUp", {
    CustomerName: customerName,
    CustomerEmail: customerEmail,
    Username: username,
    Password: password,
    PasswordRepeats: passwordRepeat,
  });
