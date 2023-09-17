import Swal from "sweetalert2";
import React, { useEffect } from "react";

const SwalComponent = ({ showSwal, errorMessages, title, icon }) => {
  useEffect(() => {
    if (showSwal) {
      Swal.fire({
        title: title,
        text: errorMessages,
        icon: icon,
        timer: 2000,
        showConfirmButton: false,
      });
    }
  }, [showSwal, title, icon, errorMessages]);

  return null;
};

export default SwalComponent;
