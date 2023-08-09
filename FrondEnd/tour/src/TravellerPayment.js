import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
import axios from 'axios';
import { Navbar, Nav, Container, Card, Form, Button } from 'react-bootstrap';

function PaymentForm() {
  const [cardNumber, setCardNumber] = useState('');
  const [cvv, setCvv] = useState('');
  const [selectedDate, setSelectedDate] = useState(null);
  const [cardHolderName, setCardHolderName] = useState('');
  const navigate = useNavigate();

  const bookingId = sessionStorage.getItem('booking_Id');

  const handleSubmit = async (e) => {
    e.preventDefault();

    const apiUrl = 'https://localhost:7257/api/Payment';

    const requestData = {
      card_Number: cardNumber,
      cvv: cvv,
      expiry_Date: selectedDate ? selectedDate.toISOString().split('T')[0] : '',
      card_Holder_Name: cardHolderName,
      booking_Id: bookingId
    };

    try {
      const response = await axios.post(apiUrl, requestData);
      console.log('Response:', response.data);
      navigate('/BookingStatus');
    } catch (error) {
      console.error('Error:', error);
    }
  };

  const handleLogout = () => {
    console.clear();
    sessionStorage.clear();
    navigate('/');
  };

  const handleDateChange = (date) => {
    setSelectedDate(date);
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
              <Nav.Link href="/Filter" active>Package</Nav.Link>
              <Nav.Link href="#">Contact</Nav.Link>
            </Nav>
          </Navbar.Collapse>
          <Nav.Link href="#" className="ml-2" onClick={handleLogout}>
            Logout
          </Nav.Link>
        </Container>
      </Navbar>
      <Container className="d-flex justify-content-center align-items-center min-vh-100">
        <Card className="p-4">
          <h2 className="text-center mb-4">Payment Form</h2>
          <Form onSubmit={handleSubmit}>
            <Form.Group>
              <Form.Label>Card Number:</Form.Label>
              <Form.Control type="text" value={cardNumber} onChange={(e) => setCardNumber(e.target.value)} />
            </Form.Group>
            <Form.Group>
              <Form.Label>CVV:</Form.Label>
              <Form.Control type="text" value={cvv} onChange={(e) => setCvv(e.target.value)} />
            </Form.Group><br></br>
            <Form.Group>
              <Form.Label>Expiry Date:</Form.Label>
              <DatePicker
                selected={selectedDate}
                onChange={handleDateChange}
                className="form-control"
                dateFormat="yyyy-MM-dd"
                minDate={new Date()}
                isClearable
              />
            </Form.Group><br></br>
            <Form.Group>
              <Form.Label>Card Holder Name:</Form.Label>
              <Form.Control type="text" value={cardHolderName} onChange={(e) => setCardHolderName(e.target.value)} />
            </Form.Group><br></br>
            <Button className="btn btn-primary btn-block" type="submit">Submit</Button>
          </Form>
        </Card>
      </Container>
    </div>
  );
}

export default PaymentForm;
