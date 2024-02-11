import "../SignIn/SignInComponent.css";
import React, { useState } from "react";
import { AuthService } from "../../../requestServices";
import { Card, Form, Button } from "react-bootstrap";
import LoadingModalComponents from "../../Modals/LoadingModals/LoadingModalComponent";
import { useNavigate, NavLink } from "react-router-dom";
import SwalComponent from "../../Swals/SwalComponent";
import { encryptData } from "../../../EncryptionUtils/EncryptionUtility";
import { GenerateStrongKey } from "../../../GenerateKey/EncryptionKey ";

const SignInComponent = () => {
  const navigate = useNavigate();
  const [username, setUsername] = useState("sarp");
  const [password, setPassword] = useState("Srpic14.");
  const [showModal, setShowModal] = useState(false);
  const [isLoading, setIsLoading] = useState(false);
  const [errorMessages, setErrorMessages] = useState([]);
  const [showSwal, setShowSwal] = useState(false);
  const [icon, setIcon] = useState();
  const [title, setTitle] = useState();

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

  const formSubmitHandler = (e) => {
    e.preventDefault();
    setShowModal(true);
    setIsLoading(true);
    if (!username || !password) {
      setShowSwal(true);
      setErrorMessages("Username or Password is required.");
      setIcon("error");
      setTitle("Sign In Problem");
      setIsLoading(false);
      setShowModal(false);
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
        setTitle("Sign In Problem");
      });
  };

  return (
    <div className="signIn container-sm">
      <Card>
        <div className="card-header">
          <h3>Sign In</h3>
        </div>
        <div className="card-body">
          <Form onSubmit={formSubmitHandler}>
            <div className="mb-3">
              <input
                onChange={usernameOnChangeHandler}
                type="text"
                value={username}
                className="form-control"
                placeholder="Username"
              />
            </div>
            <div className="mb-3">
              <input
                onChange={passwordOnChangeHandler}
                type="password"
                value={password}
                className="form-control"
                placeholder="Password"
                autoComplete="current-password"
              />
            </div>
            <Button
              type="submit"
              className="btn btn-primary float-end login_btn"
            >
              Login
            </Button>
          </Form>
        </div>
        <div className="card-footer">
          <div className="d-flex justify-content-center links">
            Don't have an account?
            <NavLink className="custom-signIn" to="/SignUp">
              Sign Up
            </NavLink>
          </div>
        </div>
      </Card>
      <LoadingModalComponents
        show={showModal}
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
};
export default SignInComponent;
