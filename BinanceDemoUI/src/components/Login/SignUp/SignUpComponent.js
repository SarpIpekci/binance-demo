import "../SignUp/SignUpComponent.css";
import React, { useState } from "react";
import { AuthService } from "../../../requestServices";
import { Card, Form, Button } from "react-bootstrap";
import LoadingModalComponents from "../../Modals/LoadingModals/LoadingModalComponent";
import { useNavigate } from "react-router-dom";
import SwalComponent from "../../Swals/SwalComponent";

const SignUpComponent = () => {
  const navigate = useNavigate();
  const [customerName, setCustomerName] = useState();
  const [customerEmail, setCustomerEmail] = useState();
  const [username, setUsername] = useState();
  const [password, setPassword] = useState();
  const [passwordRepeat, setPasswordRepeat] = useState();
  const [showModal, setShowModal] = useState(false);
  const [isLoading, setIsLoading] = useState(false);
  const [errorMessages, setErrorMessages] = useState([]);
  const [showSwal, setShowSwal] = useState(false);
  const [icon, setIcon] = useState();
  const [title, setTitle] = useState();

  const checkPasswordStrength = (password) => {
    let strength = 0;

    if (/[A-Z]/.test(password)) {
      strength++;
    }

    if (/[!@#$%^&*]/.test(password)) {
      strength++;
    }

    if (password.length >= 8) {
      strength++;
    }

    return strength;
  };

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
    const newPassword = e.target.value;
    const strength = checkPasswordStrength(newPassword);

    if (strength >= 1) {
      document.querySelector(".signUpLabel label:nth-child(1)").style.color =
        "green";
    } else {
      document.querySelector(".signUpLabel label:nth-child(1)").style.color =
        "";
    }

    if (/[!@#$%^&*.]/.test(newPassword)) {
      document.querySelector(".signUpLabel label:nth-child(2)").style.color =
        "green";
    } else {
      document.querySelector(".signUpLabel label:nth-child(2)").style.color =
        "";
    }

    if (newPassword.length >= 8) {
      document.querySelector(".signUpLabel label:nth-child(3)").style.color =
        "green";
    } else {
      document.querySelector(".signUpLabel label:nth-child(3)").style.color =
        "";
    }

    setPassword(newPassword);
  };

  const passwordRepeatOnChangeHandler = (e) => {
    setPasswordRepeat(e.target.value);

    if (e.target.value === password) {
      document.querySelector(".signUpLabel label:nth-child(4)").style.color =
        "green";
      setTimeout(() => {
        document.querySelector(
          ".signUpLabel label:nth-child(4)"
        ).style.visibility = "hidden";
      }, 1000);
    } else {
      document.querySelector(".signUpLabel label:nth-child(4)").style.color =
        "";
      document.querySelector(
        ".signUpLabel label:nth-child(4)"
      ).style.visibility = "visible";
    }
  };

  const handleModalClose = () => {
    setShowModal(false);
  };

  const formSubmitHandler = (e) => {
    e.preventDefault();
    setShowModal(true);
    setIsLoading(true);
    AuthService.signUp(
      customerName,
      customerEmail,
      username,
      password,
      passwordRepeat
    )
      .then((rest) => {
        setIcon("success");
        setTitle(rest.message);
        setShowSwal(true);
        setTimeout(() => {
          setIsLoading(false);
          setShowModal(false);
          navigate("/SignIn");
        }, 1500);
      })
      .catch((error) => {
        setIsLoading(false);
        setShowModal(false);
        if (error.response) {
          const { status } = error.response;
          if (status === 400) {
            setShowSwal(true);
            setErrorMessages(error.errorCode);
            setTitle("Sign Up Problem");
            setIcon("error");
            setTimeout(() => {
              setShowSwal(false);
              setErrorMessages(null);
            }, 100);
            return;
          }
        } else {
          setShowSwal(true);
          setErrorMessages(error.message);
          setTitle("Sign Up Problem");
          setIcon("error");
          setTimeout(() => {
            setShowSwal(false);
            setErrorMessages(null);
          }, 100);
        }
      });
  };

  return (
    <div>
      <div className="signIn container-sm">
        <Card className="signUpCard">
          <div className="card-header">
            <h3>Sign Up</h3>
          </div>
          <div className="card-body">
            <Form onSubmit={formSubmitHandler}>
              <div className="mb-3">
                <input
                  onChange={customerNameOnChangeHandler}
                  type="text"
                  className="form-control"
                  placeholder="Customer Name"
                />
              </div>
              <div className="mb-3">
                <input
                  onChange={customerEmailOnChangeHandler}
                  type="email"
                  className="form-control"
                  placeholder="Customer Email"
                />
              </div>
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
              <div className="mb-3">
                <input
                  onChange={passwordRepeatOnChangeHandler}
                  type="password"
                  className="form-control"
                  placeholder="Password Repeat"
                />
              </div>
              <Button
                type="submit"
                className="btn btn-primary float-end login_btn"
              >
                Sign Up
              </Button>
            </Form>
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
        />
      </div>{" "}
      <div className="signUpLabel container-sm">
        {" "}
        <Card className="signUpLabel">
          <label className="validationLabel">
            Şifreniz en az bir büyük karakter olmalıdır.
          </label>
          <label className="validationLabel">
            Şifreniz en az bir özel karakter olmalıdır.
          </label>
          <label className="validationLabel">
            Şifreniz en az 8 karakterden oluşmalıdır.
          </label>
          <label className="validationLabel">
            Şifreniz ile tekrarı birbiri ile uyuşmuyor.
          </label>
        </Card>
      </div>
    </div>
  );
};
export default SignUpComponent;
