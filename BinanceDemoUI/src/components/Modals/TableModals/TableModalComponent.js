import Nav from "react-bootstrap/Nav";
import React, { useState, useEffect } from "react";
import { Modal, Form } from "react-bootstrap";
import Table from "react-bootstrap/Table";
import "../TableModals/TableModalComponent.css";
import { AuthService } from "../../../requestServices";
import { DecryptData } from "../../../DencryptionUtils/DencryptionUtility";

function TableModalComponent({ showModal, setShowTableModal }) {
  const [activeTab, setActiveTab] = useState("buyCoin");
  const [buyCoinResult, setBuyCoinResult] = useState([]);
  const [sellCoinResult, setSellCoinResult] = useState([]);
  const [allCoinResult, setAllCoinResult] = useState([]);

  const handleClose = () => {
    setShowTableModal(false);
  };

  let parsedData;

  const userDataFromLocalStorage = localStorage.getItem("userData");

  if (userDataFromLocalStorage !== null) {
    const decrypt = DecryptData(userDataFromLocalStorage);
    parsedData = JSON.parse(decrypt);
  }

  useEffect(() => {
    if (showModal) {
      async function fetchData() {
        try {
          const buyResult = await AuthService.fillBuyCoinTable(parsedData.id);
          setBuyCoinResult(buyResult);
          const sellResult = await AuthService.fillSellCoinTable(parsedData.id);
          setSellCoinResult(sellResult);
          const allResult = await AuthService.fillAllCoinTable(parsedData.id);
          setAllCoinResult(allResult);
        } catch (error) {
          console.error(error);
        }
      }
      fetchData();
    }
  }, [showModal]);

  const formatDate = (dateString) => {
    const date = new Date(dateString);
    const year = date.getFullYear();
    const month = (date.getMonth() + 1).toString().padStart(2, "0");
    const day = date.getDate().toString().padStart(2, "0");
    return `${month}-${day}-${year}`;
  };

  const buyCoinContent = (
    <Table striped bordered hover size="md">
      <thead>
        <tr>
          <th>Operation Id</th>
          <th>Customer Name</th>
          <th>Coin Name</th>
          <th>Coin Value</th>
          <th>Customer Buy Value</th>
          <th>Sum Of Value</th>
          <th>Buy Date</th>
        </tr>
      </thead>
      <tbody>
        {buyCoinResult.map((item, index) => (
          <tr key={item.operationId}>
            <td>{index + 1}</td>
            <td>{item.customerName}</td>
            <td>{item.coinName}</td>
            <td>{item.coinValue}</td>
            <td>{item.customerBuyValue}</td>
            <td>{item.sumOfValue.toFixed(2)}</td>
            <td>{formatDate(item.buyDate)}</td>
          </tr>
        ))}
      </tbody>
    </Table>
  );

  const sellCoinContent = (
    <Table striped bordered hover size="md">
      <thead>
        <tr>
          <th>Operation Id</th>
          <th>Customer Name</th>
          <th>Coin Name</th>
          <th>Coin Value</th>
          <th>Customer Sell Value</th>
          <th>Sum Of Value</th>
          <th>Sell Date</th>
        </tr>
      </thead>
      <tbody>
        {sellCoinResult.map((item, index) => (
          <tr key={item.operationId}>
            <td>{index + 1}</td>
            <td>{item.customerName}</td>
            <td>{item.coinName}</td>
            <td>{item.coinValue}</td>
            <td>{item.customerSellValue}</td>
            <td>{item.sumOfValue.toFixed(2)}</td>
            <td>{formatDate(item.sellDate)}</td>
          </tr>
        ))}
      </tbody>
    </Table>
  );

  const tableRows = allCoinResult.map((item, index) => (
    <tr
      key={index}
      className={`${item.buyCoinValue !== undefined ? "buyCoin" : "sellCoin"}`}
    >
      <td>{item.customerName}</td>
      <td>{item.buyCoinName}</td>
      <td>{item.sellCoinName}</td>
      <td>{item.buyCoinValue}</td>
      <td>{item.sellCoinValue}</td>
      <td>{item.buyCustomerValue}</td>
      <td>{item.sellCustomerValue}</td>
      <td>{item.buySumOfValue.toFixed(2)}</td>
      <td>{item.sellSumOfValue.toFixed(2)}</td>
      <td>{item.differences.toFixed(2)}</td>
      <td>{formatDate(item.buyDate)}</td>
      <td>{formatDate(item.sellDate)}</td>
    </tr>
  ));

  const allCoinContent = (
    <Table striped bordered hover size="md">
      <thead>
        <tr>
          <th>Customer Name</th>
          <th>Buy Coin Name</th>
          <th>Sell Coin Name</th>
          <th>Buy Coin Value</th>
          <th>Sell Coin Value</th>
          <th>Buy Customer Value</th>
          <th>Sell Customer Value</th>
          <th>Buy Sum Of Value</th>
          <th>Sell Sum Of Value</th>
          <th>Differences</th>
          <th>Buy Date</th>
          <th>Sell Date</th>
        </tr>
      </thead>
      <tbody>{tableRows}</tbody>
    </Table>
  );

  const renderActiveTabContent = () => {
    switch (activeTab) {
      case "buyCoin":
        return buyCoinContent;
      case "sellCoin":
        return sellCoinContent;
      case "allCoin":
        return allCoinContent;
      default:
        return null;
    }
  };

  return (
    <div>
      <>
        <Modal
          show={showModal}
          backdrop="static"
          keyboard={false}
          centered
          onHide={handleClose}
          dialogClassName="custom-modal"
        >
          <Form>
            <Modal.Header className="custom-header" closeButton>
              <Modal.Title>List The Coins You Trade With</Modal.Title>
            </Modal.Header>
            <Modal.Body>
              <Nav
                variant="tabs"
                activeKey={activeTab}
                onSelect={(key) => setActiveTab(key)}
              >
                <Nav.Item className="navLink">
                  <Nav.Link eventKey="buyCoin">Get Customer Buy Coins</Nav.Link>
                </Nav.Item>
                <Nav.Item className="navLink">
                  <Nav.Link eventKey="sellCoin">
                    Get Customer Sell Coins
                  </Nav.Link>
                </Nav.Item>
                <Nav.Item className="navLink">
                  <Nav.Link eventKey="allCoin">Get Customer All Coins</Nav.Link>
                </Nav.Item>
              </Nav>
              {renderActiveTabContent()}
            </Modal.Body>
          </Form>
        </Modal>
      </>
    </div>
  );
}

export default TableModalComponent;
