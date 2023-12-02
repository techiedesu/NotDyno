import Container from "react-bootstrap/Container";
import styled from "styled-components";

const CenteredText = styled.p`
  text-align: center;
`;

const FooterComponent = () => (
  <>
    <footer className="mt-auto">
      <Container>
        <hr />
        <CenteredText>Not-Dyno &copy; 2023</CenteredText>
      </Container>
    </footer>
  </>
);

export default FooterComponent;
