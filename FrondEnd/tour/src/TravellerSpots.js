import React, { useEffect, useState } from 'react';
import { Navbar, Nav, Container, NavDropdown, Button } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';

export default function Spot() {
  const [data, setData] = useState([]);
  const [packageDetails, setPackageDetails] = useState({});
  const packageId = sessionStorage.getItem('package_Id');
  const token = sessionStorage.getItem('Token');
  const traveller_Id = sessionStorage.getItem('traveller_Id');

  const navigate = useNavigate();

  useEffect(() => {
    if (packageId) {
      fetch(`https://localhost:7297/api/Spot?package_Id=${packageId}`)
        .then(response => response.json())
        .then(data => {
          setData(data);
        })
        .catch(error => console.error('Error fetching data:', error));
    }
  }, [packageId]);

  useEffect(() => {
    if (packageId) {
      fetch(`https://localhost:7297/api/Package/Package_Id?Package_Id=${packageId}`)
        .then(response => response.json())
        .then(packageData => {
          setPackageDetails(packageData[0]); // Assuming you're getting an array with a single package
        })
        .catch(error => console.error('Error fetching package details:', error));
    }
  }, [packageId]);

  const handleBookButtonClick = () => {
    if (token && traveller_Id && packageId) {
      navigate('/Booking');
    } else {
      navigate('/TravellerLogin');
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
      <div className="container">
        <h4 className="text-center mb-4">Package details</h4>
        <div className="text-center">
          <h5>{packageDetails.package_Name}</h5>
          <p>{packageDetails.package_Description}</p>
        </div>
        <div className="row">
          {data.map(item => (
            <div className="col-md-4" key={item.spot_Id}>
              <div className="card mb-4">
                <img
                  src={`https://localhost:7297/Uploads/${item.spot_Image}`}
                  className="card-img-top"
                  alt={item.spot_Name}
                  style={{ height: '250px', objectFit: 'cover' }}
                />
                <div className="card-body">
                  <h5 className="card-title">{item.spot_Name}</h5>
                  <p className="card-text">{item.spot_Description}</p>
                </div>
              </div>
            </div>
          ))}
        </div>
        <div className="text-center">
          {packageDetails.package_Itenary && (
            <div>
              <h6>Plan</h6>
              {packageDetails.package_Itenary.split(',').map((item, index) => (
                <p key={index}>{item.trim()}</p>
              ))}
            </div>
          )}
          <h6>Food:</h6>
          <p>{packageDetails.package_Food}</p>
          <h6>Hotels NearBy</h6>
          <p>{packageDetails.package_Hotel}</p>
          <h6>Travel Agent:</h6>
          <p>{packageDetails.travel_agents?.travelagent_Name}</p>
          <p>Contact: {packageDetails.travel_agents?.travelagent_Contact}</p>
          <Button variant="primary" onClick={handleBookButtonClick}>
            Book
          </Button>
        </div>
      </div>
    </div>
  );
}
