import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Navbar, Nav, Container } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

export default function AdminLanding() {
  const [status, setStatus] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    fetchLocation();
  },[]);

  const fetchLocation = async () => {
    try {
      const response = await axios.get(`https://localhost:7297/api/Agent/RequestedStatus`);
      setStatus(response.data);
      setLoading(false);
    } catch (error) {
      console.error('Error fetching data:', error);
      setError('Error fetching data');
      setLoading(false);
    }
  };

  function clearSessionStorage() {
    sessionStorage.clear();
  }

  return (
    <div>
      <Navbar bg="light" expand="lg">
        <Container>
          <Navbar.Brand href="#">TourVista</Navbar.Brand>
          
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
          <Nav.Link href="/" className="ml-2">Logout</Nav.Link>
        </Container>
      </Navbar>
      
      <div className="container">
        <div className="row">
            {status.map((agent) => (
            <div className="col-md-4" key={agent.travelagent_Id}>
                <div className="card mb-4">
                <div className="card-body">
                    <p className="card-text">Name: {agent.travelagent_Name}</p>
                    <p className="card-text">Contact: {agent.travelagent_Contact}</p>
                    <p className="card-text">About: {agent.travelagent_Description}</p>
                    <p className="card-text">Email: {agent.travelagent_Email}</p>
                    <h6 className="card-text">Travel Agency: {agent.travelagency_Name}</h6>
                    <p className="card-text">Status: {agent.travelagent_Status}</p>
                    <div className="button-container">
                    <button
                        onClick={() => 
                            {
                                const requestBody = {
                                "id": agent.travelagent_Id
                                };
                                fetch(`https://localhost:7297/api/Agent/AcceptStatus?Id=${agent.travelagent_Id}`, {
                                method: "PUT",
                                headers: {
                                    "Accept": "application/json",
                                    "Content-Type": "application/json",
                                },
                                body: JSON.stringify(requestBody)
                                })
                                .then(response => response.json())
                                .then(data => {
                                fetchLocation();
                                })
                                .catch(error => console.log(error));
                            }}
                        className="btn btn-success mr-2"
                    >
                        Accept
                    </button>&nbsp;
                    <button
                        onClick={() => 
                            {
                                const requestBody = {
                                "id": agent.travelagent_Id
                                };
                                fetch(`https://localhost:7297/api/Agent/DeclineStatus?Id=${agent.travelagent_Id}`, {
                                method: "PUT",
                                headers: {
                                    "Accept": "application/json",
                                    "Content-Type": "application/json",
                                },
                                body: JSON.stringify(requestBody)
                                })
                                .then(response => response.json())
                                .then(data => {
                                fetchLocation();
                                })
                                .catch(error => console.log(error));
                            }}
                        className="btn btn-danger"
                    >
                        Decline
                    </button>
                    </div>
                </div>
                </div>
            </div>
            ))}
        </div>
      </div>
    </div>
  );
}  
