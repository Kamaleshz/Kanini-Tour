import React, { useState } from 'react';
import axios from 'axios';
import { Navbar, Nav, Container, NavDropdown } from 'react-bootstrap';

function PaymentForm() {
  const [cardNumber, setCardNumber] = useState(0);
  const [cvv, setCvv] = useState(0);
  const [expiryDate, setExpiryDate] = useState('');
  const [cardHolderName, setCardHolderName] = useState('');

  const bookingId = sessionStorage.getItem('booking_Id');

  const handleSubmit = async (e) => {
    e.preventDefault();

    const apiUrl = 'https://localhost:7257/api/Payment';

    const requestData = {
      card_Number: cardNumber,
      cvv: cvv,
      expiry_Date: expiryDate,
      card_Holder_Name: cardHolderName,
      booking_Id: bookingId
    };

    try {
      const response = await axios.post(apiUrl, requestData);
      console.log('Response:', response.data);
      // Handle successful response here
    } catch (error) {
      console.error('Error:', error);
      // Handle error here
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
      <h2>Payment Form</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Card Number:</label>
          <input type="number" value={cardNumber} onChange={(e) => setCardNumber(e.target.value)} />
        </div>
        <div>
          <label>CVV:</label>
          <input type="number" value={cvv} onChange={(e) => setCvv(e.target.value)} />
        </div>
        <div>
          <label>Expiry Date:</label>
          <input type="text" value={expiryDate} onChange={(e) => setExpiryDate(e.target.value)} />
        </div>
        <div>
          <label>Card Holder Name:</label>
          <input type="text" value={cardHolderName} onChange={(e) => setCardHolderName(e.target.value)} />
        </div>
        <button type="submit">Submit</button>
      </form>
    </div>
  );
}

export default PaymentForm;
