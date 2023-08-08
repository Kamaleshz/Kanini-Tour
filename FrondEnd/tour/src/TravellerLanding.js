import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Navbar, Nav, Container, NavDropdown } from 'react-bootstrap';
import { Link } from 'react-router-dom';

export default function Home() {
  const [location, setLocation] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    try {
      const response = await axios.get(`https://localhost:7297/api/Location`);
      setLocation(response.data);
      setLoading(false);
    } catch (error) {
      console.error('Error fetching data:', error);
      setError('Error fetching data');
      setLoading(false);
    }
  };

  const handleCardClick = (locationId) => {
    sessionStorage.setItem('location_Id', locationId);
  };

  return (
    <div>
    <div className="background-image">
    <Navbar bg="transparent" expand="lg" style={{ color: 'white', backdropFilter: 'blur(10px)' }}>
    <Container>
        <Navbar.Brand href="#" style={{  color: 'white' }}>
        TourVista
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="navbarNav" />
        <Navbar.Collapse id="navbarNav">
        <Nav className="ml-auto">
            <Nav.Link href="/" active style={{ color: 'white' }}>
            Home
            </Nav.Link>
            <Nav.Link href="/Package" active style={{ color: 'white' }}>
            Package
            </Nav.Link>
            <Nav.Link href="#" style={{ color: 'white' }}>
            Contact
            </Nav.Link>
        </Nav>
        </Navbar.Collapse>
        <NavDropdown
        title="Login"
        id="basic-nav-dropdown"
        alignRight
        >
        <NavDropdown.Item href="/TravellerLogin">Traveller</NavDropdown.Item>
        <NavDropdown.Item href="/AgentLogin">Travel Agent</NavDropdown.Item>
        <NavDropdown.Item href="/AdminLogin">Admin</NavDropdown.Item>
        </NavDropdown>
    </Container>
    </Navbar>
    <Container style={{ display: 'flex', alignItems: 'center', justifyContent: 'center', height: '75vh' }}>
        <div className="centered-text">
          <h1 className="responsive-font">Welcome to TourVista</h1>
        </div>
        <div className="down-arrow">
          <span className="arrow"></span>
        </div>
      </Container>
    <div className="container" style={{ paddingTop: '50px' }}>
          <div className="row">
            {location.map((loc) => (
              <div className="col-md-4" key={loc.location_Id}>
                <Link
                  to="/Package"
                  onClick={() => handleCardClick(loc.location_Id)}
                  style={{ textDecoration: 'none', color: 'inherit' }}
                >
                  <div
                    className="card mb-4"
                    style={{
                      transition: 'transform 0.3s',
                      transformOrigin: 'center',
                      transform: 'scale(1)',
                      boxShadow: '0 4px 8px 0 rgba(0, 0, 0, 0.2)',
                    }}
                    onMouseEnter={(e) => {
                      e.currentTarget.style.transform = 'scale(1.05)';
                      e.currentTarget.style.boxShadow = '0 8px 16px 0 rgba(0, 0, 0, 0.2)';
                    }}
                    onMouseLeave={(e) => {
                      e.currentTarget.style.transform = 'scale(1)';
                      e.currentTarget.style.boxShadow = '0 4px 8px 0 rgba(0, 0, 0, 0.2)';
                    }}
                  >
                    <img
                      src={`https://localhost:7297/Uploads/${loc.location_Image}`}
                      className="card-img-top"
                      alt={loc.location_Name}
                      style={{ height: '400px', objectFit: 'cover' }}
                    />
                    <div className="card-body">
                      <h5 className="card-title">{loc.location_Name}</h5>
                    </div>
                  </div>
                </Link>
              </div>
            ))}
          </div>
        </div>
      </div>
    </div>
  );
}
