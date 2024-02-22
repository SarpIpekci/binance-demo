import "../SignIn/SignInComponent.css";
import React, { useState } from "react";
import { AuthService } from "../../../requestServices";
import {
  Form,
  Button,
  Col,
  Container,
  Row,
  Image,
  InputGroup,
} from "react-bootstrap";
import LoadingModalComponents from "../../Modals/LoadingModals/LoadingModalComponent";
import { useNavigate, NavLink } from "react-router-dom";
import SwalComponent from "../../Swals/SwalComponent";
import { encryptData } from "../../../EncryptionUtils/EncryptionUtility";
import { GenerateStrongKey } from "../../../GenerateKey/EncryptionKey ";
import { SiBinance } from "react-icons/si";
import { FaRegEye } from "react-icons/fa";
import { FaRegEyeSlash } from "react-icons/fa";

const SignInComponent = () => {
  const navigate = useNavigate();
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [showModal, setShowModal] = useState(false);
  const [isLoading, setIsLoading] = useState(false);
  const [errorMessages, setErrorMessages] = useState([]);
  const [showSwal, setShowSwal] = useState(false);
  const [icon, setIcon] = useState();
  const [showPassword, setShowPassword] = useState(false);

  const togglePasswordVisibility = () => setShowPassword(!showPassword);

  const usernameOnChangeHandler = (e) => {
    setUsername(e.target.value);
  };

  const passwordOnChangeHandler = (e) => {
    setPassword(e.target.value);
  };

  const handleModalClose = () => {
    setShowModal(false);
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

  const formSubmitHandler = (e) => {
    e.preventDefault();
    setShowModal(true);
    setIsLoading(true);
    let errors = [];

    if (!username) errors.push("Username or Password is required.");
    if (!password) errors.push("Username or Password is required.");

    const passwordStrength = checkPasswordStrength(password);
    if (passwordStrength < 3 || password.length > 16) {
      errors.push("Username or Password is wrong.");
    }

    if (errors.length > 0) {
      setShowSwal(true);
      setErrorMessages(errors);
      setIcon("error");
      setIsLoading(false);
      setShowModal(false);
      setPassword("");
      return;
    }

    AuthService.signIn(username, password)
      .then((rest) => {
        const jsonData = JSON.stringify(rest);
        const replacedTurkishLetter = cleanTurkishCharacters(jsonData);
        const encryptedData = encryptData(
          replacedTurkishLetter,
          GenerateStrongKey(32)
        );
        localStorage.setItem("userData", encryptedData);
        setShowModal(false);
        setIsLoading(false);
        navigate("/");
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
                  Log in
                </h3>

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
                    Login
                  </Button>
                </div>

                <p>
                  Don't have an account?{" "}
                  <NavLink className="custom-signIn" to="/SignUp">
                    Register here
                  </NavLink>
                </p>
              </Form>
            </div>
          </Col>
          <Col sm={6} className="d-none d-sm-block p-0">
            <Image
              src="Login.jpg"
              alt="Login image"
              className="custom-image"
              style={{ objectFit: "cover", objectPosition: "right" }}
            />
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
export default SignInComponent;
