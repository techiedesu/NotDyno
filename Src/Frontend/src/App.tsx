import { Container } from "react-bootstrap";
import "./App.scss";
import MainNavbar from "./Components/MainNavbar";
import FooterComponent from "./Components/Footer";
import { ReactNode } from "react";

const App = (props: { children: ReactNode }) => (
  <>
    <MainNavbar />
    <Container>{props.children}</Container>
    <FooterComponent />
  </>
);

export default App;
