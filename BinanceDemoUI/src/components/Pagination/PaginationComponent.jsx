import Pagination from "react-bootstrap/Pagination";
import React, { useState } from "react";

const PaginationComponent = ({ totalPages, onPageChange }) => {
  const [activePage, setActivePage] = useState(1);

  const handlePageChange = (pageNumber) => {
    setActivePage(pageNumber);
    onPageChange(pageNumber);
  };

  const generatePaginationItems = () => {
    let items = [];

    items.push(
      <Pagination.Item
        key="first"
        active={activePage === 1}
        onClick={() => handlePageChange(1)}
      >
        1
      </Pagination.Item>
    );

    if (totalPages <= 10) {
      for (let page = 2; page <= totalPages; page++) {
        items.push(
          <Pagination.Item
            key={page}
            active={activePage === page}
            onClick={() => handlePageChange(page)}
          >
            {page}
          </Pagination.Item>
        );
      }
    } else {
      let startPage = Math.max(2, activePage - 4);
      let endPage = Math.min(totalPages - 1, activePage + 4);

      if (activePage < 5) {
        endPage = 9;
      }

      if (activePage > totalPages - 5) {
        startPage = totalPages - 8;
      }

      if (startPage > 2) {
        items.push(<Pagination.Ellipsis key="ellipsis-start" />);
      }

      for (let page = startPage; page <= endPage; page++) {
        items.push(
          <Pagination.Item
            key={page}
            active={activePage === page}
            onClick={() => handlePageChange(page)}
          >
            {page}
          </Pagination.Item>
        );
      }

      if (endPage < totalPages - 1) {
        items.push(<Pagination.Ellipsis key="ellipsis-end" />);
      }
    }

    items.push(
      <Pagination.Item
        key="last"
        active={activePage === totalPages}
        onClick={() => handlePageChange(totalPages)}
      >
        {totalPages}
      </Pagination.Item>
    );

    return items;
  };

  return (
    <Pagination>
      <Pagination.First onClick={() => handlePageChange(1)} />
      <Pagination.Prev
        onClick={() => handlePageChange(Math.max(1, activePage - 1))}
      />
      {generatePaginationItems()}
      <Pagination.Next
        onClick={() => handlePageChange(Math.min(totalPages, activePage + 1))}
      />
      <Pagination.Last onClick={() => handlePageChange(totalPages)} />
    </Pagination>
  );
};

export default PaginationComponent;
