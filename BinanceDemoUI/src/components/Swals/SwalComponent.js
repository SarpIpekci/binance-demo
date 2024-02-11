import { useEffect } from "react";
import Swal from "sweetalert2";

const SwalComponent = ({
  showSwal,
  errorMessages,
  title,
  icon,
  confirmCallBack,
}) => {
  if (showSwal) {
    Swal.fire({
      title: title,
      text: errorMessages,
      icon: icon,
      showConfirmButton: true,
      allowOutsideClick: false,
      preConfirm: confirmCallBack,
    });
  }

  return null;
};

export default SwalComponent;
