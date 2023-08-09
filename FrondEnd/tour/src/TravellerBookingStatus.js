import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { Navbar, Nav, Container, NavDropdown, Card } from 'react-bootstrap';
import { PDFDownloadLink, Document, Page, Text, StyleSheet } from '@react-pdf/renderer';

function BookingDetails() {
  const navigate = useNavigate();
  const [bookingDetailsList, setBookingDetailsList] = useState([]);
  const [packageDetails, setPackageDetails] = useState({});
  const bookingId = sessionStorage.getItem('booking_Id');
  const packageId = sessionStorage.getItem('package_Id');
  const [isConfirmed, setIsConfirmed] = useState(false);

  useEffect(() => {
    if (bookingId) {
      fetch(`https://localhost:7257/api/Booking/Booking_Id?Booking_Id=${bookingId}`)
        .then(response => response.json())
        .then(data => {
          setBookingDetailsList(data);
          setIsConfirmed(data[0].booking_Status === 1);
        })
        .catch(error => {
          console.error('Error fetching booking details:', error);
        });
    }
  }, [bookingId]);

  useEffect(() => {
    if (packageId) {
      fetch(`https://localhost:7297/api/Package/Package_Id?Package_Id=${packageId}`)
        .then(response => response.json())
        .then(data => {
          setPackageDetails(data[0]);
        })
        .catch(error => {
          console.error('Error fetching package details:', error);
        });
    }
  }, [packageId]);

  function clearSessionStorage() {
    sessionStorage.clear();
  }

  const formatDate = dateString => {
    const date = new Date(dateString);
    return date.toDateString();
  };

  const handlePaymentClick = () => {
    navigate('/Payment');
  };

  const MyDocument = (
    <Document>
    <Page style={{ fontFamily: 'Helvetica', padding: 20 }}>
      <Text style={{ fontSize: 14, marginBottom: 10 }}>TourVista</Text>
      {bookingDetailsList.map((booking, index) => (
        <React.Fragment key={index}>
          <Text style={{ fontSize: 10 , textAlign:'center' }}>Booking Details</Text>
          <Text style={{ fontSize: 10 }}>Booking ID: {booking.booking_Id}</Text>
          <Text style={{ fontSize: 10 }}>Booking Date: {new Date(booking.booking_Date).toDateString()}</Text>
          <Text style={{ fontSize: 10 }}>Travellers Count: {booking.travellers_Count}</Text>
          <Text style={{ fontSize: 10 }}>Booked On: {new Date(booking.booked_On).toDateString()}</Text>
          <Text style={{ fontSize: 10 }}>Total Price: {booking.travellers_Count * packageDetails.package_Rate}</Text>

        </React.Fragment>
      ))}
      <Text style={{ fontSize: 10 , textAlign:'center' }}>Package Details</Text>
      <Text style={{ fontSize: 10 }}>Package Name: {packageDetails.package_Name}</Text>
      <Text style={{ fontSize: 10 }}>Package Type: {packageDetails.package_Type}</Text>
      <Text style={{ fontSize: 10 }}>Package Rate: {packageDetails.package_Rate}</Text>
      <Text style={{ fontSize: 10 }}>Duration: {packageDetails.duration}</Text>
    </Page>
  </Document>
  );

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
            <Nav.Link href="/"  onClick={clearSessionStorage} active>Home</Nav.Link>
            <Nav.Link href="/Filter" active>Package</Nav.Link>
            <Nav.Link href="#">Contact</Nav.Link>
          </Nav>
        </Navbar.Collapse>
        <Nav.Link href="#" className="ml-2" onClick={handleLogout}>
              Logout
        </Nav.Link>
      </Container>
    </Navbar>
      <div className="d-flex justify-content-center align-items-center" style={{ marginTop: '40px' }}>
        <Card style={{ width: '600px' }}>
          <Card.Body>
            <Card.Header>Booking Details</Card.Header>
            {bookingDetailsList.map((booking, index) => (
              <div key={index}>
                <Card.Text>Booking ID: {booking.booking_Id}</Card.Text>
                <Card.Text>Booking Date: {formatDate(booking.booking_Date)}</Card.Text>
                <Card.Text>Travellers Count: {booking.travellers_Count}</Card.Text>
                <Card.Text>Booked On: {formatDate(booking.booked_On)}</Card.Text>
                <Card.Text>
                  Booking Status: {booking.booking_Status === 0 ? 'Requested' : 'Confirmed'}
                </Card.Text>
                {booking.booking_Status === 1 && (
                  <PDFDownloadLink document={MyDocument} fileName="booking_details.pdf">
                    {({ blob, url, loading, error }) =>
                      loading ? 'Loading document...' : 'Download PDF'
                    }
                  </PDFDownloadLink>
                )}
                <button className="btn btn-primary" onClick={handlePaymentClick}>
                  Pay
                </button>
                <hr />
              </div>
            ))}
            <Card.Header>Package Details</Card.Header>
            <Card.Text>Package ID: {packageDetails.package_Id}</Card.Text>
            <Card.Text>Package Name: {packageDetails.package_Name}</Card.Text>
            <Card.Text>Package Type: {packageDetails.package_Type}</Card.Text>
            <Card.Text>Package Rate: {packageDetails.package_Rate}</Card.Text>
            <Card.Text>Duration: {packageDetails.duration}</Card.Text>
            <Card.Text>Package Itinerary: {packageDetails.package_Itenary}</Card.Text>
            <Card.Text>Package Food: {packageDetails.package_Food}</Card.Text>
            <Card.Text>Package Hotel: {packageDetails.package_Hotel}</Card.Text>
          </Card.Body>
        </Card>
      </div>
    </div>
  );
}

export default BookingDetails;
