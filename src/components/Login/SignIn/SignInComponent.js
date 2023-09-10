import "../SignIn/SignInComponent.css";
import React, { useState } from "react";
import { AuthService } from "../../../requestServices";

const SignInComponent = () => {
  const [username, setUsername] = useState();
  const [password, setPassword] = useState();

  const usernameOnChangeHandler = (e) => {
    setUsername(e.target.value);
  };

  const passwordOnChangeHandler = (e) => {
    setPassword(e.target.value);
  };

  const formSubmitHandler = (e) => {
    e.preventDefault();
    AuthService.signIn(username, password).then((rest) => {
      console.log(rest);
    });
  };

  return (
    <form onSubmit={formSubmitHandler}>
      <div className="mb-3">
        <label className="form-label">Username</label>
        <input
          onChange={usernameOnChangeHandler}
          type="text"
          className="form-control"
        />
      </div>
      <div className="mb-3">
        <label className="form-label">Password</label>
        <input
          onChange={passwordOnChangeHandler}
          type="password"
          className="form-control"
        />
      </div>
      <button type="submit" className="btn btn-primary">
        Sign In
      </button>
    </form>
  );
};
export default SignInComponent;
