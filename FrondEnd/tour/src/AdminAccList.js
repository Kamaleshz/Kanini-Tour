import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Navbar, Nav, Container } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

export default function AdminAccList(){

    const [acclist,setAccList] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        fetchAccList();
      },[]);

    const fetchAccList = async () => {
        try {
          const response = await axios.get(`https://localhost:7297/api/Agent/AcceptedStatus`);
          setAccList(response.data);
          setLoading(false);
        } catch (error) {
          console.error('Error fetching data:', error);
          setError('Error fetching data');
          setLoading(false);
        }
      };

      return(
        <div>
        <Navbar bg="light" expand="lg">
            <Container>
            <Navbar.Brand href="#">Your Logo</Navbar.Brand>
            
            <Navbar.Toggle aria-controls="navbarNav" />
            <Navbar.Collapse id="navbarNav">
                <Nav className="ml-auto">
                <Nav.Link href="/Home" active>Home</Nav.Link>
                <Nav.Link href="/Requested">Requested</Nav.Link>
                <Nav.Link href="/Accepted">Accepted</Nav.Link>
                <Nav.Link href="/Full">Full</Nav.Link>
                <Nav.Link href="/Add">Location</Nav.Link>
                </Nav>
            </Navbar.Collapse>
            
            <Nav.Link href="#">
                <FontAwesomeIcon icon={faUser} />
            </Nav.Link>
            <Nav.Link href="#" className="ml-2">Login</Nav.Link>
            </Container>
        </Navbar>

        <div className="container">
        <div className="row">
            {acclist.map((list) => (
            <div className="col-md-4" key={list.travelagent_Id}>
                <div className="card mb-4">
                <div className="card-body">
                    <p className="card-text">Name: {list.travelagent_Name}</p>
                    <p className="card-text">Contact: {list.travelagent_Contact}</p>
                    <p className="card-text">About: {list.travelagent_Description}</p>
                    <p className="card-text">Email: {list.travelagent_Email}</p>
                    <h6 className="card-text">Travel Agency: {list.travelagency_Name}</h6>
                    <p className="card-text">Status: {list.travelagent_Status}</p>
                </div>
                </div>
            </div>
            ))}
        </div>
        </div>
        </div>
      )
    }