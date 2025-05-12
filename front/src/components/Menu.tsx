import { Container, NavDropdown, Navbar, Nav } from "react-bootstrap";
import { NavLink } from "react-router-dom";

const Menu = () => {
  return (
    <Navbar bg="dark" expand="lg" variant="dark">
      <Container>
        <Navbar.Brand as={NavLink} to="/">
          Home
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link as={NavLink} to="/care">
              Cuidados
            </Nav.Link>
            <Nav.Link as={NavLink} to="/animal">
              Animais
            </Nav.Link>
          </Nav>          
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};

export default Menu;
