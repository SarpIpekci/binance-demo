import Swal from "sweetalert2";
import "../Swals/SwalComponent.css";

const SwalComponent = ({ showSwal, errorMessages, icon, confirmCallBack }) => {
  const errorMessagesArray =
    typeof errorMessages === "string" ? [errorMessages] : errorMessages;

  let newErrorMessages;
  if (errorMessagesArray.length > 0) {
    newErrorMessages = errorMessagesArray.join("<br>");
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
