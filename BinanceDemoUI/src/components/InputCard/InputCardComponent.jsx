import Card from "react-bootstrap/Card";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import "../InputCard/InputCardComponent.css";

const InputCardComponent = ({
  title,
  titleValue,
  text,
  textValue,
  columns = [],
}) => {
  return (
    <div className="some-parent-class mb-4">
      <Card className="panel-like-card">
        <Card.Body>
          {title && <Card.Title>{titleValue}</Card.Title>}
          {text ? (
            <Card.Text>{textValue}</Card.Text>
          ) : (
            <Row className="justify-content-center align-items-center text-center">
              {columns.map((column, index) => (
                <Col
                  key={index}
                  md={column.md || Math.floor(12 / columns.length)}
                  className="custom-card-text"
                >
                  {column.text}
                </Col>
              ))}
            </Row>
          )}
        </Card.Body>
      </Card>
    </div>
  );
};

export default InputCardComponent;
