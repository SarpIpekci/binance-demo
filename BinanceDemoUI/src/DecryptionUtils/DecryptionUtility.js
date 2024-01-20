export function DecryptData(encryptedData) {
  const decodedData = atob(encryptedData);
  return decodedData;
}
