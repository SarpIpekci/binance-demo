import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import Form from "react-bootstrap/Form";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import "../Navbar/BinanceNavBar.css";
import { Link, NavLink } from "react-router-dom";
import { SiBinance } from "react-icons/si";
import { IoMdLogIn } from "react-icons/io";
import { IoMdLogOut } from "react-icons/io";

function ProductNavbar({ userData }) {
  const handleLogout = () => {
    localStorage.clear();
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
            <Nav className="ms-auto">
              <Form className="d-flex">
                <Row>
                  {userData ? (
                    <>
                      <Col md="auto">
                        <button
                          className="login-button btn btn-primary"
                          onClick={handleLogout}
                        >
                          <Row>
                            <IoMdLogOut className="login-logout-icon" />
                          </Row>
                          <Row>
                            <span className="login-logout-text">Logout</span>
                          </Row>
                        </button>
                      </Col>
                    </>
                  ) : (
                    <Col md="auto">
                      <NavLink
                        className="login-button btn btn-primary"
                        to="/SignIn"
                      >
                        <Row>
                          <IoMdLogIn className="login-logout-icon" />
                        </Row>
                        <Row>
                          <span className="login-logout-text">Login</span>
                        </Row>
                      </NavLink>
                    </Col>
                  )}
                </Row>
              </Form>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </>
  );
}

export default ProductNavbar;
