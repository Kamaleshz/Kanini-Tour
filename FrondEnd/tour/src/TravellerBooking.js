import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Modal, Button } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
import { Navbar, Nav, Container, NavDropdown } from 'react-bootstrap';


export default function Booking() {
  const navigate = useNavigate();

  const [bookingData, setBookingData] = useState({
    traveller_Id: sessionStorage.getItem('traveller_Id'),
    package_Id: sessionStorage.getItem('package_Id'),
    travellers_Count: 0,
    booked_On: new Date().toISOString(),
  });

  const [showSuccessModal, setShowSuccessModal] = useState(false);
  const [showErrorModal, setShowErrorModal] = useState(false);

  const handleSubmit = async (event) => {
    event.preventDefault();

    if (!bookingData.traveller_Id || !bookingData.package_Id) {
      setShowErrorModal(true);
      return;
    }

    try {
      const response = await fetch('https://localhost:7257/api/Booking', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(bookingData),
      });

      if (response.ok) {
        const data = await response.json(); // Assuming the response contains the booking_Id
        // Store the booking_Id in session storage
        sessionStorage.setItem('booking_Id', data.booking_Id);
        // Handle success, show the success modal
        setShowSuccessModal(true);
      } else {
        // Handle error, maybe show an error message
        console.error('Error submitting booking.');
      }
    } catch (error) {
      console.error('An error occurred:', error);
    }
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
    <div className="container mt-5">
      <div className="row justify-content-center">
        <div className="col-md-6">
          <div className="card">
            <div className="card-body">
              <h2 className="card-title">Booking Form</h2>
              <form onSubmit={handleSubmit}>
                <div className="mb-3">
                  <label htmlFor="travellersCount" className="form-label">
                    Travellers Count:
                  </label>
                  <input
                    type="number"
                    className="form-control"
                    id="travellersCount"
                    value={bookingData.travellers_Count}
                    onChange={(e) =>
                      setBookingData({
                        ...bookingData,
                        travellers_Count: parseInt(e.target.value),
                      })
                    }
                    required
                  />
                </div>
                <div className="mb-3">
                  <label htmlFor="bookedOn" className="form-label">
                    Booked On:
                  </label>
                  <input
                    type="datetime-local"
                    className="form-control"
                    id="bookedOn"
                    value={bookingData.booked_On}
                    onChange={(e) =>
                      setBookingData({
                        ...bookingData,
                        booked_On: e.target.value,
                      })
                    }
                    required
                  />
                </div>
                <button type="submit" className="btn btn-primary">
                  Submit Booking
                </button>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>

      {/* Success Modal */}
      <Modal show={showSuccessModal} onHide={() => setShowSuccessModal(false)}>
        <Modal.Header closeButton>
          <Modal.Title>Booking Successful</Modal.Title>
        </Modal.Header>
        <Modal.Body>Your booking was successful. Proceed for payment?</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={() => setShowSuccessModal(false)}>
            Close
          </Button>
          {/* Navigate to "/Payment" on button click */}
          <Button
            variant="primary"
            onClick={() => {
              setShowSuccessModal(false);
              navigate('/Status'); // Navigate to "/Payment" page
            }}
          >
            Proceed to Payment
          </Button>
        </Modal.Footer>
      </Modal>

      {/* Error Modal */}
      <Modal show={showErrorModal} onHide={() => setShowErrorModal(false)}>
        <Modal.Header closeButton>
          <Modal.Title>Error</Modal.Title>
        </Modal.Header>
        <Modal.Body>Some required data is missing. Please retry your booking.</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={() => setShowErrorModal(false)}>
            Close
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
}
