import "../SignUp/SignUpComponent.css";
import React, { useState } from "react";
import { AuthService } from "../../../requestServices";
import LoadingModalComponents from "../../Modals/LoadingModals/LoadingModalComponent";
import { useNavigate } from "react-router-dom";
import SwalComponent from "../../Swals/SwalComponent";
import {
  Form,
  Button,
  Col,
  Container,
  Row,
  Image,
  InputGroup,
} from "react-bootstrap";
import { SiBinance } from "react-icons/si";
import { FaRegEye } from "react-icons/fa";
import { FaRegEyeSlash } from "react-icons/fa";

const SignUpComponent = () => {
  const navigate = useNavigate();
  const [customerName, setCustomerName] = useState("");
  const [customerEmail, setCustomerEmail] = useState("");
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [passwordRepeat, setPasswordRepeat] = useState("");
  const [showModal, setShowModal] = useState(false);
  const [isLoading, setIsLoading] = useState(false);
  const [errorMessages, setErrorMessages] = useState([]);
  const [showSwal, setShowSwal] = useState(false);
  const [icon, setIcon] = useState();
  const [showPassword, setShowPassword] = useState(false);
  const [showPasswordRepeat, setShowPasswordRepeat] = useState(false);

  const togglePasswordVisibility = () => setShowPassword(!showPassword);
  const togglePasswordRepeatVisibility = () =>
    setShowPasswordRepeat(!showPasswordRepeat);

  const customerNameOnChangeHandler = (e) => {
    setCustomerName(e.target.value);
  };

  const customerEmailOnChangeHandler = (e) => {
    setCustomerEmail(e.target.value);
  };

  const usernameOnChangeHandler = (e) => {
    setUsername(e.target.value);
  };

  const passwordOnChangeHandler = (e) => {
    setPassword(e.target.value);
  };

  const passwordRepeatOnChangeHandler = (e) => {
    setPasswordRepeat(e.target.value);
  };

  const handleModalClose = () => {
    setShowModal(false);
  };

  const checkPasswordStrength = (password) => {
    let strength = 0;

    if (/[A-Z]/.test(password)) {
      strength++;
    }

    if (/[!@#$%^&*]/.test(password)) {
      strength++;
    }

    if (/[0-9]/.test(password)) {
      strength++;
    }

    if (password.length >= 8 && password.length <= 16) {
      strength++;
    }

    return strength >= 4 ? 3 : strength;
  };

  function cleanTurkishCharacters(str) {
    return str
      .replace(/İ/g, "I")
      .replace(/ı/g, "i")
      .replace(/Ö/g, "O")
      .replace(/ö/g, "o")
      .replace(/Ç/g, "C")
      .replace(/ç/g, "c")
      .replace(/Ş/g, "S")
      .replace(/ş/g, "s")
      .replace(/Ğ/g, "G")
      .replace(/ğ/g, "g");
  }

  const formSubmitHandler = (e) => {
    e.preventDefault();
    let errors = [];

    if (!customerName) errors.push("Customer name is required.");
    if (!customerEmail) errors.push("Email is required.");
    if (!username) errors.push("Username is required.");
    if (!password) errors.push("Password is required.");
    if (!passwordRepeat) errors.push("Password repeat is required.");
    if (password !== passwordRepeat) errors.push("Passwords do not match.");
    const passwordStrength = checkPasswordStrength(password);
    if (passwordStrength < 3 || password.length > 16) {
      errors.push(
        "Password must contain at least one uppercase letter, one special character, one number, and must be 8-16 characters long."
      );
    }

    if (errors.length > 0) {
      setShowSwal(true);
      setErrorMessages(errors);
      setIcon("error");
      return;
    }
    setShowModal(true);
    setIsLoading(true);
    const cleanCustomerName = cleanTurkishCharacters(customerName);
    AuthService.signUp(
      cleanCustomerName,
      customerEmail,
      username,
      password,
      passwordRepeat
    )
      .then((rest) => {
        setIsLoading(false);
        setShowModal(false);
        setShowSwal(true);
        setIcon("success");
        setErrorMessages(rest.message);
        navigate("/SignIn");
      })
      .catch((error) => {
        setIsLoading(false);
        setShowModal(false);
        setShowSwal(true);
        setErrorMessages(error.message);
        setIcon("error");
      });
  };

  return (
    <section className="vh-80">
      <Container fluid>
        <Row>
          <Col sm={6} className="d-none d-sm-block p-0">
            <Image
              src="SignUp.jpg"
              alt="SignUp image"
              className="custom-image"
              style={{ objectFit: "cover", objectPosition: "right" }}
            />
          </Col>
          <Col sm={6} className="text-black">
            <div className="px-5 ms-xl-4">
              <i
                className="fas fa-crow fa-2x me-3 pt-5 mt-xl-4"
                style={{ color: "#709085" }}
              ></i>
              <span className="h1 fw-bold mb-0">
                {" "}
                <SiBinance className="company-icon" />
              </span>
            </div>

            <div className="d-flex align-items-center h-custom-2 px-5 ms-xl-4 mt-5 pt-5 pt-xl-0 mt-xl-n5">
              <Form style={{ width: "23rem" }} onSubmit={formSubmitHandler}>
                <h3
                  className="fw-normal mb-3 pb-3"
                  style={{ letterSpacing: "1px" }}
                >
                  Sign Up
                </h3>
                <Form.Group className="form-outline mb-4">
                  <Form.Control
                    type="text"
                    id="form2Example18"
                    className="form-control form-control-lg"
                    onChange={customerNameOnChangeHandler}
                    value={customerName}
                    placeholder="Customer Name"
                  />
                </Form.Group>
                <Form.Group className="form-outline mb-4">
                  <Form.Control
                    type="email"
                    id="form2Example18"
                    className="form-control form-control-lg"
                    onChange={customerEmailOnChangeHandler}
                    value={customerEmail}
                    placeholder="Email"
                  />
                </Form.Group>
                <Form.Group className="form-outline mb-4">
                  <Form.Control
                    type="text"
                    id="form2Example18"
                    className="form-control form-control-lg"
                    onChange={usernameOnChangeHandler}
                    value={username}
                    placeholder="Username"
                  />
                </Form.Group>

                <Form.Group className="form-outline mb-4">
                  <InputGroup>
                    <Form.Control
                      type={showPassword ? "text" : "password"}
                      id="form2Example28"
                      className="form-control form-control-lg"
                      value={password}
                      onChange={passwordOnChangeHandler}
                      placeholder="Password"
                    />
                    <Button
                      variant="outline-secondary"
                      onClick={togglePasswordVisibility}
                    >
                      {showPassword ? <FaRegEye /> : <FaRegEyeSlash />}
                    </Button>
                  </InputGroup>
                </Form.Group>

                <Form.Group className="form-outline mb-4">
                  <InputGroup>
                    <Form.Control
                      type={showPasswordRepeat ? "text" : "password"}
                      id="form2Example28"
                      className="form-control form-control-lg"
                      value={passwordRepeat}
                      onChange={passwordRepeatOnChangeHandler}
                      placeholder="Password"
                    />
                    <Button
                      variant="outline-secondary"
                      onClick={togglePasswordRepeatVisibility}
                    >
                      {showPasswordRepeat ? <FaRegEye /> : <FaRegEyeSlash />}
                    </Button>
                  </InputGroup>
                </Form.Group>

                <div className="pt-1 mb-4">
                  <Button
                    className="btn btn-info btn-lg btn-block"
                    type="submit"
                    style={{
                      backgroundColor: "#024959",
                      borderColor: "#024959",
                      color: "white",
                      fontFamily: "Roboto sans-serif",
                    }}
                  >
                    Sign Up
                  </Button>
                </div>
              </Form>
            </div>
          </Col>
        </Row>
      </Container>
      <LoadingModalComponents
        show={showModal}
        onClose={handleModalClose}
        isLoading={isLoading}
      />
      <SwalComponent
        showSwal={showSwal}
        errorMessages={errorMessages}
        icon={icon}
        confirmCallBack={() => setShowSwal(false)}
      />
    </section>
  );
};
export default SignUpComponent;
