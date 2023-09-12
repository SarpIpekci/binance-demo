import React from "react";
import { Modal } from "react-bootstrap";

const ErrorModalComponent = ({ show, onClose, errorMessages }) => {
  let errorMessagesControl = null;

  if (errorMessages != "User is not exists") {
    errorMessagesControl = errorMessages.map((message, index) => (
      <p key={index} style={{ color: "red" }}>
        {message}
      </p>
    ));
  } else {
    errorMessagesControl = errorMessages;
  }

  return (
    <Modal
      show={show}
      onHide={onClose}
      backdrop="static"
      keyboard={false}
      centered
    >
      <Modal.Body className="text-center" style={{ color: "red" }}>
        {errorMessagesControl}
      </Modal.Body>
    </Modal>
  );
};

export default ErrorModalComponent;
