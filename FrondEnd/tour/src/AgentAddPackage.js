import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Nav, Navbar, Modal, Button, Container } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

function AddPackage() {
  const [data, setData] = useState({
    package_Name: '',
    package_Type: '',
    package_Rate: 0,
    duration: '',
    package_Itinerary: '',
    package_Food: '',
    package_Hotel: '',
    location_Id: 0,
    travelagent_Id: 0,
    image: '',
  });

  useEffect(() => {
    const locationId = sessionStorage.getItem('location_Id');
    const travelagentId = sessionStorage.getItem('travelagent_Id');
    
    setData((prevData) => ({
      ...prevData,
      location_Id: locationId,
      travelagent_Id: travelagentId,
    }));
  }, []);

  const [showModal, setShowModal] = useState(false);
  const [isSuccess, setIsSuccess] = useState(false); 

  const handleImageInputChange = (event) => {
    const file = event.target.files[0];
    setData((prevData) => ({
      ...prevData,
      image: file,
    }));
  };

  const handlePackageInputChange = (event) => {
    const { name, value } = event.target;
    setData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleSubmit = async (event) => {
    event.preventDefault();

    const url = 'https://localhost:7297/api/Package';

    try {
      const formData = new FormData();
      for (const key in data) {
        if (key === 'image') {
          formData.append(key, data[key]);
        } else {
          formData.append(`package.${key}`, data[key]);
        }
      }

      const response = await axios.post(url, formData, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
      });

      if (response.status === 200) {
        console.log('Data posted successfully');
        setIsSuccess(true);
        const packageId = response.data.package_Id;
        sessionStorage.setItem('package_Id', packageId);
        setShowModal(true);
        setData({
          package_Name: '',
          package_Type: '',
          package_Rate: 0,
          duration: '',
          package_Itinerary: '',
          package_Food: '',
          package_Hotel: '',
          location_Id: 0,
          travelagent_Id: 0,
          image: '',
        });
      } else {
        console.error('Failed to post data');
      }
    } catch (error) {
      console.error('Error:', error);
    }
  };
  const handleLogout = () => {
    console.clear();
    sessionStorage.clear();
    window.location.href = '/AgentLogin';
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
      <Container>
        <div className="row justify-content-center">
          <div className="col-md-6">
            <div className="card">
            <div>
            <h4 className="card-header">Adding Package</h4>
            </div>
              <div className="card-body">
                <form onSubmit={handleSubmit} encType="multipart/form-data">
                  <div className="form-group">
                    <label htmlFor="packageName">Package Name:</label>
                    <input
                      type="text"
                      className="form-control"
                      id="packageName"
                      name="package_Name"
                      value={data.package_Name}
                      onChange={handlePackageInputChange}
                    />
                  </div>
                  <div className="form-group">
                    <label htmlFor="packageType">Package Type:</label>
                    <input
                      type="text"
                      className="form-control"
                      id="packageType"
                      name="package_Type"
                      value={data.package_Type}
                      onChange={handlePackageInputChange}
                    />
                  </div>
                  <div className="form-group">
                    <label htmlFor="packageRate">Package Rate:</label>
                    <input
                      type="number"
                      className="form-control"
                      id="packageRate"
                      name="package_Rate"
                      value={data.package_Rate}
                      onChange={handlePackageInputChange}
                    />
                  </div>
                  <div className="form-group">
                    <label htmlFor="packageDuration">Duration:</label>
                    <input
                      type="text"
                      className="form-control"
                      id="durations"
                      name="duration"
                      value={data.duration}
                      onChange={handlePackageInputChange}
                    />
                  </div>
                  <div className="form-group">
                    <label htmlFor="packageItinerary">Itinerary:</label>
                    <input
                      type="text"
                      className="form-control"
                      id="packageItinerary"
                      name="package_Itinerary"
                      value={data.package_Itinerary}
                      onChange={handlePackageInputChange}
                    />
                  </div>
                  <div className="form-group">
                    <label htmlFor="packageFood">Food:</label>
                    <input
                      type="text"
                      className="form-control"
                      id="packageFood"
                      name="package_Food"
                      value={data.package_Food}
                      onChange={handlePackageInputChange}
                    />
                  </div>
                  <div className="form-group">
                    <label htmlFor="packageHotel">Hotels:</label>
                    <input
                      type="text"
                      className="form-control"
                      id="packageHotel"
                      name="package_Hotel"
                      value={data.package_Hotel}
                      onChange={handlePackageInputChange}
                    />
                  </div>
                  <div className="form-group">
                    <label htmlFor="locationImage">Package Image:</label>
                    <input
                      type="file"
                      className="form-control-file"
                      id="locationImage"
                      name="image"
                      onChange={handleImageInputChange}
                    />
                  </div>
                  <div className="d-flex justify-content-center">
                    <button type="submit" className="btn btn-primary">
                      Submit
                    </button>
                  </div>
                </form>
              </div>
            </div>
          </div>
        </div>
      </Container>
      <Modal show={showModal} onHide={() => setShowModal(false)}>
        <Modal.Header closeButton>
          <Modal.Title>Success</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Package has been posted successfully.
        </Modal.Body>
        <Modal.Footer>
          <Button variant="primary" onClick={() => window.location.href = "/AddSpots"}>
            Close
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
}

export default AddPackage;
