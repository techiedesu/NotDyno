import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import { Link } from "react-router-dom";

const MainNavbar = () => (
  <Navbar
    bg="dark"
    data-bs-theme="dark"
    expand="md"
    className="bg-body-tertiary"
  >
    <Container fluid>
      <Navbar.Brand href="#home">Not Dyno</Navbar.Brand>
      <Navbar.Toggle aria-controls="basic-navbar-nav" />
      <Navbar.Collapse id="basic-navbar-nav">
        <Nav className="me-auto">
          <Nav.Link as={Link} to={`/`} className="me-auto">
            Home
          </Nav.Link>
          <Nav.Link as={Link} to={`/premium`}>
            Premium
          </Nav.Link>
        </Nav>
      </Navbar.Collapse>
    </Container>
  </Navbar>
);

export default MainNavbar;
