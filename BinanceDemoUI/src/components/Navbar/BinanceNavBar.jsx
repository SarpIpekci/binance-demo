import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import Form from "react-bootstrap/Form";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Button from "react-bootstrap/Button";
import "../Navbar/BinanceNavBar.css";
import { Link, NavLink } from "react-router-dom";
import React, { useState } from "react";
import { DecryptData } from "../../DecryptionUtils/DecryptionUtility";
import InputModalComponent from "../Modals/InputModals/InputModalComponent";
import { AuthService } from "../../requestServices";
import TableModalComponent from "../Modals/TableModals/TableModalComponent";
import { FaBitcoin, FaMoneyBillWave, FaTable } from "react-icons/fa";
import { SiBinance } from "react-icons/si";

function ProductNavbar({ userData }) {
  const [showModal, setShowModal] = useState(false);
  const [binanceItem, setBinanceItem] = useState([]);
  const [buyOrSellCoinModal, setBuyOrSellCoinModal] = useState();
  const [modalTitle, setModalTitle] = useState();
  const [buttonName, setButtonName] = useState();
  const [showTableModal, setShowTableModal] = useState(false);
  const [showDetails, setShowDetails] = useState(false);

  const toggleDetails = () => {
    setShowDetails(!showDetails);
  };

  let parsedData;
  if (userData != null) {
    const decrypt = DecryptData(userData);
    parsedData = JSON.parse(decrypt);
  }

  const handleLogout = () => {
    localStorage.clear();
  };

  const handleShowBuy = () => {
    handleShowModal(true);
    setModalTitle("Buy Coin");
    setButtonName("Buy");
  };

  const handleShowTable = () => {
    setShowTableModal(true);
  };

  const handleShowSell = () => {
    handleShowModal(false);
    setModalTitle("Sell Coin");
    setButtonName("Sell");
  };

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

  return (
    <>
      <Navbar expand="lg" className="navbar">
        <Container fluid>
          <Nav.Link as={Link} to="/" className="company-name">
            <Row>
              <Col md={2}>
                <SiBinance className="company-icon" />
              </Col>
              <Col md={8}>
                <label className="company-name">Binance</label>
              </Col>
            </Row>
          </Nav.Link>
          <Navbar.Toggle aria-controls="navbarScroll" />
          <Navbar.Collapse id="navbarScroll">
            <Nav
              className="me-auto my-78 my-lg-0"
              style={{ maxHeight: "100px" }}
              navbarScroll
            >
              {userData && (
                <>
                  <Nav.Link onClick={handleShowBuy}>
                    <FaBitcoin className="icon" />
                    <label className="labelBuy">Buy Coin</label>
                  </Nav.Link>
                  <Nav.Link onClick={handleShowSell}>
                    <FaMoneyBillWave className="icon" />
                    <label className="labelSell">Sell Coin</label>
                  </Nav.Link>
                  <Nav.Link onClick={handleShowTable}>
                    <FaTable className="icon" />
                    <label className="labelShow">Show Coin</label>
                  </Nav.Link>
                </>
              )}
            </Nav>
            <Form className="inline">
              <Row>
                {userData ? (
                  <>
                    <Col xs="auto">
                      <Button variant="primary" onClick={toggleDetails}>
                        Show Details
                      </Button>
                      {showDetails && (
                        <div>
                          <label
                            className="welcome-label"
                            style={{ color: "white" }}
                          >
                            Username: {parsedData.username}
                          </label>
                          <br /> <label>----------------------------</label>
                          <br />{" "}
                          <label
                            className="welcome-label"
                            style={{ color: "white" }}
                          >
                            Customer Name: {parsedData.customerName}
                          </label>
                        </div>
                      )}
                    </Col>
                    <Col xs="auto">
                      <button
                        className="login-button btn btn-primary"
                        onClick={handleLogout}
                      >
                        Logout
                      </button>
                    </Col>
                  </>
                ) : (
                  <Col xs="auto">
                    <NavLink
                      className="login-button btn btn-primary"
                      to="/SignIn"
                    >
                      Login
                    </NavLink>
                  </Col>
                )}
              </Row>
            </Form>
          </Navbar.Collapse>
        </Container>
      </Navbar>
      <InputModalComponent
        buyOrSellCoinModal={buyOrSellCoinModal}
        showModal={showModal}
        setShowModal={setShowModal}
        modalTitle={modalTitle}
        binanceItem={binanceItem}
        buttonName={buttonName}
      />
      <TableModalComponent
        showModal={showTableModal}
        setShowTableModal={setShowTableModal}
      />
    </>
  );
}

export default ProductNavbar;
