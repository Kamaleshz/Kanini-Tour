import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Navbar, Nav, Container } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

export default function AdminLanding() {

    const[location,setLocation] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        fetchData();
      },[]);

      const fetchData = async () => {
        try {
          const response = await axios.get(`https://localhost:7297/api/Location`);
          console.log(response.data)
          setLocation(response.data);
          setLoading(false);
        } catch (error) {
          console.error('Error fetching data:', error);
          setError('Error fetching data');
          setLoading(false);
        }
      };

      function clearSessionStorage() {
        sessionStorage.clear();
        window.location.href = '/';
      }
    
      return (
        <div>
          <Navbar bg="light" expand="lg">
            <Container>
              <Navbar.Brand href="#">Your Logo</Navbar.Brand>
              <Navbar.Toggle aria-controls="navbarNav" />
              <Navbar.Collapse id="navbarNav">
                <Nav className="ml-auto">
                  <Nav.Link href="/AdminLanding" active>Home</Nav.Link>
                  <Nav.Link href="/Requested">Requested</Nav.Link>
                  <Nav.Link href="/Accepted">Accepted</Nav.Link>
                  <Nav.Link href="/Full">Full</Nav.Link>
                  <Nav.Link href="/Add">Location</Nav.Link>
                </Nav>
              </Navbar.Collapse>
              <Nav.Link href="#">
                <FontAwesomeIcon icon={faUser} />
              </Nav.Link>
              <Nav.Link href="#" onClick={clearSessionStorage} className="ml-2">Logout</Nav.Link>
            </Container>
          </Navbar>
          <div className="container">
            <div className="row">
              <div className="row mb-3">
                <div className="col text-center">
                  <button
                    className="btn btn-primary"
                    onClick={() => {
                      window.location.href = "/Requested";
                    }}
                  >
                    Add Location
                  </button>
                </div>
              </div>
              {location.map((loc) => (
                <div className="col-md-4" key={loc.location_Id}>
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
                </div>
              ))}
            </div>
          </div>
        </div>
      );      
}  
