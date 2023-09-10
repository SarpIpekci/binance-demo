import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import "../Navbar/BinanceNavBar.css";

function ProductNavbar() {
  return (
    <Navbar expand="lg" className="navbar">
      <Container fluid>
        <Navbar.Brand className="company-name" href="#">
          <label className="company-name">Binance</label>
        </Navbar.Brand>
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
            <Button
              className="login-button"
              as="input"
              type="button"
              value="Login"
            />
          </Form>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}

export default ProductNavbar;
