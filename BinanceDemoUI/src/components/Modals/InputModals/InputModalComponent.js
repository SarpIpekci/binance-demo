import React, { useState } from "react";
import { InputGroup, Button, Modal, Dropdown, Form } from "react-bootstrap";
import { DecryptData } from "../../../DencryptionUtils/DencryptionUtility";
import LoadingModalComponents from "../LoadingModals/LoadingModalComponent";
import { AuthService } from "../../../requestServices";
import SwalComponent from "../../Swals/SwalComponent";
import "../InputModals/InputModalComponent.css";

function InputModalComponent({
  showModal,
  setShowModal,
  modalTitle,
  binanceItem,
}) {
  const handleClose = () => {
    setShowModal(false);
  };
  const [doubleValue, setDoubleValue] = useState(1);
  const [coinValue, setCoinValue] = useState();
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

  const fixedCoinValue = parseFloat(sumOfCoin.toFixed(2));
  console.log(fixedCoinValue);
  console.log(sumOfCoin);
  console.log(coinValue);
  console.log(doubleValue);
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
    setSelectedItem(text);
    setCoinValue(getPriceForSymbol(text, binanceItem));
  };

  const binanceItemWithDefault = [
    {
      symbol: "Please Select Coin",
      price: 0,
    },
    ...binanceItem,
  ];

  const formSubmitHandler = (e) => {
    e.preventDefault();
    setShowModalLoading(true);
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
        setIcon("success");
        setTitle(rest.message);
        setShowSwal(true);
      })
      .catch((error) => {
        setIsLoading(false);
        setShowModalLoading(false);
        setErrorMessages(error.message);
        if (error.response) {
          const { status } = error.response;
          if (status === 400) {
            setShowSwal(true);
            setErrorMessages(error.errorCode);
            setTitle("Buy");
            setIcon("error");
            return;
          }
        } else {
          setShowSwal(true);
          setErrorMessages(error.message);
          setTitle("Buy");
          setIcon("error");
        }
      });
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
            <Modal.Header closeButton>
              <Modal.Title>{modalTitle}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
              <div className="panel-default">
                <div className="panel-body">
                  <div className="row">
                    <div className="col-sm-12">
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
                      {coinValue !== undefined && (
                        <div className="form-group">
                          <label style={{ color: "red" }}>{coinValue}</label>
                        </div>
                      )}
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
                Buy
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
      />
    </div>
  );
}

export default InputModalComponent;
