import { Container } from "react-bootstrap";
import Button from "react-bootstrap/Button";
import Card from "react-bootstrap/Card";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import styled from "styled-components";

interface CardProps {
  Title: string;
  Text: string;
  PictureUrl: string;
  ButtonText: string;
  ButtonVariant: string;
}

const StyledCardTitle = styled(Card.Title)`
  text-align: center;
`;

const StyledCardText = styled(Card.Text)`
  text-align: center;
`;

const CenteredContainer = styled(Container)`
  text-align: center;
`;

const CardComponent = (props: CardProps) => (
  <Card style={{ width: "18rem" }}>
    <Card.Img variant="top" src={props.PictureUrl} />
    <Card.Body>
      <StyledCardTitle>{props.Title}</StyledCardTitle>
      <StyledCardText>{props.Text}</StyledCardText>
      <CenteredContainer>
        <Button variant={props.ButtonVariant}>{props.ButtonText}</Button>
      </CenteredContainer>
    </Card.Body>
  </Card>
);

const PremiumPage = () => (
  <>
    <CenteredContainer>
      <h1>Premium Plans</h1>
      <p>
        Upgrading to Non-Dyno Premium providing you with a same level of service
        and features.
      </p>
    </CenteredContainer>
    <Container className="d-flex justify-content-center">
      <Row xs={1} md={3} className="g-4">
        <Col key={1}>
          <CardComponent
            PictureUrl="/premium/IMG_20231017_235909.jpg"
            Title="Premium Free"
            Text="Free for everyone!"
            ButtonText="Apply for a loan"
            ButtonVariant="warning"
          />
        </Col>
        <Col key={2}>
          <CardComponent
            PictureUrl="/premium/IMG_20231101_121513.jpg"
            Title="$0"
            Text="Not-Dyno Premium for 1 server of your choice."
            ButtonText="Enter Credit Card"
            ButtonVariant="success"
          />
        </Col>
        <Col key={3}>
          <CardComponent
            PictureUrl="/premium/IMG_20231127_012826.jpg"
            Title="0 ETH"
            Text="Ultimate."
            ButtonText="Open Binance"
            ButtonVariant="info"
          />
        </Col>
      </Row>
    </Container>
  </>
);

export default PremiumPage;
