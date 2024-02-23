import Nav from "react-bootstrap/Nav";
import React, { useState, useEffect } from "react";
import { Modal, Form } from "react-bootstrap";
import Table from "react-bootstrap/Table";
import "../TableModals/TableModalComponent.css";
import { AuthService } from "../../../requestServices";
import { DecryptData } from "../../../DecryptionUtils/DecryptionUtility";
import PaginationComponent from "../../Pagination/PaginationComponent";

function TableModalComponent({ showModal, setShowTableModal }) {
  const [activeTab, setActiveTab] = useState("buyCoin");
  const [sellCoinResult, setSellCoinResult] = useState([]);
  const [allCoinResult, setAllCoinResult] = useState([]);
  const [buyCoinResult, setBuyCoinResult] = useState([]);
  const itemsPerPage = 10;
  const [activePage, setActivePage] = useState(1);

  const handlePageChange = (pageNumber) => {
    setActivePage(pageNumber);
  };

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

  const getResultLengthByTab = () => {
    switch (activeTab) {
      case "buyCoin":
        return buyCoinResult.length;
      case "sellCoin":
        return sellCoinResult.length;
      case "allCoin":
        return allCoinResult.length;
      default:
        return 0;
    }
  };

  const totalItems = getResultLengthByTab();
  const totalPages = Math.ceil(totalItems / itemsPerPage);
  const startIndex = (activePage - 1) * itemsPerPage;
  const endIndex = startIndex + itemsPerPage;

  const formatDate = (dateString) => {
    const date = new Date(dateString);
    const year = date.getFullYear();
    const month = (date.getMonth() + 1).toString().padStart(2, "0");
    const day = date.getDate().toString().padStart(2, "0");
    return `${month}-${day}-${year}`;
  };

  const buyCoinContent = (
    <div>
      <Table striped bordered hover size="sm">
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
          {buyCoinResult.slice(startIndex, endIndex).length > 0 ? (
            buyCoinResult.slice(startIndex, endIndex).map((item, index) => (
              <tr key={item.operationId}>
                <td>{item.operationId}</td>
                <td>{item.customerName}</td>
                <td>{item.coinName}</td>
                <td>{item.coinValue}</td>
                <td>{item.customerBuyValue}</td>
                <td>{item.sumOfValue.toFixed(2)}</td>
                <td>{formatDate(item.buyDate)}</td>
              </tr>
            ))
          ) : (
            <tr>
              <td colSpan="7" style={{ height: "150px" }}>
                <div className="no-records">No Records</div>
              </td>
            </tr>
          )}
        </tbody>
      </Table>
      <PaginationComponent
        totalPages={totalPages}
        onPageChange={handlePageChange}
      />
    </div>
  );

  const sellCoinContent = (
    <div>
      <Table striped bordered hover size="sm">
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
          {sellCoinResult.slice(startIndex, endIndex).length > 0 ? (
            sellCoinResult.slice(startIndex, endIndex).map((item, index) => (
              <tr key={item.operationId}>
                <td>{item.operationId}</td>
                <td>{item.customerName}</td>
                <td>{item.coinName}</td>
                <td>{item.coinValue}</td>
                <td>{item.customerSellValue}</td>
                <td>{item.sumOfValue.toFixed(2)}</td>
                <td>{formatDate(item.sellDate)}</td>
              </tr>
            ))
          ) : (
            <tr>
              <td colSpan="7" style={{ height: "150px" }}>
                <div className="no-records">No Records</div>
              </td>
            </tr>
          )}
        </tbody>
      </Table>
      <PaginationComponent
        totalPages={totalPages}
        onPageChange={handlePageChange}
      />
    </div>
  );

  const tableContent =
    allCoinResult.slice(startIndex, endIndex).length > 0 ? (
      allCoinResult.slice(startIndex, endIndex).map((item, index) => (
        <tr
          key={index}
          className={`${
            item.buyCoinValue !== undefined ? "buyCoin" : "sellCoin"
          }`}
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
      ))
    ) : (
      <tr>
        <td colSpan="12" style={{ height: "150px" }}>
          <div className="no-records">No Records</div>
        </td>
      </tr>
    );

  const allCoinContent = (
    <div>
      <Table striped bordered hover size="sm">
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
        <tbody>{tableContent}</tbody>
      </Table>
      <PaginationComponent
        totalPages={totalPages}
        onPageChange={handlePageChange}
      />
    </div>
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
                onSelect={(key) => {
                  setActiveTab(key);
                  setActivePage(1);
                }}
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
