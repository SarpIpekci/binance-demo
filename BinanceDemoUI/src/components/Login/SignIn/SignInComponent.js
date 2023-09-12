import "../SignIn/SignInComponent.css";
import React, { useState } from "react";
import { AuthService } from "../../../requestServices";
import { Card, Form, Button } from "react-bootstrap";
import "../SignIn/SignInComponent.css";
import LoadingModalComponents from "../../Modals/LoadingModals/LoadingModalComponent";
import { useNavigate } from "react-router-dom";
import ErrorModalComponent from "../../Modals/ErrorModals/ErrorModalComponent";

const SignInComponent = () => {
  const navigate = useNavigate();
  const [username, setUsername] = useState();
  const [password, setPassword] = useState();
  const [showModal, setShowModal] = useState(false);
  const [isLoading, setIsLoading] = useState(false);
  const [errorMessages, setErrorMessages] = useState([]);
  const [showErrorModal, setShowErrorModal] = useState();

  const usernameOnChangeHandler = (e) => {
    setUsername(e.target.value);
  };

  const passwordOnChangeHandler = (e) => {
    setPassword(e.target.value);
  };

  const handleModalClose = () => {
    setShowModal(false);
  };

  const handleErrorModalClose = () => {
    setShowErrorModal(false);
  };

  const formSubmitHandler = (e) => {
    e.preventDefault();
    setShowModal(true);
    setIsLoading(true);
    AuthService.signIn(username, password)
      .then((rest) => {
        console.log(rest);
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
            setShowErrorModal(true);
            setErrorMessages(error.message);
            setTimeout(() => {
              setShowErrorModal(false);
            }, 2000);
            return;
          }
        } else {
          setShowErrorModal(true);
          setErrorMessages(error.message);
          setTimeout(() => {
            setShowErrorModal(false);
          }, 2000);
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
            Don't have an account?<a href="#">Sign Up</a>
          </div>
        </div>
      </Card>
      <LoadingModalComponents
        show={showModal}
        onClose={handleModalClose}
        isLoading={isLoading}
      />
      <ErrorModalComponent
        show={showErrorModal}
        onClose={handleErrorModalClose}
        errorMessages={errorMessages}
      />
    </div>
  );
};
export default SignInComponent;
