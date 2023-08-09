import React, { useState } from 'react';
import axios from 'axios';
import { Navbar, Nav, Container, Button, Modal } from 'react-bootstrap';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import 'bootstrap/dist/css/bootstrap.min.css';

function AddSpot() {
  const [data, setData] = useState({
    spot_Name: '',
    spot_Description: '',
    package_Id: sessionStorage.getItem('package_Id') || 0,
    imageFile: '',
  });

  const [showModal, setShowModal] = useState(false); // Add this line


  const handleImageInputChange = (event) => {
    const file = event.target.files[0];
    setData((prevData) => ({
      ...prevData,
      imageFile: file,
    }));
  };

  const handleSpotInputChange = (event) => {
    const { name, value } = event.target;
    setData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleAddAnother = () => {
    setShowModal(false);
    setData({
      spot_Name: '',
      spot_Description: '',
      package_Id: sessionStorage.getItem('package_Id') || 0,
      imageFile: '',
    });
  };

  const handleClearAndRedirect = () => {
    setShowModal(false);

    // Items to retain
    const travelagentId = sessionStorage.getItem('travelagent_Id');

    sessionStorage.removeItem('location_Id');
    sessionStorage.removeItem('package_Id');
    sessionStorage.setItem('travelagent_Id', travelagentId);

    window.location.href = '/Agent';
  };

  const handleSubmit = async (event) => {
    event.preventDefault();

    const url = 'https://localhost:7297/api/Spot'; // Update with the correct API endpoint for adding spots

    try {
      const formData = new FormData();
      for (const key in data) {
        if (key === 'imageFile') {
          formData.append(key, data[key]);
        } else {
          formData.append(`spot.${key}`, data[key]);
        }
      }

      const response = await axios.post(url, formData, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
      });

      if (response.status === 200) {
        console.log('Data posted successfully');
        setShowModal(true);
        // Handle success, e.g., show a success modal
      } else {
        console.error('Failed to post data');
        // Handle failure, e.g., show an error message
      }
    } catch (error) {
      console.error('Error:', error);
      // Handle error, e.g., show an error message
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
        <div className="row justify-content-center">
          <div className="col-md-6">
            <div className="card">
              <div className="card-body">
                <h4 className="card-title">Adding Spot</h4>
                <form onSubmit={handleSubmit} encType="multipart/form-data">
                  <div className="form-group">
                    <label htmlFor="spotName">Spot Name:</label>
                    <input
                      type="text"
                      className="form-control"
                      id="spotName"
                      name="spot_Name"
                      value={data.spot_Name}
                      onChange={handleSpotInputChange}
                    />
                  </div>
                  <div className="form-group">
                    <label htmlFor="spotDescription">Spot Description:</label>
                    <input
                      type="text"
                      className="form-control"
                      id="spotDescription"
                      name="spot_Description"
                      value={data.spot_Description}
                      onChange={handleSpotInputChange}
                    />
                  </div>
                  <div className="form-group">
                    <label htmlFor="spotImage">Spot Image:</label>
                    <input
                      type="file"
                      className="form-control-file"
                      id="spotImage"
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
      <Modal show={showModal} onHide={() => setShowModal(false)}>
        <Modal.Header closeButton>
          <Modal.Title>Success</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Spot has been added successfully.
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleAddAnother}>
            Add Another Spot
          </Button>
          <Button variant="primary" onClick={handleClearAndRedirect}>
            No, Done Adding
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
}

export default AddSpot;
