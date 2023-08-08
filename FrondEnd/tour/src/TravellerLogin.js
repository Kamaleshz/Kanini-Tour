import React, { useState } from 'react';
import { useNavigate , Link } from 'react-router-dom';
import axios from 'axios';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { Navbar, Nav, Container, NavDropdown } from 'react-bootstrap';

const TravellerLogin = () => {
  const [traveller_Email, setEmail] = useState('');
  const [traveller_Password, setPassword] = useState('');
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const navigate = useNavigate();

  const handleLogin = async () => {
    try {
      const response = await axios.post('https://localhost:7135/api/TravellerToken/Authenticate', {
        traveller_Email,
        traveller_Password,
      });
  
      const token = response.data.token;
      const traveller_Id = response.data.traveller_Id;
      const package_Id = sessionStorage.getItem('package_Id');

      if (!token) {
        toast.error('Token ID not generated. Please check your credentials.');
        return;
      }
  
      sessionStorage.setItem('traveller_Id', traveller_Id);
      sessionStorage.setItem('Token', token);
  
      if (package_Id && token) {
        navigate('/Booking');
      } else {
        navigate('/Home');
      }
  
      setIsLoggedIn(true);
    } catch (error) {
      console.error('Error:', error);
      toast.error('Login credentials seem wrong. Please try again.');
    }
  };
  

  return (
    <div>
    <Navbar bg="light" expand="lg">
      <Container>
        <Navbar.Brand href="#">TourVista</Navbar.Brand>        
        <Navbar.Toggle aria-controls="navbarNav" />
        <Navbar.Collapse id="navbarNav">
          <Nav className="ml-auto">
            <Nav.Link href="/" active>Home</Nav.Link>
            <Nav.Link href="/Package" active>Package</Nav.Link>
            <Nav.Link href="#">Contact</Nav.Link>
          </Nav>
        </Navbar.Collapse>
        <NavDropdown title="Login" id="basic-nav-dropdown" alignRight>
          <NavDropdown.Item href="/TravellerLogin">Traveller</NavDropdown.Item>
          <NavDropdown.Item href="/AgentLogin">Travel Agent</NavDropdown.Item>
          <NavDropdown.Item href="/AdminLogin">Admin</NavDropdown.Item>
        </NavDropdown>
      </Container>
    </Navbar>
    <div className="container mt-5">
      <div className="row justify-content-center">
        <div className="col-md-6">
          <div className="card">
            <div>
              <h4 className="card-header">Traveller Login</h4>
            </div>
            <div className="card-body">
              <div className="mb-3">
                <label className="form-label">Email:</label>
                <input
                  type="email"
                  className="form-control"
                  value={traveller_Email}
                  onChange={(e) => setEmail(e.target.value)}
                />
              </div>
              <div className="mb-3">
                <label className="form-label">Password:</label>
                <input
                  type="password"
                  className="form-control"
                  value={traveller_Password}
                  onChange={(e) => setPassword(e.target.value)}
                />
              </div>
              <button className="btn btn-primary" onClick={handleLogin}>
                Login
              </button>
              <p className="mt-3">
                New user? <Link to="/TravellerRegister">Sign up Here</Link>
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
    </div>
  );
};

export default TravellerLogin;
