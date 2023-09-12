import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import Form from "react-bootstrap/Form";
import "../Navbar/BinanceNavBar.css";
import { Link, NavLink } from "react-router-dom";

function ProductNavbar() {
  return (
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
            <Nav.Link href="#action1">
              <label className="labels">Buy Coin</label>
            </Nav.Link>
            <Nav.Link href="#action2">
              <label className="labels">Sell Coin</label>
            </Nav.Link>
            <Nav.Link href="#action3">
              <label className="labels">Show Coin</label>
            </Nav.Link>
          </Nav>
          <Form className="d-flex">
            <NavLink className="login-button btn btn-primary" to="/SignIn">
              Login
            </NavLink>
          </Form>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}

export default ProductNavbar;
