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

export const sell = (
  customerId,
  coinName,
  coinValue,
  customerSellValue,
  sumOfValue
) =>
  postJSON("BuyOrSell/sell", {
    CustomerId: customerId,
    CoinName: coinName,
    CoinValue: coinValue,
    CustomerSellValue: customerSellValue,
    SumOfValue: sumOfValue,
  });

export const fillBuyCoinTable = (customerId) =>
  get(`CustomerTable/getBuyCoin?customerId=${customerId}`);

export const fillSellCoinTable = (customerId) =>
  get(`CustomerTable/getSellCoin?customerId=${customerId}`);

export const fillAllCoinTable = (customerId) =>
  get(`CustomerTable/getAllCoins?customerId=${customerId}`);
