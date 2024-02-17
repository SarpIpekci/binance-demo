import React, { useState } from "react";
import { InputGroup, Button, Modal, Dropdown, Form } from "react-bootstrap";
import { DecryptData } from "../../../DecryptionUtils/DecryptionUtility";
import LoadingModalComponents from "../LoadingModals/LoadingModalComponent";
import { AuthService } from "../../../requestServices";
import SwalComponent from "../../Swals/SwalComponent";
import "../InputModals/InputModalComponent.css";

function InputModalComponent({
  buyOrSellCoinModal,
  showModal,
  setShowModal,
  modalTitle,
  binanceItem,
  buttonName,
}) {
  const handleClose = () => {
    setShowModal(false);
  };
  const [doubleValue, setDoubleValue] = useState(1);
  const [coinValue, setCoinValue] = useState(0);
  const [selectedItem, setSelectedItem] = useState("Please Select Coin");
  const [showModalLoading, setShowModalLoading] = useState(false);
  const [isLoading, setIsLoading] = useState(false);
  const [showSwal, setShowSwal] = useState(false);
  const [icon, setIcon] = useState();
  const [title, setTitle] = useState();
  const [errorMessages, setErrorMessages] = useState([]);

  let sumOfCoin;

  if (coinValue !== "undefined") {
    sumOfCoin = coinValue * doubleValue;
  }

  const fixedCoinValue = parseFloat(sumOfCoin.toFixed(5));

  let parsedData;

  const userDataFromLocalStorage = localStorage.getItem("userData");

  if (userDataFromLocalStorage !== null) {
    const decrypt = DecryptData(userDataFromLocalStorage);
    parsedData = JSON.parse(decrypt);
  }

  const handleInputChange = (event) => {
    const newValue = parseFloat(event.target.value);
    if (!isNaN(newValue)) {
      setDoubleValue(newValue);
    }
  };

  function getPriceForSymbol(symbol, binanceData) {
    const coin = binanceData.find((item) => item.symbol === symbol);
    if (coin) {
      return coin.price;
    }
    return null;
  }

  const handleItemClick = (text) => {
    if (text === "Please Select Coin") {
      setSelectedItem(text);
      setCoinValue(0);
    } else {
      setSelectedItem(text);
      setCoinValue(getPriceForSymbol(text, binanceItem));
    }
  };

  const binanceItemWithDefault = [
    {
      symbol: "Please Select Coin",
      price: 0,
    },
    ...binanceItem,
  ];

  const buyService = () => {
    setShowModal(true);
    setIsLoading(true);
    AuthService.buy(
      parsedData.id,
      selectedItem,
      coinValue,
      doubleValue,
      fixedCoinValue
    )
      .then((rest) => {
        setIsLoading(false);
        setShowModalLoading(false);
        setShowSwal(true);
        setIcon("success");
        setTitle(rest.message);
      })
      .catch((error) => {
        setIsLoading(false);
        setShowModalLoading(false);
        setShowModal(true);
        setErrorMessages(error.message);
        setTitle("Buy");
        setIcon("error");
      });
  };

  const sellService = () => {
    setShowModal(true);
    setIsLoading(true);
    AuthService.sell(
      parsedData.id,
      selectedItem,
      coinValue,
      doubleValue,
      fixedCoinValue
    )
      .then((rest) => {
        setIsLoading(false);
        setShowModalLoading(false);
        setShowSwal(true);
        setTitle("Sell");
        setIcon("success");
        setTitle(rest.message);
      })
      .catch((error) => {
        setIsLoading(false);
        setShowModalLoading(false);
        setShowSwal(true);
        setTitle("Sell");
        setIcon("error");
        setErrorMessages(error.message);
      });
  };

  const formSubmitHandler = (e) => {
    e.preventDefault();
    setIsLoading(true);
    setShowModalLoading(true);
    if (buyOrSellCoinModal) {
      buyService();
    } else {
      sellService();
    }
  };

  const handleModalClose = () => {
    setShowModalLoading(false);
  };

  return (
    <div>
      <>
        <Modal
          show={showModal}
          backdrop="static"
          keyboard={false}
          centered
          onHide={handleClose}
        >
          <Form onSubmit={formSubmitHandler}>
            <Modal.Header className="custom-header" closeButton>
              <Modal.Title>{modalTitle}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
              <div className="panel-default">
                <div className="panel-body">
                  <div className="row">
                    <div className="mb-3">
                      {" "}
                      <div className="form-group">
                        <Dropdown>
                          <Dropdown.Toggle
                            id="dropdown-basic"
                            className="dropdown-toggle"
                          >
                            {selectedItem}
                          </Dropdown.Toggle>
                          <Dropdown.Menu className="dropdown-menu">
                            {binanceItemWithDefault.map((item) => (
                              <Dropdown.Item
                                key={item.symbol}
                                eventKey={item.symbol}
                                onClick={() => handleItemClick(item.symbol)}
                              >
                                {item.symbol}
                              </Dropdown.Item>
                            ))}
                          </Dropdown.Menu>
                        </Dropdown>
                      </div>
                    </div>
                    <div className="mb-3">
                      {" "}
                      {coinValue !== 0 && (
                        <div className="form-group">
                          <label style={{ color: "red" }}>{coinValue}</label>
                        </div>
                      )}
                    </div>
                  </div>
                  <div className="row">
                    <div className="mb-3">
                      <label className="input-label">
                        {buyOrSellCoinModal
                          ? "Buy Quantity:"
                          : "Sell Quantity:"}
                      </label>
                      <div className="form-group">
                        <InputGroup className="mb-3">
                          <Form.Control
                            type="number"
                            min="1"
                            value={doubleValue}
                            onChange={handleInputChange}
                          />
                        </InputGroup>
                      </div>
                    </div>
                  </div>
                  <div className="row">
                    <div className="mb-3">
                      <label className="input-label">Sum Of Quantity:</label>
                      <div className="form-group">
                        <InputGroup className="mb-3">
                          <Form.Control
                            type="number"
                            min="1"
                            value={sumOfCoin || 0}
                            disabled
                            className="disabled-input"
                          />
                        </InputGroup>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </Modal.Body>
            <Modal.Footer>
              <Button type="submit" variant="success" onClick={handleClose}>
                {buttonName}
              </Button>
            </Modal.Footer>
          </Form>
        </Modal>
      </>
      <LoadingModalComponents
        show={showModalLoading}
        onClose={handleModalClose}
        isLoading={isLoading}
      />
      <SwalComponent
        showSwal={showSwal}
        errorMessages={errorMessages}
        title={title}
        icon={icon}
        confirmCallBack={() => setShowSwal(false)}
      />
    </div>
  );
}

export default InputModalComponent;
