import Swal from "sweetalert2";
import "../Swals/SwalComponent.css";

const SwalComponent = ({ showSwal, errorMessages, icon, confirmCallBack }) => {
  let newErrorMessages;
  if (errorMessages.length > 0) {
    newErrorMessages = errorMessages.join("<br>");
  }

  if (showSwal) {
    Swal.fire({
      html: newErrorMessages,
      icon: icon,
      showConfirmButton: true,
      allowOutsideClick: false,
      preConfirm: confirmCallBack,
      confirmButtonColor: "#024959",
      animation: true,
    });
  }

  return null;
};

export default SwalComponent;
