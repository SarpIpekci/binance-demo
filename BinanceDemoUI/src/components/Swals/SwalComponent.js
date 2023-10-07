import Swal from "sweetalert2";

const SwalComponent = ({ showSwal, errorMessages, title, icon }) => {
  if (showSwal) {
    Swal.fire({
      title: title,
      text: errorMessages,
      icon: icon,
      timer: 2000,
      showConfirmButton: false,
    });
  }

  return null;
};

export default SwalComponent;
