import { postJSON } from "./request";
import { get } from "./request";

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

export const fillModal = () => get("Modal/fillModal");

export const buy = (
  customerId,
  coinName,
  coinValue,
  customerBuyValue,
  sumOfValue
) =>
  postJSON("BuyOrSell/buy", {
    CustomerId: customerId,
    CoinName: coinName,
    CoinValue: coinValue,
    CustomerBuyValue: customerBuyValue,
    SumOfValue: sumOfValue,
  });
