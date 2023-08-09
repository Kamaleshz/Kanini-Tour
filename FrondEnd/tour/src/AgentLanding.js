import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Navbar, Nav, Container } from 'react-bootstrap';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Link } from 'react-router-dom';

export default function AgentLanding() {
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

  const handleLogout = () => {
    console.clear();
    sessionStorage.clear();
    window.location.href = '/';
  };

  return (
    <div>
      <Navbar bg="light" expand="lg">
        <Container>
          <Navbar.Brand href="#">Your Logo</Navbar.Brand>
          <Navbar.Toggle aria-controls="navbarNav" />
          <Navbar.Collapse id="navbarNav">
            <Nav className="ml-auto">
              <Nav.Link href="/Agent" active>Home</Nav.Link>
              <Nav.Link href="/AgentAddedPackage">Package</Nav.Link>
            </Nav>
          </Navbar.Collapse>
          <Nav.Link href="#">
              <FontAwesomeIcon icon={faUser} />
            </Nav.Link>
            <Nav.Link href="#" className="ml-2" onClick={handleLogout}>
              Logout
            </Nav.Link>
        </Container>
      </Navbar>
      <div className="container">
        <div className="row">
        <h4 className="text-center mb-4">
            Click a location from below to add package.
          </h4>
          {location.map((loc) => (
            <div className="col-md-4" key={loc.location_Id}>
              <Link to="/AddPackage" onClick={() => handleCardClick(loc.location_Id)}>
                <div className="card mb-4">
                  <img
                    src={`https://localhost:7297/Uploads/${loc.location_Image}`}
                    className="card-img-top"
                    alt={loc.location_Name}
                    style={{ height: '500px', objectFit: 'cover' }}
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
  );
}
