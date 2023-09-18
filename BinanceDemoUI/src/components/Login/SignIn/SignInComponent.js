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
  const [username, setUsername] = useState();
  const [password, setPassword] = useState();
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

  const formSubmitHandler = (e) => {
    e.preventDefault();
    setShowModal(true);
    setIsLoading(true);
    AuthService.signIn(username, password)
      .then((rest) => {
        const jsonData = JSON.stringify(rest);
        const encryptedData = encryptData(jsonData, GenerateStrongKey(32));
        localStorage.setItem("userData", encryptedData);
        setTimeout(() => {
          setIsLoading(false);
          setShowModal(false);
          navigate("/");
        }, 1000);
      })
      .catch((error) => {
        setIsLoading(false);
        setShowModal(false);
        if (error.response) {
          const { status } = error.response;

          if (status === 400) {
            setShowSwal(true);
            setErrorMessages(error.errorCode);
            setIcon("error");
            setTitle("Sign In Problem");
            return;
          }
        } else {
          setShowSwal(true);
          setErrorMessages(error.message);
          setIcon("error");
          setTitle("Sign In Problem");
        }
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
                className="form-control"
                placeholder="Username"
              />
            </div>
            <div className="mb-3">
              <input
                onChange={passwordOnChangeHandler}
                type="password"
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
            <NavLink to="/SignUp">Sign Up</NavLink>
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
      ></SwalComponent>
    </div>
  );
};
export default SignInComponent;
