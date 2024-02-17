import React from "react";
import { Modal } from "react-bootstrap";
import LoadingSnipperComponent from "../../Snippers/LoadingSnipper/LoadingSnipperComponent";
import "../LoadingModals/LoadingModalComponents.css";

const LoadingModalComponents = ({ show, onClose, isLoading }) => {
  return (
    <Modal
      show={show}
      onHide={onClose}
      backdrop="static"
      keyboard={false}
      centered
    >
      <Modal.Body className="text-center">
        {isLoading ? (
          <>
            <LoadingSnipperComponent />
            Loading...
          </>
        ) : (
          "Operation Completed"
        )}
      </Modal.Body>
    </Modal>
  );
};

export default LoadingModalComponents;
