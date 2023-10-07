import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import Form from "react-bootstrap/Form";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import "../Navbar/BinanceNavBar.css";
import { Link, NavLink } from "react-router-dom";
import React, { useState } from "react";
import { DecryptData } from "../../DencryptionUtils/DencryptionUtility";
import InputModalComponent from "../Modals/InputModals/InputModalComponent";
import { AuthService } from "../../requestServices";

function ProductNavbar({ userData }) {
  const [showModal, setShowModal] = useState(false);
  const [binanceItem, setBinanceItem] = useState([]);

  let parsedData;
  if (userData != null) {
    const decrypt = DecryptData(userData);
    parsedData = JSON.parse(decrypt);
  }

  const handleLogout = () => {
    localStorage.clear();
  };

  const handleShow = () => {
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
            <label className="company-name">Binance</label>
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
                  <Nav.Link onClick={handleShow}>
                    <label className="labels">Buy Coin</label>
                  </Nav.Link>
                  <Nav.Link href="#action2">
                    <label className="labels">Sell Coin</label>
                  </Nav.Link>
                  <Nav.Link href="#action3">
                    <label className="labels">Show Coin</label>
                  </Nav.Link>
                </>
              )}
            </Nav>
            <Form className="inline">
              <Row>
                {userData ? (
                  <>
                    <Col xs="auto">
                      <label
                        className="welcome-label"
                        style={{ color: "white" }}
                      >
                        Welcome: {parsedData.username}
                      </label>
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
        showModal={showModal}
        setShowModal={setShowModal}
        modalTitle={"Buy Coin"}
        binanceItem={binanceItem}
      />
    </>
  );
}

export default ProductNavbar;
