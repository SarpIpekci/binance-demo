import { AuthService } from "../../requestServices";
import Col from "react-bootstrap/Col";
import { FaMoneyBill } from "react-icons/fa";
import { MdOutlineTableView } from "react-icons/md";
import { MdSell } from "react-icons/md";
import InputModalComponent from "../Modals/InputModals/InputModalComponent";
import TableModalComponent from "../Modals/TableModals/TableModalComponent";
import InputCardComponent from "../InputCard/InputCardComponent";
import React, { useState } from "react";
import "../TradeInputs/TradeInputComponent.css";

const TradeInputComponent = () => {
  const [buyOrSellCoinModal, setBuyOrSellCoinModal] = useState();
  const [showModal, setShowModal] = useState(false);
  const [modalTitle, setModalTitle] = useState();
  const [binanceItem, setBinanceItem] = useState([]);
  const [buttonName, setButtonName] = useState();
  const [showTableModal, setShowTableModal] = useState(false);
  const [buttonStyle, setButtonStyle] = useState();

  const handleShowModal = (isBuy) => {
    setBuyOrSellCoinModal(isBuy);
    AuthService.fillModal()
      .then((rest) => {
        setShowModal(true);
        setBinanceItem(rest);
      })
      .catch((error) => {
        setShowModal(false);
      });
  };

  const handleShowBuy = () => {
    handleShowModal(true);
    setModalTitle("Buy New Coins");
    setButtonName("Buy");
    setButtonStyle("#267365");
  };

  const handleShowSell = () => {
    handleShowModal(false);
    setModalTitle("Sell The Coins");
    setButtonName("Sell");
    setButtonStyle("#F23030");
  };

  const handleShowTable = () => {
    setShowTableModal(true);
  };

  return (
    <>
      <Col
        ms={4}
        className="d-flex justify-content-center align-items-center"
        onClick={handleShowBuy}
      >
        <InputCardComponent
          title={false}
          text={false}
          titleValue={""}
          textValue={""}
          columns={[
            { text: <FaMoneyBill className="my-icon-buy" />, md: 10 },
            { text: "Buy New Coins", md: 10 },
          ]}
        />
      </Col>

      <Col
        ms={4}
        className="d-flex justify-content-center align-items-center"
        onClick={handleShowSell}
      >
        <InputCardComponent
          title={false}
          text={false}
          titleValue={""}
          textValue={""}
          columns={[
            { text: <MdSell className="my-icon-sell" />, md: 10 },
            { text: "Sell The Coins", md: 10 },
          ]}
        />
      </Col>

      <Col
        ms={4}
        className="d-flex justify-content-center align-items-center"
        onClick={handleShowTable}
      >
        <InputCardComponent
          title={false}
          text={false}
          titleValue={""}
          textValue={""}
          columns={[
            {
              text: <MdOutlineTableView className="my-icon-table" />,
              md: 10,
            },
            { text: "Show All Trades", md: 10 },
          ]}
        />
      </Col>

      <InputModalComponent
        buyOrSellCoinModal={buyOrSellCoinModal}
        showModal={showModal}
        setShowModal={setShowModal}
        modalTitle={modalTitle}
        binanceItem={binanceItem}
        buttonName={buttonName}
        buttonStyle={buttonStyle}
      />
      <TableModalComponent
        showModal={showTableModal}
        setShowTableModal={setShowTableModal}
      />
    </>
  );
};

export default TradeInputComponent;
